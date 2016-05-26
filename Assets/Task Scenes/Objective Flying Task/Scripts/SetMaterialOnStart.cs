using UnityEngine;
using System.Collections;

public class SetMaterialOnStart : MonoBehaviour {
    private Renderer matRender;
    public string materialFileName;
    public int colorNumber;
    private Color newMaterialColor;
    
    void Start()
    {
        ObjectiveFlyInitializer initializer = GameObject.Find("Manager").GetComponent<ObjectiveFlyInitializer>();
        switch (colorNumber)
        {
            case 0:
                newMaterialColor = initializer.hazardColor;
                break;
            case 1:
                newMaterialColor = initializer.playerColor;
                break;
            case 2:
                newMaterialColor = initializer.objectiveColor;
                break;
            case 3:
                newMaterialColor = initializer.uiColor;
                break;
        }
        matRender = gameObject.GetComponent<Renderer>();
        matRender.material = Resources.Load("SharedMaterials/" + materialFileName) as Material;
        matRender.material.color = newMaterialColor;
    }
}
