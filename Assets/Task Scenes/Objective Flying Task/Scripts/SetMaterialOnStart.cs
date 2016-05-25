using UnityEngine;
using System.Collections;

public class SetMaterialOnStart : MonoBehaviour {
    private Renderer matRender;
    public string materialFileName;
    public int colorNumber;
    private Color newMaterialColor;
    
    void Start()
    {
        switch (colorNumber)
        {
            case 0:
                newMaterialColor = GameObject.Find("Manager").GetComponent<ObjectiveFlyInitializer>().hazardColor;
                break;
            case 1:
                newMaterialColor = GameObject.Find("Manager").GetComponent<ObjectiveFlyInitializer>().playerColor;
                break;
            case 2:
                newMaterialColor = GameObject.Find("Manager").GetComponent<ObjectiveFlyInitializer>().objectiveColor;
                break;
            case 3:
                newMaterialColor = GameObject.Find("Manager").GetComponent<ObjectiveFlyInitializer>().uiColor;
                break;
        }
        matRender = gameObject.GetComponent<Renderer>();
        matRender.material = Resources.Load("SharedMaterials/" + materialFileName) as Material;
        matRender.material.color = newMaterialColor;
    }
}
