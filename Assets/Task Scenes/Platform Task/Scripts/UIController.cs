using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text distToGoalText;
    public Text minDistToGoalText;
    private Color textStartColor;
    private float colorFlashTime;

    public GameObject player;
    public GameObject goal;

	// Use this for initialization
	void Start () {
        Debug.Log("UIController START");
        int dist = (int)Vector3.Distance(GameManager.player.transform.position, goal.transform.position);
        minDistToGoalText.text = Stats.minDistToGoal + "m";
        minDistToGoalText.color = Color.magenta;
        textStartColor = distToGoalText.color;

        //if (Stats.minDistToGoal > dist)
        //{
        //    Stats.minDistToGoal = dist;
        //}

    }

    // Update is called once per frame
    void Update () {
        if (GameManager.playerIsAlive)
        {
            int dist = (int)Vector3.Distance(GameManager.player.transform.position, goal.transform.position);

            distToGoalText.text = dist + "m";

            if (Stats.minDistToGoal > dist)
            {
                colorFlashTime = Time.time;
                distToGoalText.color = Color.magenta;
                minDistToGoalText.text = dist + "m";
                Stats.minDistToGoal = dist;
            }
            else if (colorFlashTime + .1f < Time.time)
            {

                distToGoalText.color = textStartColor;
            }
        }
	}
}


