using UnityEngine;
using System.Collections;

public class SlowPickup : MonoBehaviour {
    public GameObject particles;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Slow pickup");
            PlatformMovement.SlowDown();
            //GameObject newParticles = Instantiate(particles, collider.transform.position, collider.transform.rotation) as GameObject;
            //newParticles.GetComponent<ParticleSystem>().Play();
            Destroy(this.gameObject);
            //Destroy(newParticles);
        }
    }
}
