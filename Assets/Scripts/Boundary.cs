using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Boundary : MonoBehaviour {

    public int scoring;
    public int highscoring;
    public Text score;
    public Text highscore;

    public int SFXEnable;
	// Use this for initialization
	void Start () {
        highscoring = PlayerPrefs.GetInt("Highscore" + 0,0);
        SFXEnable = PlayerPrefs.GetInt("SFX",0);
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "SCORE: " + scoring;
        if (highscoring > scoring)
        {
            highscore.text = "HIGHSCORE: " + highscoring;
        }
        else
        {
            highscore.text = "HIGHSCORE: " + scoring; 
        }
	}
}
