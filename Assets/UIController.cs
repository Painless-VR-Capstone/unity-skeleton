using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text distToGoalText;
    public Text minDistToGoalText;

    public GameObject player;
    public GameObject goal;

	// Use this for initialization
	void Start () {
        int dist = (int)Vector3.Distance(player.transform.position, goal.transform.position);
        minDistToGoalText.text = "(Best: " + Stats.minDistToGoal + ")";

        //if (Stats.minDistToGoal > dist)
        //{
        //    Stats.minDistToGoal = dist;
        //}

    }

    // Update is called once per frame
    void Update () {
        int dist = (int)Vector3.Distance(player.transform.position, goal.transform.position);

        distToGoalText.text = dist + "m to FINISH";

        if (Stats.minDistToGoal > dist)
        {
            minDistToGoalText.text = "(Best: " + dist + ")";
            Stats.minDistToGoal = dist;
        }
	}
}


