using UnityEngine;
using System.Collections;

public class GoalRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(.7f, 0, 0));
    }
}
