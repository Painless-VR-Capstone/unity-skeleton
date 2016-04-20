﻿/*
Dictates how player's hitbox handles various collisions.
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ColliderScript : MonoBehaviour {
    public GameObject playerCamera;
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Hazard"))
        {
            SceneManager.LoadScene("Flying Objective Scene");
        }
        if (col.gameObject.name.Contains("Objective"))
        {
            GameObject go = Instantiate(Resources.Load("FlyObjectives/particleEmit") as GameObject); ;
            go.transform.position = col.transform.position;
            go.transform.rotation = transform.rotation;
            Destroy(col.gameObject);
            transform.position += transform.forward * -1;
        }
    }
}