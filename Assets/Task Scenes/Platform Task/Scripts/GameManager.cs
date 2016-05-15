using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    internal static GameObject player;
    internal static PlayerController playCtrl;
    internal static PlatformMovement platMovement;

    public static bool playerIsAlive = false;
    float timeAlive; 
    public static string playerObject;
    public GameObject humanPlayer, orbPlayer, robotPlayer;
    public static PlatformPresetModel presetModel;
    TrailRenderer trail;

    public AudioSource audioSource;
    public List<AudioClip> audioClips = new List<AudioClip>();

    public float boostPower = .07f;
    public float slowPower = 5f;

    public List<float> boostTimes = new List<float>();
    public List<float> slowTimes = new List<float>();
    internal static float startJumpTime;
    internal static float startPlatSpeed;

    void OnEnable()
    {
        if (player == null)
            Init();
    }

    // Use this for initialization
    void Start () {


    }

    internal void Init()
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
        timeAlive = 0f;
        playerIsAlive = true;
        gm.trail = player.GetComponent<TrailRenderer>();
        playCtrl = player.GetComponent<PlayerController>();
        platMovement = GameObject.Find("MovingObjects").GetComponent<PlatformMovement>();
        startJumpTime = playCtrl.jumpTime;
        startPlatSpeed = platMovement.speed;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Submit"))
            RestartGame();

        if (player != null)
        {
            for (int i = 0; i < boostTimes.Count; i++)
            {
                if (boostTimes[i] + 3f < Time.time)
                    boostTimes.RemoveAt(i);
            }
            for (int i = 0; i < slowTimes.Count; i++)
            {
                if (slowTimes[i] + 3.5f < Time.time)
                    slowTimes.RemoveAt(i);
            }



            platMovement.speed = Mathf.Clamp(startPlatSpeed - (float)System.Math.Pow(slowTimes.Count, 2) * slowPower, 0, startPlatSpeed);
            float boost = (float)System.Math.Pow(boostTimes.Count, 2) * boostPower;
            trail.time = boostTimes.Count * .15f;
            trail.startWidth = boostTimes.Count * .3f;
            playCtrl.jumpTime = Mathf.Clamp(startJumpTime - boost, .1f, startJumpTime);
        }

	}

    public void DestroyPlayer()
    {
        
        playerIsAlive = false;
        Destroy(player);
        StartCoroutine(Wait());
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        RestartGame();
        Debug.Log("ROUTINE OVER");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Init();
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

    public void PlaySound(int clipIndex)
    {
        audioSource.PlayOneShot(audioClips[clipIndex]);

    }



}
