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
    public bool grounded;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask Ground;
    public GameObject Knight;
    Animator anim;
    private void Start()
    {
        //cc = GetComponent < CharacterController>();
        rb = GetComponent<Rigidbody>();
        anim = Knight.GetComponent<Animator>();
    }

    private void Update()
    {
        grounded = Physics.CheckSphere(GroundCheck.position, groundDistance, Ground);
        direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        if (grounded)
        {
            Movement();
        }
    }

    void Movement()
    {
        if (direction * speed != Vector3.zero)
        {
            rb.velocity = direction * speed;
            anim.SetFloat("Speed", 1);
        }
        else
        {
            anim.SetFloat("Speed", 0);

        }

    }


}
