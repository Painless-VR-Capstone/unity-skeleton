using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    internal static GameObject player;
    internal static PlayerController playCtrl;
    internal static PlatformMovement platMovement;
    internal static PlatformFall fallPoint;
    internal static PlatformEmitter platEmitter;
    int platMat;
    int borderMat;
    int groundMat;
    int towerMat;

    public static bool playerIsAlive = false;
    float timeAlive; 
    public static string playerObject;
    public GameObject humanPlayer, orbPlayer, robotPlayer;
    public static PlatformPresetModel presetModel;
    TrailRenderer trail;

    public AudioSource audioSource;
    public List<AudioClip> audioClips = new List<AudioClip>();
    public List<Material> mats;

    public float boostPower = .07f;
    public float slowPower = 5f;

    public List<float> boostTimes = new List<float>();
    public List<float> slowTimes = new List<float>();
    internal static float startJumpTime;
    internal static float startPlatSpeed;
    internal static float startFallSpeed;
    internal static float startDecJumpSpeed;


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
        platMovement = GameObject.Find("MovingObjects").GetComponent<PlatformMovement>();
        platEmitter = GameObject.Find("PlatformEmitter").GetComponent<PlatformEmitter>();
        fallPoint = GameObject.Find("FallPoint").GetComponent<PlatformFall>();

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
            platEmitter.columnCount = presetModel.platStreamWidth;
            platEmitter.multiplePaths = presetModel.multiplePaths;
            platMovement.speed = presetModel.platSpeed;
            if (presetModel.textures == 0)
            {
                borderMat = 3; groundMat = 11; towerMat = 1; platMat = 8;
            } else if (presetModel.textures == 1)
            {
                borderMat = 4; groundMat = 6; towerMat = 9; platMat = 3;
            } else
            {
                borderMat = 2; groundMat = 7; towerMat = 8; platMat = 0;
            }
            SetMaterials();
            gm.SetPlayerObject();
            gm.SpawnPlayer();

        }
        timeAlive = 0f;
        playerIsAlive = true;
        gm.trail = player.GetComponent<TrailRenderer>();
        playCtrl = player.GetComponent<PlayerController>();
        startJumpTime = playCtrl.jumpTime;
        startPlatSpeed = platMovement.speed;
        startFallSpeed = fallPoint.fallSpeed;
        startDecJumpSpeed = playCtrl.decreaseJumpBySpeed;
        playCtrl.decreaseJumpBySpeed = 1 + (startPlatSpeed * .02f);
    }

    void SetMaterials()
    {
        GameObject[] borders = GameObject.FindGameObjectsWithTag("Border");
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        GameObject[] plats = GameObject.FindGameObjectsWithTag("Platform");


        foreach (GameObject gm in borders)
        {
            gm.GetComponent<Renderer>().material = mats[borderMat];
        }
        foreach (GameObject gm in grounds)
        {
            gm.GetComponent<Renderer>().material = mats[groundMat];

        }
        foreach (GameObject gm in towers)
        {
            gm.GetComponent<Renderer>().material = mats[towerMat];

        }
        foreach (GameObject gm in plats)
        {
            gm.GetComponent<Renderer>().material = mats[platMat];

        }


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

            float newPlatSpeed = Mathf.Clamp(startPlatSpeed - (float)System.Math.Pow(slowTimes.Count, 2) * slowPower, 0, startPlatSpeed);
            fallPoint.fallSpeed = (newPlatSpeed / startPlatSpeed) * startFallSpeed;
            platMovement.speed = newPlatSpeed;
            float boost = (float)System.Math.Pow(boostTimes.Count, 2) * boostPower;
            playCtrl.decreaseJumpBySpeed = (startDecJumpSpeed - boost * .25f);
            trail.time = boostTimes.Count * .15f;
            trail.startWidth = boostTimes.Count * .3f;
            playCtrl.jumpTime = Mathf.Clamp(startJumpTime - boost, .11f, startJumpTime);
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
        UIController.oldTime = Time.time;
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
                player = Instantiate(orbPlayer);
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

    public void PlaySound(int clipIndex, float vol, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(audioClips[clipIndex], position, vol);
    }

    public void PlaySound(int clipIndex, float vol)
    {
        audioSource.PlayOneShot(audioClips[clipIndex], vol);

    }

    public void PlaySound(int clipIndex)
    {
        audioSource.PlayOneShot(audioClips[clipIndex]);

    }



}
