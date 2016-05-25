using UnityEngine;
using System.Collections;

public class ObjectiveFlyInitializer : SceneInitializer {
    ObjectiveFlyPresetModel presetModel;
    public BiplaneLerp sphereScript;
    public Camera cameraMouse, cameraVR;
    public GameObject VRObject, sphereObject;
    public ColliderScript gameMechanics;
    public int tempVRMode, controlScheme;
    public Color hazardColor, playerColor, objectiveColor, uiColor;

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

        switch (tempVRMode)//((int)presetModel.vrMode)
        {
            case 0:
                cameraMouse.gameObject.SetActive(true);
                cameraMouse.enabled = true;
                sphereScript.Initialize("SphereLead2", "bassy laser", cameraMouse.transform);
                Debug.Log("Mouse Moude");
                break;
            case 1:
                VRObject.SetActive(true);
                sphereScript.Initialize("SphereLead", "bassy laser", cameraVR.transform);
                //cameraVR.enabled = true;
                break;
        }
        

        hazardColor = Color.blue;
        playerColor = Color.magenta;
        objectiveColor = Color.green;
        uiColor = Color.white;
        sphereObject.SetActive(true);
        gameMechanics.Initialize(32);
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.G)) RenderSettings.fogDensity = .01f;
        if (Input.GetKeyDown(KeyCode.G)) RenderSettings.fogDensity = .03f;
    }
}
