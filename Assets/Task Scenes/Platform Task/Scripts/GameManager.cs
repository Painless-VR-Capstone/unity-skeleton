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

    public AudioSource audioSource;
    public AudioClip testClip;
    void OnEnable()
    {
        if (player == null)
            Init();
    }

    // Use this for initialization
    void Start () {


    }

    internal static void Init()
    {
        GameManager gm = GameObject.Find("Manager").GetComponent<GameManager>();
        if (presetModel == null)
        {
            gm.SpawnPlayer();
            //player = GameObject.FindGameObjectWithTag("Player");
        } else
        {
            CameraColorShift.brightness = presetModel.brightness;
            CameraColorShift.contrast = presetModel.contrast;
            CameraColorShift.saturation = presetModel.saturation;
            CameraColorShift.hue = presetModel.hue;
            gm.SetPlayerObject();
            gm.SpawnPlayer();
        }
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
            if (boostTimes[i] + 3.5f < Time.time)
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
                player = Instantiate(humanPlayer);
                player.transform.SetParent(parent, false);
                break;
            case "Orb":
                player = Instantiate(orbPlayer);
                player.transform.SetParent(parent, false);
                break;
            default:
                player = Instantiate(humanPlayer);
                player.transform.SetParent(parent, false);
                break;
        }
    }

    void SetPlayerObject()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
            Destroy(GameObject.FindGameObjectWithTag("Player"));

        GameManager.playerObject = presetModel.playerObject.ToString();
        //GameObject.Find("Manager").GetComponent<GameManager>().SpawnPlayer();
    }

    void PlayJumpSound()
    {
        if 
    }
}
