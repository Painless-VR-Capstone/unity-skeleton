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
    internal const string defaultPresetFileName = "preset.json";
    internal string presetFilePath;
    internal int sceneIndex;
    //IMPORTANT This string holds all data from the JSON preset. All 
    //other scenes must reference this field to deserializa their variables. 
    internal static string json;

    //This small, nested "class" is only meant as a container for the 
    //task variable (the desired scene index). By using this structure,
    //the variable can be deserialized easily from the preset file. 
    [Serializable]
    internal class TaskVariable { public int task; }

    void Start() {
        
        presetFilePath = Directory.GetCurrentDirectory() + "\\"  + defaultPresetFileName;
        Debug.Log("Trying path: " + presetFilePath);

        //If the file doesn't exist in the default location,
        //an file opening dialog is created so the user can select a preset file
        if (!File.Exists(presetFilePath))
        {
            Debug.Log("Couldn't find a preset file with default name");
            OpenPresetFileDialog();
        } 

        try
        {
            FindSceneIndex();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        LoadScene();
    }


    private void FindSceneIndex()
    {
        json = File.ReadAllText(presetFilePath);
        Debug.Log("JSON read: " + json);
        TaskVariable taskVar = JsonUtility.FromJson<TaskVariable>(json);
        sceneIndex = taskVar.task;
    }

    private void OpenPresetFileDialog()
    {

        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "JSON Files|*.json";
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
        //Checks to see if the scene (task) index is valid. It should always
        //be between 1 & 4, because the loading scene is 0, and there are 4 task scenes. 
        if (sceneIndex < 1 || sceneIndex > 4)
            InvalidSceneDialog();
        
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
            FindSceneIndex();
            LoadScene();
        } else
        {
            TerminateApp();
        }
    }

}
