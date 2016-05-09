using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
    private int bulletLife = 270;
    public Vector3 trajectory;
    public ColliderScript colScript;

	// Update is called once per frame
	void Update () {
        bulletLife--;
        if (bulletLife < 0)
            Destroy(gameObject);
        transform.position += trajectory;
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Contains("Hazard"))
            Destroy(gameObject);
        if (col.gameObject.name.Contains("Enemy"))
        {
            Destroy(col.gameObject);
            colScript.updateScore(25);
            GameObject go = Instantiate(Resources.Load("FlyObjectives/TargetDestroyed") as GameObject); ;
            go.transform.position = col.transform.position;
            go.transform.rotation = transform.rotation;
            Destroy(gameObject);
        }
    }
}
