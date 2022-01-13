using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class DSTP : MonoBehaviour
{
    public static bool isTouched = false;
    private CharacterController controller;
    [SerializeField] private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public FixedButton Button;
    public FixedJoystick joystick;
    Transform cam;
    private void Start()
    {
        //cam = Camera.main.transform;
        //controller = gameObject.AddComponent<CharacterController>();
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            isTouched = true;

        }
        else
        {
            isTouched = false;
        }
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        Vector3 relativeMove = transform.forward * joystick.Vertical + transform.right * joystick.Horizontal;
        controller.Move(relativeMove * Time.deltaTime * playerSpeed);
        //Debug.Log(move);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        //Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    public void Jump()
    {
        if (groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
    }
}

//cinemachine , camera rotation sets player rotation (only y)
//play with speed and stuff
