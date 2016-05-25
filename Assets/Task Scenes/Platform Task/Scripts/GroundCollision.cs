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
        float f = new System.Random().Next(0, 1);
        if (f > .75)
            PlayerController.gameManager.PlaySound(13, 20, collider.transform.position);
        else
            PlayerController.gameManager.PlaySound(14, 20, collider.transform.position);


        if (collider.tag == "Player")
        {
            //PlayerController.gameManager.PlaySound(5);

            GameObject particle = Instantiate(Resources.Load("Platformer/LavaBurnParticle") as GameObject);
            particle.transform.localScale = new Vector3(.7f, .7f, .7f);
            particle.transform.position = collider.transform.position;
            Destroy(particle, 3);
            Destroy(collider.gameObject);
            PlayerController.gameManager.DestroyPlayer();
        } else if (collider.tag == "Platform")
        {
            if (collider.transform.childCount > 0)
            {
                collider.transform.GetChild(0).SetParent(this.transform.parent);
            }
            GameObject particle = Instantiate(Resources.Load("Platformer/LavaBurnParticle") as GameObject);
            particle.transform.position = collider.transform.position;
            Destroy(particle, 3);
            Destroy(collider.gameObject);
        }
    }

    //IEnumerator Wait()
    //{
    //    GameManager.DestroyPlayer();

    //    yield return new WaitForSeconds(2);
    //    GameManager.RestartGame();
    //    Debug.Log("ROUTINE OVER");
    //}
}

