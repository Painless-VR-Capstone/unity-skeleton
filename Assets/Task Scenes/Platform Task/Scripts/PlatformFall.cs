using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Platform")
        {
            Rigidbody rBody = collider.gameObject.GetComponent<Rigidbody>();
            //rBody.freezeRotation = false;
            rBody.constraints = RigidbodyConstraints.None;
            rBody.useGravity = true;
        }
    }
        
}
