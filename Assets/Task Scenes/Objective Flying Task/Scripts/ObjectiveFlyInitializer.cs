using UnityEngine;
using System.Collections;

public class ObjectiveFlyInitializer : SceneInitializer {
<<<<<<< HEAD
    ObjectiveFlyPresetModel presetModel;

    void Awake()
    {
=======

	// Use this for initialization
	void Start () {
>>>>>>> 0a6a02c7630a6a10656409243cf8ba4d103576eb
        if (SceneLoader.json != null)
        {
            presetModel = DeserializeVariables<ObjectiveFlyPresetModel>();
            CameraColorShift.brightness = presetModel.brightness;
            CameraColorShift.contrast = presetModel.contrast;
            CameraColorShift.saturation = presetModel.saturation;
            CameraColorShift.hue = presetModel.hue;
<<<<<<< HEAD


=======
>>>>>>> 0a6a02c7630a6a10656409243cf8ba4d103576eb
        }
        else
        {
            Debug.Log("No JSON to initialize");
        }
    }
<<<<<<< HEAD

	// Use this for initialization
	void Start () {

    }
=======
>>>>>>> 0a6a02c7630a6a10656409243cf8ba4d103576eb
	
	// Update is called once per frame
	void Update () {
	
	}
}
