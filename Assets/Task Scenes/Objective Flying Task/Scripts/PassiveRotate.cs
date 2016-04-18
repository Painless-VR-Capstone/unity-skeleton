using UnityEngine;
using System.Collections;

public class PassiveRotate : MonoBehaviour {
    private Vector3 rotSpeed;
    public float rotationSpeed;

	// Use this for initialization
	void Start () {
        rotSpeed = new Vector3(Random.Range(-rotationSpeed, rotationSpeed), Random.Range(-rotationSpeed, rotationSpeed));
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotSpeed);
	}
}
