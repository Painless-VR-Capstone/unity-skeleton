using UnityEngine;
using System.Collections;

public class FollowX : MonoBehaviour {
    private Transform t;
	
    void Start()
    {
        t = GameObject.FindGameObjectWithTag("Player").transform;
    }
    

	// Update is called once per frame
	void Update () {
        if (t != null)
            transform.position = Vector3.Lerp(transform.position - Vector3.right * 3, new Vector3(t.position.x, transform.position.y, transform.position.z) - Vector3.right * 3, .1f);
	}
}
