using UnityEngine;
using System.Collections;

public class CameraColorShift : MonoBehaviour {
    [Range(0,1)]
    public float brightness = .5f, contrast = .5f, hue = .5f, saturation = .5f;
    public ColorSuite colorSuite;
    public Material red, green, blue, yellow, part;
    public Color r, g, b, y;

	// Use this for initialization
	void Start () {
        red.color = r;
        green.color = g;
        blue.color = b;
        yellow.color = y;
        part.SetColor("_EmissionColor", y);
        yellow.SetColor("_EmissionColor", Color.Lerp(y, Color.black, .5f));
    }
	
	// Update is called once per frame
	void Update () {
        
        colorSuite.rgbCurve = getCurve(contrast - .5f, -contrast + 1.5f, brightness - contrast, 1 + brightness - contrast);
        colorSuite.redCurve = getCurve(0, 1, 0, 1 + (hue * 2 - 1f));
        colorSuite.blueCurve = getCurve(0, 1, 0, 1 - (hue * 2 - 1f));
        colorSuite.saturation = saturation * 2;
    }

    AnimationCurve getCurve(float startTime, float EndTime, float startValue, float EndValue)
    {
        Keyframe[] newKC = new Keyframe[2];
        newKC[0] = new Keyframe(startTime, startValue);
        newKC[1] = new Keyframe(EndTime, EndValue);
        return new AnimationCurve(newKC);
    }
}
