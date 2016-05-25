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
            PlayerController.gameManager.PlaySound(3, 1, collider.transform.position);

            GameObject newParticle = (GameObject)Instantiate(Resources.Load("Platformer/SlowPickupParticle") as GameObject, this.transform.position, Quaternion.identity);
            Destroy(newParticle, 3);

            PlayerController.gameManager.boostTimes.Add(Time.time);

            PlatformFall.fallingGOs.Remove(this.gameObject);
            Destroy(this.gameObject);
            //Destroy(newParticles);
        }
    }
}
