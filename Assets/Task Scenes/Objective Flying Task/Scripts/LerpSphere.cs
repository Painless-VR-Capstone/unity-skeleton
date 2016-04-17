using UnityEngine;
using System.Collections;

public class LerpSphere : MonoBehaviour {
    public Transform leadTransform;

	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, leadTransform.position, .15f);
	}
}
