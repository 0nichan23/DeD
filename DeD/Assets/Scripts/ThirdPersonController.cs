using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Transform Cam;
    Vector3 camForward;
    Vector3 move;
    public float h;
    public float v;
    public FixedButton Button;
    CharacterController cc;
    public FixedJoystick joystick;
    public float speed = 5f;
    public LayerMask layer;
    public bool isGrounded;
    public float JumpForce =5f;
    public Transform GroundCheck;
    float checkRad = 0.4f;
    float gravity = -9.81f;
    Vector3 velocity;

    private void Start()
    {
        cc = GetComponent < CharacterController>();
    }

    private void Update()
    {
        //isGrounded = Physics.CheckSphere(GroundCheck.position, checkRad, layer);
        h = joystick.Horizontal;
        v = joystick.Vertical;
        if (Button.Pressed && isGrounded)
        {
            jump();
        }
        else if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            //cc.Move(velocity * Time.deltaTime);
        }
        Movement();
    }

    void jump()
    {
        Debug.Log("jump");
    }

    void Movement()
    {
        if (joystick.Vertical > 0)
        {
            cc.Move(cc.transform.forward * speed * Time.deltaTime);
        }
        else if (joystick.Vertical < 0)
        {
            cc.Move(cc.transform.forward * speed * Time.deltaTime * -1);
        }
        if (joystick.Horizontal > 0)
        {
            cc.Move(cc.transform.right * speed * Time.deltaTime);
        }
        else if (joystick.Horizontal < 0)
        {
            cc.Move(cc.transform.right * speed * Time.deltaTime * -1);
        }
        //cc.Move(joystick.Vertical * speed * Time.deltaTime);
    }


}
