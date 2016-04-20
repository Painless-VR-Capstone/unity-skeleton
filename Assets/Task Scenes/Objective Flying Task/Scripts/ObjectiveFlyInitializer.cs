using UnityEngine;
using System.Collections;

public class ObjectiveFlyInitializer : SceneInitializer {

	// Use this for initialization
	void Start () {

        presetModel = DeserializeVariables<ObjectiveFlyPresetModel>();
        CameraColorShift.brightness = presetModel.brightness;
        CameraColorShift.contrast = presetModel.contrast;
        CameraColorShift.saturation = presetModel.saturation;
        CameraColorShift.hue = presetModel.hue;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
