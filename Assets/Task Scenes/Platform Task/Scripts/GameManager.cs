using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    internal static GameObject player;
    public static bool playerIsAlive = true;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerIsAlive = true;
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit"))
            RestartGame();
	}

    public static void DestroyPlayer()
    {
        playerIsAlive = false;
        Destroy(player);

    }

    public static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
