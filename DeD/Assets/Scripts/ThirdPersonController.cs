using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Transform Cam;
    public float h;
    public float v;
    public FixedButton Button;
    public FixedJoystick joystick;
    public float speed = 5f;
    Rigidbody rb;
    Vector3 direction;

    private void Start()
    {
        //cc = GetComponent < CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        /*
        h = joystick.Horizontal;
        v = joystick.Vertical;*/
        direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        Movement();
    }

   /* void jump()
    {
        Debug.Log("jump");
    }*/

    void Movement()
    {
        rb.velocity = direction * speed;
    }


}
