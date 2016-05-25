using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject winText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player")
        {
            Debug.Log("VICTORY!");
            GameObject text = Instantiate(winText);
            text.transform.SetParent(GameObject.Find("UI").transform, false);
            StartCoroutine(PlayerController.gameManager.Wait());

        }
    }
}
