//This abstract class models a PVR preset when implemented.
//As a model, it only contains a data, a model of the application's state. 
//Each task/scene must provide its own implementation of PresetModel, with
//the addition of its particular variables.  


using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class PresetModel {

    //Base variables that should be present in every scene
    // TODO Determine all the variables that can be shared between scenes
    public Color worldColor;
    public PlayerObject playerObject;
    public string musicPath;
    public double musicTempo; 

}
