using UnityEngine;
using System.Collections;

public class ObjectiveFlyInitializer : SceneInitializer {
    ObjectiveFlyPresetModel presetModel;

    void Awake()
    {
        if (SceneLoader.json != null)
        {
            presetModel = DeserializeVariables<ObjectiveFlyPresetModel>();
            CameraColorShift.brightness = presetModel.brightness;
            CameraColorShift.contrast = presetModel.contrast;
            CameraColorShift.saturation = presetModel.saturation;
            CameraColorShift.hue = presetModel.hue;


        }
        else
        {
            Debug.Log("No JSON to initialize");
        }
    }

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
