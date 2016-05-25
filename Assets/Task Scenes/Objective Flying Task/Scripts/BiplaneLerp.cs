using UnityEngine;
using System.Collections;

public class BiplaneLerp : MonoBehaviour
{
    private Transform headTransform, planeTransform;
    private Transform leadTransform;
    [Range(0f, .5f)]
    public float lerpSpeed;
    public bool canShoot;

    private float shootTime;
    private AudioSource audSource;

    //Allows manager to set transform to follow;
    public void Initialize(string sLead, string aClip, Transform hTransform)
    {
        headTransform = hTransform;
        leadTransform = GameObject.Find(sLead).transform;
        audSource = gameObject.GetComponent<AudioSource>();
        audSource.clip = Resources.Load("SharedSounds/" + aClip) as AudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        try {
            if (planeTransform == null)
                planeTransform = GameObject.Find("BIPLANE Remake").transform;
        } catch (System.NullReferenceException e)
        {
            Debug.Log("Not active yet");
        }
        transform.position = Vector3.Lerp(transform.position, leadTransform.position, lerpSpeed);
        Vector3 vec = leadTransform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(vec);
        transform.rotation = Quaternion.Lerp(leadTransform.rotation, lookRot, lerpSpeed);

        //Instantiates bullets upon player input
        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Space) && shootTime < 0)
            {
                audSource.Stop();
                audSource.Play();
                shootTime = 15;
                Quaternion shootRotation = Quaternion.LookRotation(planeTransform.forward, planeTransform.up);

                //Instantiate Left Bullet
                GameObject go = Instantiate(Resources.Load("FlyObjectives/bulletPrefab") as GameObject); ;
                go.transform.position = transform.position + transform.forward + transform.up * -.3f + transform.right * -.4f;
                go.transform.rotation = Quaternion.FromToRotation(Vector3.zero, headTransform.forward + headTransform.right);
                go.transform.Rotate(headTransform.right, 90);
                go.GetComponent<bulletScript>().trajectory = headTransform.forward * .5f;
                go.GetComponent<bulletScript>().colScript = gameObject.GetComponent<ColliderScript>();
                //Instantiate Right Bullet
                go = Instantiate(Resources.Load("FlyObjectives/bulletPrefab") as GameObject); ;
                go.transform.position = transform.position + transform.forward + transform.up * -.3f + transform.right * .4f;
                go.transform.eulerAngles = planeTransform.forward + planeTransform.right + planeTransform.up;
                go.transform.Rotate(planeTransform.right, -90);
                go.GetComponent<bulletScript>().colScript = gameObject.GetComponent<ColliderScript>();
                go.GetComponent<bulletScript>().trajectory = headTransform.forward * .5f;
            }
            shootTime--;
        }
    }
}
