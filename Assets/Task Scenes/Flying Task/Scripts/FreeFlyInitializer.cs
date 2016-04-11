using UnityEngine;
using System.Collections;
using System;
using PainlessVR;
using System.Windows.Forms;
using System.IO;

public class FreeFlyInitializer : MonoBehaviour, ISceneInitializer {

    public Color worldColor = Color.gray;

    // Use this for initialization
    void Start()
    {
        FreeFlyPresetModel presetModel = new FreeFlyPresetModel();
        presetModel.color = Color.cyan;
        presetModel.musicPath = "desktop/5thconcerto.mp3";
        presetModel.enemyCount = 3;
        
        
        string json = JsonUtility.ToJson(presetModel);

        FreeFlyPresetModel newPresetModel = JsonUtility.FromJson<FreeFlyPresetModel>(json);

        Debug.Log(json);
        
        DeserializeVariables();
        SetVisuals();
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    public void DeserializeVariables()
    {
        try
        {
            string rawColor = PresetData.variables["color"];
            worldColor = PresetData.ParseColor(rawColor);
        } catch (Exception e)
        {
            MessageBox.Show("One or more provided variables are invalid for this task. Exception: " + e.Message + "\r\n Reverting to default values");
        }
    }


    public void SetAudio()
    {
        throw new NotImplementedException();
    }

    public void SetMechanics()
    {
        throw new NotImplementedException();
    }

    public void SetVisuals()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].gameObject.GetComponent<Renderer>().material.color = worldColor;
        }
    }

}
