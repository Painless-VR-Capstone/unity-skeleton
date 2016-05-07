using UnityEngine;
using System.Collections;

public class GroundCollision : MonoBehaviour {

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
            GameObject particle = Instantiate(Resources.Load("Platformer/LavaBurnParticle") as GameObject);
            particle.transform.localScale = new Vector3(.7f, .7f, .7f);
            particle.transform.position = collider.transform.position;
            //GameObject newParticles = Instantiate(particles, collider.transform.position, collider.transform.rotation) as GameObject;
            //newParticles.GetComponent<ParticleSystem>().Play();
            StartCoroutine(Wait());
            //Destroy(newParticles);
        } else if (collider.tag == "Platform")
        {
            GameObject particle = Instantiate(Resources.Load("Platformer/LavaBurnParticle") as GameObject);
            particle.transform.position = collider.transform.position;
            Destroy(collider.gameObject);
        }
    }

    IEnumerator Wait()
    {
        GameManager.DestroyPlayer();

        yield return new WaitForSeconds(2);
        GameManager.RestartGame();
        Debug.Log("ROUTINE OVER");
    }
}

