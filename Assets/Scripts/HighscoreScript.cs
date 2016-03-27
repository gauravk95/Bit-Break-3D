using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscoreScript : MonoBehaviour {

    public GameObject menuManager;

    public Text[] Highscore;


    void Start()
    {
        for (int i = 0; i < Highscore.Length; i++)
        {
            Highscore[i].text = "" + PlayerPrefs.GetInt("Highscore" + i, 0);
        }
    }
	// Update is called once per frame
	void Update () {


        if (Input.touchCount == 1)
        {
            Touch myTouch = Input.GetTouch(0);


            if (myTouch.phase == TouchPhase.Began)
            {
                menuManager.SetActive(true);
                gameObject.SetActive(false);
            }
        }
       
	}
}
