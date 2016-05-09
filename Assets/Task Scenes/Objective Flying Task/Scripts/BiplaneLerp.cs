using UnityEngine;
using System.Collections;

public class BiplaneLerp : MonoBehaviour
{
    public Transform leadTransform, headTransform, planeTransform;
    [Range(0f, .5f)]
    public float lerpSpeed;
    private float shootTime;
    private AudioSource audSource;

    void Start()
    {
        audSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, leadTransform.position, lerpSpeed);
        Vector3 vec = leadTransform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(vec);
        transform.rotation = Quaternion.Lerp(leadTransform.rotation, lookRot, lerpSpeed);

        if (Input.GetKey(KeyCode.B) && shootTime < 0)
        {
            audSource.Play();
            shootTime = 15;
            Quaternion shootRotation = Quaternion.LookRotation(planeTransform.forward, planeTransform.up);
            GameObject go = Instantiate(Resources.Load("FlyObjectives/bulletPrefab") as GameObject); ;
            go.transform.position = transform.position + transform.forward + transform.up * -.3f + transform.right * -.4f;
            go.transform.rotation = Quaternion.FromToRotation(Vector3.zero, headTransform.forward + headTransform.right);
            go.transform.Rotate(headTransform.right, 90);
            go.GetComponent<bulletScript>().trajectory = headTransform.forward * .5f;
            go.GetComponent<bulletScript>().colScript = gameObject.GetComponent<ColliderScript>();
            go = Instantiate(Resources.Load("FlyObjectives/bulletPrefab") as GameObject); ;
            go.transform.position = transform.position + transform.forward + transform.up * -.3f + transform.right * .4f;
            go.transform.eulerAngles = planeTransform.forward + planeTransform.right + planeTransform.up;
            go.transform.Rotate(planeTransform.right, -90);
            go.GetComponent<bulletScript>().colScript = gameObject.GetComponent<ColliderScript>();
            go.GetComponent<bulletScript>().trajectory = headTransform.forward * .5f;
        }
        shootTime--;
        /*float f = Quaternion.Angle(Quaternion.LookRotation(leadTransform.position - headTransform.position), Quaternion.LookRotation(leadTransform.position - transform.position));
        if ((transform.position + transform.right * .1f - leadTransform.position).magnitude < (transform.position + transform.right * .1f - leadTransform.position).magnitude)
            transform.Rotate(transform.forward, f);
        else
            transform.Rotate(-transform.forward, f);*/
    }
}
