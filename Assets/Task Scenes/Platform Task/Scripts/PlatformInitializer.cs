using UnityEngine;
using System.Collections;

public class PlatformInitializer : SceneInitializer {
    public GameObject humanPlayer, orbPlayer, robotPlayer;
   


    void Awake()
    {
        if (SceneLoader.json != null)
        {
            presetModel = DeserializeVariables<PlatformPresetModel>();
            CameraColorShift.brightness = presetModel.brightness;
            CameraColorShift.contrast = presetModel.contrast;
            CameraColorShift.saturation = presetModel.saturation;
            CameraColorShift.hue = presetModel.hue;
            SetPlayerObject();
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
        Debug.Log(presetModel.playerObject.ToString());
        Transform parent = GameObject.Find("MovingObjects").transform;
        switch (presetModel.playerObject.ToString())
        {
            case "Human":
                Instantiate(humanPlayer).transform.SetParent(parent, false);
                break;
            case "Orb":
                Instantiate(orbPlayer).transform.SetParent(parent, false);
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
