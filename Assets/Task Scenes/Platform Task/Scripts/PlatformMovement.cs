﻿using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {
    public float speed;
    public float slowDownDuration;
    public static float timeStamp;
    public float slowDownIntensity;

	// Use this for initialization
	void Start () {
	
	}
	

    public static void SlowDown()
    {
        timeStamp = Time.time;
    }

    void FixedUpdate ()
    {
        if (timeStamp != 0 && timeStamp + slowDownDuration > Time.time)
        {
            transform.Translate(Vector3.left * Time.deltaTime * (speed - slowDownIntensity));
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
    }
}
