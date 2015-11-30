using UnityEngine;
using System.Collections;

public class Colourizer : MonoBehaviour {

    public Color color;
    public float offset = 2f;

	// Use this for initialization
	void Start () {
        this.GetComponent<Renderer>().material.color = Randomize(color);
        this.GetComponent<Renderer>().material.SetColor("_EMISSION", Randomize(color));
    }

    Color Randomize(Color color)
    {
        float value = (color.r + color.g + color.b) / 3;
        float newValue = value + 2 * Random.Range(0.1f,1) * offset;
        float valueRatio = newValue / value;
        Color newColor = new Color();
        newColor.r = color.r * valueRatio;
        newColor.g = color.g * valueRatio;
        newColor.b = color.b * valueRatio;
        return newColor;
    }
}
