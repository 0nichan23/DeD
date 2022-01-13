using Cinemachine;
using UnityEngine;


public class CinemachineCoreGetInputTouchAxis : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Transform Knight;
    [SerializeField] Transform Cam;
    public float TouchSensitivity_x = 10f;
    public float TouchSensitivity_y = 10f;

    // Use this for initialization
    void Start()
    {
        CinemachineCore.GetInputAxis = HandleAxisInputDelegate;
    }
    private void Update()
    {
        Player.rotation = Cam.rotation;
        Player.transform.eulerAngles = new Vector3(0, Player.transform.eulerAngles.y, 0);
        Knight.rotation = Cam.rotation;
        Knight.transform.eulerAngles = new Vector3(0, Knight.transform.eulerAngles.y, 0);

    }

    float HandleAxisInputDelegate(string axisName)
    {



        if (!ThirdPersonController.isTouched)
        {

            switch (axisName)
            {

                case "Mouse X":

                    if (Input.touchCount > 0)
                    {
                        return Input.touches[0].deltaPosition.x / TouchSensitivity_x;
                    }
                    else
                    {
                        return Input.GetAxis(axisName);
                    }

                case "Mouse Y":
                    if (Input.touchCount > 0)
                    {
                        return Input.touches[0].deltaPosition.y / TouchSensitivity_y;
                    }
                    else
                    {
                        return Input.GetAxis(axisName);
                    }

                default:
                    Debug.LogError("Input <" + axisName + "> not recognyzed.", this);
                    break;
            }
        }

        return 0f;
    }
}