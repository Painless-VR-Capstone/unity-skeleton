using UnityEngine;
using System.Collections;

interface ISceneInitializer {

    void DeserializeVariables();

    void SetAudio();

    void SetVisuals();

    void SetMechanics();

}

public enum PlayerObject
{
    Human, Robot, Orb
}
