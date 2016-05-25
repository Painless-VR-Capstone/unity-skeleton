 using UnityEngine;
using System.Collections;

public class MoveFreeFly : MonoBehaviour {
    float xRotation = 0, yRotation = 0, xTarget = 0, yTarget = 0, rotationSpeed = 200;
    public float flySpeed;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * flySpeed;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * flySpeed;
        }
    }

    void LateUpdate()
    {
        yTarget -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        yTarget = Mathf.Clamp(yTarget, -80, 80);
        yRotation = Mathf.Lerp(yRotation, yTarget, .15f);
        xTarget += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        xTarget = xTarget % 360;
        xRotation = Mathf.Lerp(xRotation, xTarget, .15f);
        transform.localEulerAngles = new Vector3(yRotation, xRotation, 0);
    }
}
