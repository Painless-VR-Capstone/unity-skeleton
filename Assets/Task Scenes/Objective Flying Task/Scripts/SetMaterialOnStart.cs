using UnityEngine;
using System.Collections;

public class SetMaterialOnStart : MonoBehaviour {
    private Renderer matRender;
    public string materialFileName;
    public Color newMaterialColor;
    
    void Start()
    {
        matRender = gameObject.GetComponent<Renderer>();
        matRender.material = Resources.Load("SharedMaterials/" + materialFileName) as Material;
        matRender.material.color = newMaterialColor;
    }
}
