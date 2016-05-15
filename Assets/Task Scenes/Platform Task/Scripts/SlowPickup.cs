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
            PlayerController.gameManager.PlaySound(1);
            GameObject newParticle = (GameObject)Instantiate(Resources.Load("Platformer/SlowPickupParticle") as GameObject, this.transform.position, Quaternion.identity);
            Destroy(newParticle, 3);
            PlayerController.gameManager.slowTimes.Add(Time.time);
            PlatformFall.fallingGOs.Remove(this.gameObject);
            Destroy(this.gameObject);
            //Destroy(newParticles);
        }
    }
}
