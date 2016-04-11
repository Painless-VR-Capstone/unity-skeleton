using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMGMT : MonoBehaviour {
    public Rigidbody rBody;

    public float autoSpeed = 1000;
    public float turnSpeed = 1000;

    // Use this for initialization
    void Start () {
        rBody = transform.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate()
    {
        float horz = CrossPlatformInputManager.GetAxis("Horizontal");
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        transform.Translate(new Vector3(0, 0, 1 * autoSpeed));

        transform.Rotate(new Vector3(vert * turnSpeed * Time.deltaTime, horz * turnSpeed * Time.deltaTime, 0));
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "StarPickup")
        {
            Destroy(c.gameObject);
            Debug.Log("Cat");
        }
    }
}
