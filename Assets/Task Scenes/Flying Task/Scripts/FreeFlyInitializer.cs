<<<<<<< HEAD
﻿using UnityEngine;
=======
﻿ using UnityEngine;
>>>>>>> origin/fly-scene
using System.Collections;
using System;
using PainlessVR;
using System.Windows.Forms;
using System.IO;

public class FreeFlyInitializer : SceneInitializer {
  

    void Start()
    {
        presetModel = DeserializeVariables<FreeFlyPresetModel>();
        SetVisuals();
    }

    void Update()
    {

    }

    

    //public void DeserializeVariables()
    //{
    //    try
    //    {
    //        presetModel = JsonUtility.FromJson<FreeFlyPresetModel>(SceneLoader.json);
    //    } catch 
    //    {
    //    }
    //}


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
            cubes[i].gameObject.GetComponent<Renderer>().material.color = presetModel.worldColor;
        }
    }

}
