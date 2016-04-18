using UnityEngine;
using System.Collections;

public class LerpToTransform : MonoBehaviour {
    public Transform leadTransform;
    [Range(0f, .5f)]
    public float lerpSpeed;

	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, leadTransform.position, lerpSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, leadTransform.rotation, lerpSpeed);
	}
}
