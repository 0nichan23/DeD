using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    //public FixedButton Button;
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
    Vector3 relativeMove;
    public static bool isTouched;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = Knight.GetComponent<Animator>();
    }

    private void Update()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            isTouched = true;
        }
        else
        {
            isTouched = false;
        }
        grounded = Physics.CheckSphere(GroundCheck.position, groundDistance, Ground);
        direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        relativeMove = transform.forward * joystick.Vertical + transform.right * joystick.Horizontal;
        if (grounded && isTouched)
        {
            Movement();
        }
        if (relativeMove * speed != Vector3.zero)
        {
            anim.SetFloat("Speed", 1);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
    }

    void Movement()
    {
        if (relativeMove * speed != Vector3.zero)
        {
            rb.velocity = relativeMove * speed;
        }
    }


}
