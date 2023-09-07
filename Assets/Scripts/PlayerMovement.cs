using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public static bool hasLiftTicket = false;
    public Rigidbody controller;
    public CinemachineSwitcher cameraSwitcher;
    public GoalController gc;
    public Transform lookThirdPPoint;
    public Transform lookFirstPPoint;
    public CanvasGroup allUI;
    public float moveSpeed = 6f;
    public float turnSmooth = 0.1f;
    public float sensitivity = .3f;
    public bool invertLook = false;
    [SerializeField]
    private float jumpHeight = 1.0f;
    private Animator anim;
    public PhotoDisplay photoDisplay;

    private PlayerControls playerControls;
    private bool groundedPlayer;
    private Vector3 playerVelocity;
    private Vector2 DeltaPointer;
    private Vector2 MoveDirection;
    private bool PhotoMode = false;

    public static int objectDragCount = 0;

    GameObject attachedTo;
    private bool onLift;
    private bool waitingForLift;
    private bool jumping;
    public GameObject noLiftTicketUI;

    public float hitForce;
    private bool isRagdoll = false;
    private bool rotateBack = false;
    private bool singleHit = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        onLift = false;
        waitingForLift = false;
        jumping = false;
        playerControls = new PlayerControls();
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        CameraChange();

        if (playerControls.Walk.Photograph.WasPressedThisFrame() && PhotoMode)
        {
            StartCoroutine(TakePhoto());
        }

        Vector3 tempMove = new Vector3(Math.Abs(MoveDirection.x), 0, Math.Abs(MoveDirection.y)).normalized;
        anim.SetFloat("Speed", tempMove.x > tempMove.z ? tempMove.x : tempMove.z);

        if (onLift) {
            //match lift speed, position, and rotation
            transform.rotation = attachedTo.transform.rotation;
            Vector3 pos = attachedTo.transform.position + 0.4f * attachedTo.transform.forward;
            pos.y -= 4.05f;
            transform.position = pos;
        }

        if(rotateBack)
        {
            transform.rotation = (Quaternion.RotateTowards(transform.rotation, new Quaternion(0, 0, 0, 1), 2));
            if (transform.rotation == new Quaternion(0, 0, 0, 1))
            {
                controller.isKinematic = false;
                rotateBack = false;
                isRagdoll = false;
                controller.freezeRotation = true;
                singleHit = true;
            }
        }
    }

    void FixedUpdate () 
    {
        Look();
        MovePlayer();
    }

    private void CameraChange()
    {
        if(playerControls.Walk.Viewfinder.IsPressed() && !PhotoMode)
        {
            isRagdoll = true;
            cameraSwitcher.EnterViewfinder();
            PhotoMode = true;
        } else if(!playerControls.Walk.Viewfinder.IsPressed() && PhotoMode)
        {
            isRagdoll = false;
            cameraSwitcher.ExitViewfinder();
            PhotoMode = false;
        }
    }

    private void MovePlayer()
    {
        if (!isRagdoll)
        {
            MoveDirection = playerControls.Walk.Move.ReadValue<Vector2>();
            Vector3 move = new Vector3(MoveDirection.x, 0, MoveDirection.y).normalized * moveSpeed * Time.deltaTime;

            if (playerControls.Walk.Jump.IsPressed() && isGrounded())
            {
                controller.velocity = new Vector3(controller.velocity.x, jumpHeight, controller.velocity.y);
            }

            controller.velocity = (transform.TransformDirection(move)) + new Vector3(0f, controller.velocity.y, 0f);
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.1f);
    }

private void Look()
    {
        DeltaPointer = playerControls.Walk.Look.ReadValue<Vector2>() * sensitivity;

        lookThirdPPoint.Rotate(new Vector3(DeltaPointer.y * (invertLook ? 1 : -1), 0, 0), Space.Self);
        lookFirstPPoint.Rotate(new Vector3(DeltaPointer.y * (invertLook ? 1 : -1), 0, 0), Space.Self);
        lookThirdPPoint.localEulerAngles = new Vector3(lookThirdPPoint.localEulerAngles.x, 0, 0);
        lookFirstPPoint.localEulerAngles = new Vector3(lookFirstPPoint.localEulerAngles.x, 0, 0);
        transform.Rotate(new Vector3(0, DeltaPointer.x, 0));
    }

    IEnumerator TakePhoto()
    {
        allUI.alpha = 0;
        yield return new WaitForEndOfFrame();
        photoDisplay.PushPhoto(CaptureScreen());
        allUI.alpha = 1;
        gc.CheckObjectives();
    }

    public static Texture2D CaptureScreen()
    {
        //Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);
        //Read screen contents into the texture
        screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        screenshot.Apply();

        return screenshot;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("chair") && !onLift && waitingForLift && hasLiftTicket) {
            onLift = true;
            waitingForLift = false;
            attachedTo = collision.gameObject;
            anim.SetTrigger("liftStart");
        }

        if (collision.gameObject.name == "end lift") {
            onLift = false;
            waitingForLift = false;
            anim.SetTrigger("liftEnd");
        }

        if (collision.gameObject.name.Contains("CARHIT") && singleHit)
        {
            singleHit = false;
            isRagdoll = true;
            StartCoroutine(ragdollTime(2));
            controller.freezeRotation = false;
            controller.AddForce(collision.relativeVelocity * hitForce);
        }
    }

    IEnumerator ragdollTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        controller.isKinematic = true;
        rotateBack = true;
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.name == "player wait" && !onLift && !waitingForLift) {
            if (!hasLiftTicket) {
                noLiftTicketUI.SetActive(true);
            }
            else {
                waitingForLift = true;
            }
        }
    }

    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.name == "player wait") {
            noLiftTicketUI.SetActive(false);
        }
    }
}
