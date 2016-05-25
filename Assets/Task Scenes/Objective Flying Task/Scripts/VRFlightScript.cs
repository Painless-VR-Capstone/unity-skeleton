using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VRFlightScript : MonoBehaviour {
    public Transform camRigTransform, sphereLeaderTransform, restObject, leftObject, rightObject;
    public Text countDown;
    public float camSpeed;
    public Renderer perifereeMaterial1, perifereeMaterial2;
    public int controlScheme, shiftAmount;

    private float leftDist, rightDist;
    private int startTimer = 300;
    private Vector3 rotationAxis, projectedForward;
    private Vector2 eyeVector, eyeBaseVector;
    
	// Update is called once per frame
	void Update ()
    {
        projectedForward = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;

        if (startTimer < 0)
        {
            //Set resting angle manually
            if (Input.GetKey(KeyCode.R))
            {
                centerVision();
            }
            restObject.position = Vector3.ProjectOnPlane(restObject.position, Vector3.up);
            camRigTransform.position += transform.forward * camSpeed * .2f;

            if (Input.GetKey(KeyCode.W))
            {
                camRigTransform.transform.position += transform.forward * camSpeed * .15f;
            }

            //Control screen turning and blinder fade
            ObjectiveFlyInitializer managerScript = GameObject.Find("Manager").GetComponent<ObjectiveFlyInitializer>();
            switch (managerScript.controlScheme)
            {
                case 0:
                    leftDist = (Vector3.ProjectOnPlane(transform.position + projectedForward, Vector3.up) - leftObject.position).magnitude;
                    rightDist = (Vector3.ProjectOnPlane(transform.position + projectedForward, Vector3.up) - rightObject.position).magnitude;
                    if (leftDist > 1.6f)
                        camRigTransform.RotateAround(transform.position, Vector3.up, -(leftDist - 1.6f) * 2);
                    else if (rightDist > 1.6f)
                        camRigTransform.RotateAround(transform.position, Vector3.up, (rightDist - 1.6f) * 2);
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.A))
                        camRigTransform.RotateAround(transform.position, Vector3.up, -shiftAmount);
                    if (Input.GetKeyDown(KeyCode.D))
                        camRigTransform.RotateAround(transform.position, Vector3.up, shiftAmount);
                    break;
                case 2:
                    leftDist = (Vector3.ProjectOnPlane(transform.position + projectedForward, Vector3.up) - leftObject.position).magnitude;
                    rightDist = (Vector3.ProjectOnPlane(transform.position + projectedForward, Vector3.up) - rightObject.position).magnitude;
                    if (leftDist > 1.6f)
                        camRigTransform.RotateAround(transform.position, Vector3.up, -(leftDist - 1.6f) * 2);
                    else if (rightDist > 1.6f)
                        camRigTransform.RotateAround(transform.position, Vector3.up, (rightDist - 1.6f) * 2);
                    if (Input.GetKeyDown(KeyCode.A))
                        camRigTransform.RotateAround(transform.position, Vector3.up, -shiftAmount);
                    if (Input.GetKeyDown(KeyCode.D))
                        camRigTransform.RotateAround(transform.position, Vector3.up, shiftAmount);
                    break;
            }
        }
        else if (startTimer >= 0) {
            countDown.text = "Look straight ahead \n" + startTimer / 90;
            centerVision();
            if (startTimer == 0)
                countDown.text = "";
            startTimer--;
        }
    }

    void centerVision()
    {
        restObject.position = Vector3.ProjectOnPlane(transform.position + projectedForward, Vector3.up);
        restObject.rotation = Quaternion.LookRotation(projectedForward);
    }
}
