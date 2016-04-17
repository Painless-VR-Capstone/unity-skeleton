using UnityEngine;
using System.Collections;

public class CameraColorShift : MonoBehaviour {
    [Range(0,1)]
    public float brightness = .5f, contrast = .5f, hue = .5f;
    public ColorSuite colorSuite;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        float difference = 1 - (contrast * 2);
        colorSuite.rgbCurve = getCurve(0, 1, 0 + difference * brightness + (brightness - .5f), 1 - difference + (brightness - .5f));
        colorSuite.redCurve = getCurve(0, 1, 0, 1 + (hue * 5 - 2.5f) / 10);
	}

    AnimationCurve getCurve(float startTime, float EndTime, float startValue, float EndValue)
    {
        Keyframe[] newKC = new Keyframe[2];
        newKC[0] = new Keyframe(startTime, startValue);
        newKC[1] = new Keyframe(EndTime, EndValue);
        return new AnimationCurve(newKC);
    }
}
