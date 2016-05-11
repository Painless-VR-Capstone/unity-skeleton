using UnityEngine;
using System.Collections;

public class TargetSpawnScript : MonoBehaviour {
    private GameObject myTarget;
    private int respawnTime;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (myTarget == null)
        {
            respawnTime--;
            if (respawnTime <= 0)
                createNewTarget();
        }
	}

    void createNewTarget()
    {
        myTarget = Instantiate(Resources.Load("FlyObjectives/EnemyTarget") as GameObject); ;
        myTarget.transform.position = transform.position;
        myTarget.transform.rotation = transform.rotation;
        respawnTime = 1000;
    }
}
