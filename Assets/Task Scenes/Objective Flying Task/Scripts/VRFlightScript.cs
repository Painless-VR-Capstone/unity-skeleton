using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VRFlightScript : MonoBehaviour {
    public Transform camRigTransform, sphereLeaderTransform, restObject, leftObject, rightObject;
    public Text countDown;
    public float camSpeed;
    public Renderer perifereeMaterial1, perifereeMaterial2;

    private float leftDist, rightDist;
    private int startTimer = 300;
    private Vector3 rotationAxis, projectedForward;
    private Vector2 eyeVector, eyeBaseVector;

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        projectedForward = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;

        if (startTimer < 0)
        {
            countDown.text = "";
            //Set resting angle manually
            if (Input.GetKey(KeyCode.S))
            {
                centerVision();
            }
            restObject.position = Vector3.ProjectOnPlane(restObject.position, Vector3.up);
            camRigTransform.position += transform.forward * camSpeed * .2f;
            leftDist = (Vector3.ProjectOnPlane(transform.position + projectedForward, Vector3.up) - leftObject.position).magnitude;
            rightDist = (Vector3.ProjectOnPlane(transform.position + projectedForward, Vector3.up) - rightObject.position).magnitude;

            if (Input.GetKey(KeyCode.Space))
            {
                camRigTransform.transform.position += transform.forward * camSpeed * .15f;
            }


            if (leftDist > 1.6f)
            {
                camRigTransform.RotateAround(transform.position, Vector3.up, -(leftDist - 1.6f) * 2);
                perifereeMaterial2.material.SetFloat("_Cutoff", Mathf.Lerp(.425f, .38f, (leftDist - 1.62f) * 2));
                perifereeMaterial1.material.SetFloat("_Cutoff", Mathf.Lerp(.425f, .38f, (leftDist - 1.62f) * 2));
            } else if (rightDist > 1.6f)
            {
                camRigTransform.RotateAround(transform.position, Vector3.up, (rightDist - 1.6f) * 2);
                perifereeMaterial2.material.SetFloat("_Cutoff", Mathf.Lerp(.425f, .38f, (rightDist - 1.62f) * 2));
                perifereeMaterial1.material.SetFloat("_Cutoff", Mathf.Lerp(.425f, .38f, (rightDist - 1.62f) * 2));
            } else
            {
                perifereeMaterial1.material.SetFloat("_Cutoff", 1);
                perifereeMaterial2.material.SetFloat("_Cutoff", 1);
            }
        }
        else if (startTimer >= 0) {
            countDown.text = "Look straight ahead \n" + startTimer / 90;
            centerVision();
            startTimer--;
        }
    }

    void centerVision()
    {
        restObject.position = Vector3.ProjectOnPlane(transform.position + projectedForward, Vector3.up);
        restObject.rotation = Quaternion.LookRotation(projectedForward);
    }
}
