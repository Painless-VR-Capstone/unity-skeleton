using UnityEngine;
using System.Collections;

public class MoveFreeFly : MonoBehaviour {
    float xRotation = 0, yRotation = 0, rotationSpeed = 200;
    public float passiveSpeed, activeSpeed;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.forward * activeSpeed;
        } else
        {
            transform.position += transform.forward * passiveSpeed;
        }
    }

    void LateUpdate()
    {
        yRotation -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -80, 80);
        xRotation += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        xRotation = xRotation % 360;
        transform.localEulerAngles = new Vector3(yRotation, xRotation, 0);
    }
}
