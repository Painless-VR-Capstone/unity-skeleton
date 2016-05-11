/*
Dictates how player's hitbox handles various collisions.
*/
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
using UnityEngine.UI;
using System.Collections;

public class ColliderScript : MonoBehaviour
{
    public GameObject playerCamera;
    public Text scoreText, timeText;
    private int score = 0;
    private float time = 100;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = (int)time + "s";
        if (time < 0)
        {
            SceneManager.LoadScene("Flying Objective Scene");
        }

    }
=======
using System.Collections;

public class ColliderScript : MonoBehaviour {
    public GameObject playerCamera;
	
	// Update is called once per frame
	void Update () {
	    
	}
>>>>>>> 0a6a02c7630a6a10656409243cf8ba4d103576eb

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Hazard"))
        {
            SceneManager.LoadScene("Flying Objective Scene");
        }
        if (col.gameObject.name.Contains("Objective"))
        {
<<<<<<< HEAD
            Destroy(col.gameObject);
            GameObject go = Instantiate(Resources.Load("FlyObjectives/particleEmit") as GameObject); ;
            go.transform.position = col.transform.position;
            go.transform.rotation = transform.rotation;
            updateScore(50);
            transform.position += transform.forward * -.33f;
        }
    }

    public void updateScore(int updateBy)
    {
        score += updateBy;
        scoreText.text = "" + score;
    }
=======
            GameObject go = Instantiate(Resources.Load("FlyObjectives/particleEmit") as GameObject); ;
            go.transform.position = col.transform.position;
            go.transform.rotation = transform.rotation;
            Destroy(col.gameObject);
            transform.position += transform.forward * -1;
        }
    }
>>>>>>> 0a6a02c7630a6a10656409243cf8ba4d103576eb
}
