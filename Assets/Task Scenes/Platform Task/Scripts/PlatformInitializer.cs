using UnityEngine;
using System.Collections;

public class PlatformInitializer : SceneInitializer {


	// Use this for initialization
	void Start () {
        if (SceneLoader.json != null)
        {
            presetModel = DeserializeVariables<PlatformPresetModel>();
            CameraColorShift.brightness = presetModel.brightness;
            CameraColorShift.contrast = presetModel.contrast;
            CameraColorShift.saturation = presetModel.saturation;
            CameraColorShift.hue = presetModel.hue;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
