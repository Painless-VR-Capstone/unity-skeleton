using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public float speed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 1, 0), speed);
    }
}
