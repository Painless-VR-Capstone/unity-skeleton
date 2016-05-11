using UnityEngine;
using System.Collections;

public class LerpToTransform : MonoBehaviour {
    public Transform leadTransform;
    [Range(0f, 1f)]
    public float lerpSpeed;
    public float rotationAmount = 0;

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.Lerp(transform.position, leadTransform.position, lerpSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, leadTransform.rotation, lerpSpeed);
        transform.Rotate(new Vector3(0, rotationAmount, 0));
	}
}
