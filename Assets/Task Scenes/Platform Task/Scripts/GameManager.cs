using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    internal static GameObject player;
    internal static PlayerController playCtrl;
    public static bool playerIsAlive = false;
    public static string playerObject;
    public GameObject humanPlayer, orbPlayer, robotPlayer;
    public static PlatformPresetModel presetModel;
    void Awake()
    {
        //Init();
    }

    // Use this for initialization
    void Start () {
	}

    internal static void Init()
    {
        //GameObject.Find("Manager").GetComponent<GameManager>().SpawnPlayer();
        player = GameObject.FindGameObjectWithTag("Player");
        playerIsAlive = true;
        playCtrl = player.GetComponent<PlayerController>();
        startJumpTime = playCtrl.jumpTime;
    }

    internal static float startJumpTime;
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Submit"))
            RestartGame();

        for (int i = 0; i < boostTimes.Count; i++)
        {
            if (boostTimes[i] + 3f < Time.time)
            {
                boostTimes.RemoveAt(i);
                playCtrl.jumpTime += boostPower;
            }
        }

        if (boostTimes.Count == 0)
            playCtrl.jumpTime = startJumpTime;

        playCtrl.jumpTime = startJumpTime - Mathf.Clamp(boostTimes.Count * boostPower, .01f, 20f);

	}

    public void DestroyPlayer()
    {
        
        playerIsAlive = false;
        Destroy(player);
        StartCoroutine(Wait());
    }

    static IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        GameManager.RestartGame();
        Debug.Log("ROUTINE OVER");
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Init();
    }

    float minJumpTime = .2f;
    public float boostPower = .1f;
    static List<float> boostTimes = new List<float>();
    public static void BoostPlayer()
    {
        boostTimes.Add(Time.time);
    }

    public void SpawnPlayer()
    {
        Transform parent = GameObject.Find("MovingObjects").transform;
        switch (playerObject)
        {
            case "Human":
                Instantiate(humanPlayer).transform.SetParent(parent, false);
                break;
            case "Orb":
                Instantiate(orbPlayer).transform.SetParent(parent, false);
                break;
            default:
                Instantiate(humanPlayer).transform.SetParent(parent, false);
                break;
        }
    }
}
