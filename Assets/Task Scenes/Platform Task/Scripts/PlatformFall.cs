using UnityEngine;
using System.Collections.Generic;

public class PlatformFall : MonoBehaviour {
    List<GameObject> fallingGOs = new List<GameObject>();
    public float fallSpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        int index = 0;
        foreach (GameObject fallingGO in fallingGOs)
        {
            if (fallingGO != null)
            {
                fallingGO.transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);
            }
            else
            {
                fallingGOs.Remove(fallingGO);
            }
            
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Platform" || collider.transform.tag.Contains("Pickup"))
        {

            //Rigidbody rBody = collider.gameObject.GetComponent<Rigidbody>();
            ////rBody.freezeRotation = false;
            //rBody.constraints = RigidbodyConstraints.None;
            //rBody.useGravity = true;

            fallingGOs.Add(collider.gameObject);


        } 
    }
        
}
