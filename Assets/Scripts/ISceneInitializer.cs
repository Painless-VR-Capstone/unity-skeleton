using UnityEngine;
using System.Collections;

interface ISceneInitializer {

    //The core method that should be run when the scene starts. 
    //Must deserialize 
    void DeserializeVariables();

    void SetAudio();

    void SetVisuals();

    void SetMechanics();

}

public enum PlayerObject
{
    Human, Robot, Orb
}
