using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public static bool someoneOnJump = false;
        public bool snowboarder;
        public Rigidbody rb;
        public Animator animator;
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;

        float distanceTravelled;
        GameObject attachedTo;
        bool onLift;
        bool waitingForLift;
        bool jumping;

        void Start() {
            onLift = false;
            waitingForLift = false;
            jumping = false;

            distanceTravelled = Random.value * 1000;

            if (snowboarder)
                animator.SetBool("snowboarder", true);
            else
                animator.SetBool("snowboarder", false);

            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null && !waitingForLift)
            {
                distanceTravelled += speed * Time.deltaTime;
                Vector3 pos = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                Vector3 next = pathCreator.path.GetPointAtDistance(distanceTravelled + speed * Time.deltaTime, endOfPathInstruction);

                if (onLift) {
                    // match lift speed, position, and rotation
                    speed = 3;
                    transform.rotation = attachedTo.transform.rotation;
                    pos = attachedTo.transform.position + 0.4f * attachedTo.transform.forward;
                    pos.y -= 4.05f;
                }
                else if (!jumping){
                    // make height the terrain height
                    pos.y = Terrain.activeTerrain.SampleHeight(transform.position) - 12.49275f;
                    next.y = Terrain.activeTerrain.SampleHeight(next) - 12.49275f;
                }

                transform.position = pos;
                
                if (!onLift) {
                    transform.LookAt(next);
                }
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            print("oh no the path changed");
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "wait" && !onLift && !waitingForLift) {
                waitingForLift = true;
            }
            if (collision.gameObject.name.Contains("chair") && !onLift && waitingForLift) {
                onLift = true;
                waitingForLift = false;
                attachedTo = collision.gameObject;
                animator.SetTrigger("liftStart");
            }

            if (collision.gameObject.name == "end lift") {
                onLift = false;
                animator.SetTrigger("liftEnd");
                speed = 5;
            }

            if (collision.gameObject.name.Contains("Ramp")) {
                jumping = true;
                someoneOnJump = true;
            }

            if (jumping && collision.gameObject.name == "end jump") {
                jumping = false;
                someoneOnJump = false;
            }
        }
    }
}