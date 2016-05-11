using UnityEngine;
using System.Collections;
using System;

public abstract class SceneInitializer : MonoBehaviour {
    internal PresetModel presetModel; //IMPORTANT - the model that should hold all variable data. 
                                      //Initialize with DeserializeVariables()


    //The core method that should be run when the scene starts. 
    //Type argument must be a PresetModel so that it can deserialize 
    //correctly, otherwise it returns null. Making this method generic
    //allows it to use any PresetModel implementation. 
    internal T DeserializeVariables<T>()
    {
        try
        {
            return JsonUtility.FromJson<T>(SceneLoader.json);
        }
        catch (Exception e)
        {
            Debug.Log("Exception while deserializing JSON: \r\n" + e.Message);
        }
        return default(T);
    }

    //void SetAudio();

    //void SetVisuals();

    //void SetMechanics();

}

public enum PlayerObject
{
    Human, Robot, Orb
}
