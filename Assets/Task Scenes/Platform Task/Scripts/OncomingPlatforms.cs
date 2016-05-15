using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class OncomingPlatforms : MonoBehaviour {
    public static GameObject[] sortedPlats = new GameObject[3];
    static List<GameObject> unsortedPlats = new List<GameObject>();
    public static GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        unsortedPlats.Clear();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Platform")
        {

            //Debug.Log("Platform detected " + position.z);
            //for (int i = 0; i < platforms.Length; i++)
            //{
            //    if (platforms[i] != null && position.x - platforms[i].transform.position.x > Math.Abs(4f))
            //    {

            //    }
            //}
            
            unsortedPlats.Add(collider.gameObject);
               
        }
    }

    public static void SortPlats()
    {
        foreach (GameObject plat in unsortedPlats)
        {
            Debug.Log("Sortin' plat");
            float platZ = plat.transform.position.z;

            if (platZ < player.transform.position.z + 3 && platZ > player.transform.position.z - 3)

            {
                //Debug.Log("Front platform added");
                sortedPlats[1] = plat;
            }
            else if (platZ < player.transform.position.z - 3)
            {
                //Debug.Log("Right platform added");
                sortedPlats[2] = plat;
            }
            else
            {
                //Debug.Log("Left platform added");
                sortedPlats[0] = plat;
            }
        }

    }

    public static void ClearNext()
    {
        Debug.Log("Platforms cleared");
        Array.Clear(sortedPlats, 0, 3);
        unsortedPlats.Clear();
    }

}
