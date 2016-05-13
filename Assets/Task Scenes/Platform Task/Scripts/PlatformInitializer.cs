using UnityEngine;
using System.Collections;

public class PlatformInitializer : SceneInitializer {
    public GameObject humanPlayer, orbPlayer, robotPlayer;
    PlatformPresetModel presetModel;


    void Awake()
    {
        if (SceneLoader.json != null)
        {
            presetModel = DeserializeVariables<PlatformPresetModel>();
            GameManager.presetModel = presetModel;
            //CameraColorShift.brightness = presetModel.brightness;
            //CameraColorShift.contrast = presetModel.contrast;
            //CameraColorShift.saturation = presetModel.saturation;
            //CameraColorShift.hue = presetModel.hue;
            //SetPlayerObject();
            GameManager.Init();
            //PlayerController playCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            //playCtrl.jumpTime = presetModel.jumpSpeed;
            //GameManager.startJumpTime = presetModel.jumpSpeed;

        }
        else
        {
            Debug.Log("No JSON to initialize");
        }

    }

    // Use this for initialization
    void Start () {

	}

    void SetPlayerObject()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
            Destroy(GameObject.FindGameObjectWithTag("Player"));

        GameManager.playerObject = presetModel.playerObject.ToString();
        //GameObject.Find("Manager").GetComponent<GameManager>().SpawnPlayer();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
