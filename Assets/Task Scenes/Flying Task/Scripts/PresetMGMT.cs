using UnityEngine;
using System.Collections;
using System.IO;

public class PresetMGMT : MonoBehaviour {

    void Awake()
    {
        var reader = new StreamReader(File.OpenRead(@"C:\preset.csv"));

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            string[] lineValues = line.Split(',');

            if (lineValues[0].Contains("color"))
            {
                SetWorldColor(float.Parse(lineValues[1]), float.Parse(lineValues[2]), float.Parse(lineValues[3]));
            }

        }
    }

    void SetWorldColor(float r, float g, float b) 
    {
        Color newColor = new Color(.5f, .2f, .7f);
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].gameObject.GetComponent<Renderer>().material.color = newColor;
            //cubeColor = Color.black;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
