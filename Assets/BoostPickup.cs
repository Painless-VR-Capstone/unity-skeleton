using UnityEngine;
using System.Collections;

public class BoostPickup : MonoBehaviour {

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
            Debug.Log("Boost pickup");
            Instantiate(Resources.Load("Platformer/SlowPickupParticle") as GameObject, this.transform.position, Quaternion.identity);
            GameManager.BoostPlayer();
            //GameObject newParticles = Instantiate(particles, collider.transform.position, collider.transform.rotation) as GameObject;
            //newParticles.GetComponent<ParticleSystem>().Play();
            PlatformFall.fallingGOs.Remove(this.gameObject);
            Destroy(this.gameObject);
            //Destroy(newParticles);
        }
    }
}
