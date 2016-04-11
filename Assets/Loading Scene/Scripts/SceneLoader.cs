using UnityEngine;
using UnityEngine.VR;
using System.Collections;
using PainlessVR;
using System.IO;
using System;
using System.Windows.Forms;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour {
    public const string defaultPresetFileName = "test.csv";
    public const string defaultPresentDirectory = "C:\\SpeedyDocs\\Unity3D Projects\\Painless VR\\";
    public string presetFilePath;

    // Use this for initialization
    void Start() {
        
        PresetData.variables = new Dictionary<string, string>();
        presetFilePath = Directory.GetCurrentDirectory() + "\\"  + defaultPresetFileName;

        Debug.Log("Trying path: " + presetFilePath);

        InputTracking.GetLocalPosition(VRNode.Head);

        //If the file doesn't exist in the default location,
        //an file opening dialog is created so the user can select a preset file
        if (!File.Exists(presetFilePath))
        {
            Debug.Log("Couldn't find a preset file with default name");
            OpenPresetFileDialog();
        } 

        try
        {
            ReadPreset();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        LoadScene();
    }

    // Update is called once per frame
    void Update () {
	    
	}

    private void ReadPreset()
    {
        StreamReader stream = new StreamReader(File.OpenRead(presetFilePath));
        PresetData.variables.Clear();
        while (!stream.EndOfStream)
        {
            string line = stream.ReadLine();
            string[] kVP = line.Split(',');
            PresetData.variables.Add(kVP[0], kVP[1]);
            Debug.Log(kVP);
        }
        stream.Close();
    }

    private void OpenPresetFileDialog()
    {

        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "CSV Files|*.csv";
        openFileDialog.Title = "Select a PainlessVR preset file";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            presetFilePath = openFileDialog.FileName;
            Debug.Log("Path selected: " + presetFilePath);
        }
        else
        {
            TerminateApp();
        }
    }

    private void LoadScene()
    {
        //Checks to see if a properly formatted task variable has been added
        if (!PresetData.variables.ContainsKey("task"))
            InvalidSceneDialog();


        int sceneIndex = 1;
        try
        {
            sceneIndex = Int32.Parse(PresetData.variables["task"]); //Parses the task variable for a scene index
        }
        catch (FormatException e)
        {
            InvalidSceneDialog();
        }

        //Checks to see if the scene (task) index is valid. It should always
        //be between 1 & 4, because the loading scene is 0, and there are 4 task scenes. 
        if (sceneIndex < 1 || sceneIndex > 4)
        {
            InvalidSceneDialog();
        }

        SceneManager.LoadScene(sceneIndex);

    }


    //Terminates app if a valid preset file is not provided.
    private void TerminateApp()
    {
        MessageBox.Show("Sorry, a valid preset file is required to run PainlessVR. \r\n The application will now terminate.",
                    "Preset Required");
        UnityEngine.Application.Quit();
    }

    //Prompts user to select another preset file if a valid task variable is not found. 
    private void InvalidSceneDialog()
    {
        DialogResult result1 = MessageBox.Show("The preset file doesn't designate a valid task. \r\n Please select a new preset file.",
    "Task Variable Required");
        if (result1 == DialogResult.OK)
        {
            OpenPresetFileDialog();
            ReadPreset();
            LoadScene();
        } else
        {
            TerminateApp();
        }
    }

}
