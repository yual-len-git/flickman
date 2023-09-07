using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragObject : MonoBehaviour
{
    public GameObject dragLocation;
    public float dragDistance;
    private PlayerControls playerControls;
    public float dragSpeed;
    private float dragSpeedSaved;
    public int dragType = 0;
    private int isReleased = 0;
    public float fireworkForce;
    public float playerLaunchMultiplier;
    public float fuseTime;
    private bool fired = false;
    private bool hasJoint = false;
    public Rigidbody player;
    private FixedJoint temp;
    public ParticleSystem initOnDragFx;
    //fireworks
    public ParticleSystem initOnApexFx;
    //trashbag
    private int collisionCount;
    private bool recentlyDragged = false;
    public GameObject spawnOnCollision;
    public float collisionTargetForce;
    //stuff
    private Collider collisionSaved;
    private bool isCollided = false;
    //pig
    public CarMoveScript tempScript;
    public bool held = false;

    private bool isAttatched = false;
    public Transform attachLocation;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public bool IsAttached()
    {
        return isAttatched;
    }

    private void Start()
    {
        if(tempScript)
        {
            tempScript.enabled = true;
        }
        dragSpeedSaved = dragSpeed;
        isReleased = 0;
        if (dragType == 3)
        {
            gameObject.GetComponent<Rigidbody>().freezeRotation = false;
            gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            tempScript.enabled = false;
            StartCoroutine(reEnableIn(2));
        }
    }
    void Update()
    {
        float distancePlayer = Vector3.Distance(dragLocation.transform.position, transform.position);
        if ((distancePlayer < dragDistance) && playerControls.Walk.Drag.IsPressed() && PlayerMovement.objectDragCount <= 1)
        {
            isAttatched = true;
            isReleased = 1;
            if (isCollided && collisionSaved.gameObject.name == "DragLocation")
            {
                if (dragType == 1 && !fired)
                {
                    transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, 1);
                }
                if (!hasJoint)
                {
                    gameObject.GetComponent<Rigidbody>().freezeRotation = false;
                    recentlyDragged = true;
                    StartCoroutine(recentlyDraggedFor(5));
                    hasJoint = true;
                    temp = gameObject.AddComponent<FixedJoint>();
                    temp.connectedBody = player;
                }
                if (!fired)
                {
                    PlayerMovement.objectDragCount += 1;
                }
                if (dragType == 1 && !fired)
                {
                    fired = true;
                    if(initOnDragFx != null)
                    {
                        Debug.Log(initOnDragFx);
                        initOnDragFx.Play();
                    }
                    StartCoroutine(LaunchRocket(fuseTime));
                }
                if (dragType == 3 && !fired && tempScript)
                {
                    tempScript.enabled = false;
                }
            } else
            {
                transform.position = Vector3.MoveTowards(transform.position, dragLocation.transform.position, dragSpeed);
            }
        } else if ((playerControls.Walk.Drag.WasReleasedThisFrame() || (distancePlayer > dragDistance)) && (isReleased == 1))
        {
            isAttatched = false;
/*            if (dragType == 5)
            {
                transform.position = attachLocation.position;
                transform.parent = attachLocation;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
            }*/
            gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            PlayerMovement.objectDragCount -= 1;
            Destroy(temp);
            hasJoint = false;
            fired = false;
            isReleased = 0;
            if (dragType == 3)
            {
                StartCoroutine(reEnableIn(4));
            }
        }
    }

    IEnumerator reEnableIn(int v)
    {
        yield return new WaitForSeconds(v);
        tempScript.enabled = true;
    }

    IEnumerator recentlyDraggedFor(int v)
    {
        yield return new WaitForSeconds(v);
        recentlyDragged = false;
    }

    IEnumerator LaunchRocket(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (hasJoint)
        {
            fireworkForce *= playerLaunchMultiplier;
        }
        if (initOnDragFx != null)
        {
            initOnDragFx.Stop();
        }
        GetComponent<Rigidbody>().AddForce(transform.up * fireworkForce);
        StartCoroutine(Fireworks(2));
    }

    IEnumerator Fireworks(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        initOnApexFx.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (recentlyDragged && collision.gameObject.layer != 6)
        {
            collisionCount += 1;
        }
        if (collision.relativeVelocity.magnitude > collisionTargetForce && dragType == 2)
        {
            Instantiate(spawnOnCollision);
            spawnOnCollision.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isCollided = true;
        collisionSaved = other;
    }

    private void OnTriggerExit(Collider collision)
    {
        isCollided = false;
        collisionSaved = null;
    }
}
