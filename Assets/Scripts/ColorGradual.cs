using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorGradual : MonoBehaviour {

    public float duration;
    public float after;

    private float timer = 0.0f;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
        if (timer > after)
        {
            GetComponent<Image>().CrossFadeAlpha(0, duration, false);
        }
        timer += Time.fixedDeltaTime;
	}
}
