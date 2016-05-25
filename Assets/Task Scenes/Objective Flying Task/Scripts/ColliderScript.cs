/*
Dictates how player's hitbox handles various collisions.
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ColliderScript : MonoBehaviour
{
    public Text scoreText, timeText;
    private int score = 0;
    private float time = 100;

    //Method for manager to call on start
    public void Initialize(float nTime)
    {
        time = nTime;
    }

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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Hazard"))
        {
            SceneManager.LoadScene("Flying Objective Scene");
        }
        if (col.gameObject.name.Contains("Objective"))
        {
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
}
