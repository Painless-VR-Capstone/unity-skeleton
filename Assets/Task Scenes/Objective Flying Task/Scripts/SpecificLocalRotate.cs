using UnityEngine;
using System.Collections;

public class SpecificLocalRotate : MonoBehaviour {
    public Vector3 specificRot;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(specificRot);
	}
}
