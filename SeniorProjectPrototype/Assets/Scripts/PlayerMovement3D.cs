using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public Transform orientation;
    public float speed = 12f;
    public float groundDrag;
    public bool canMove;
    public bool isIdle = true;
    public float timeSinceLastStep = 0f;

    float hInput;
    float vInput;

    Vector3 moveDir;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        canMove = true;
    }

    void getInputs()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }

    void movePlayer()
    {
        if (canMove)
        {
            moveDir = orientation.forward * vInput + orientation.right * hInput;
            rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
            PlayFootStepAudio();
        }
    }

    // Update is called once per frame
    void Update()
    {
        getInputs();
        timeSinceLastStep += Time.deltaTime;
        if (hInput == 0 && vInput == 0)
        {
            enableIdle();
        }
        else
        {
            disableIdle();
        }
    }

    void FixedUpdate()
    {
        rb.drag = groundDrag;
        movePlayer();
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

        PlayFootStepAudio();
    }

    private void PlayFootStepAudio()
    {
        if (!canMove || isIdle || timeSinceLastStep < 0.66f)
        {
            return;
        }
        if (!isIdle && timeSinceLastStep >= 0.66f)
        {
            AkSoundEngine.PostEvent("Play_Footsteps", gameObject);
            timeSinceLastStep = 0;
        }
    }

    public void disableMovement()
    {
        canMove = false;
    }

    public void enableMovement()
    {
        canMove = true;
    }

    public void disableIdle()
    {
        isIdle = false;
    }

    public void enableIdle()
    {
        isIdle = true;
    }
}
