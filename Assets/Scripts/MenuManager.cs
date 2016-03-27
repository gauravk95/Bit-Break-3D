using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {


    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject aboutUsButton;
    public GameObject highscoreButton;

    public GameObject playBack,settingsBack;
    public GameObject aboutUsBack, highscoreBack;

    public GameObject[] Spawners;
    public GameObject loading;
    public GameObject loadingText;
    public GameObject BitText;
    public GameObject BreakText;
    public GameObject PlayText;
    public GameObject SettingsManager;
    public GameObject menuText;

    public GameObject aboutUs;
    public GameObject highscores;

    public float textGapTime = 1.0f,loadTime = 3.0f;

    private float timer;
    private bool  pressedSettings = false, pressedPlay = false;
    private bool pressedAboutUs = false, pressedHighscore = false;

    private int next = 0;
	// Use this for initialization
	void Start () {
        menuText.SetActive(true);
        pressedSettings = false;
        pressedPlay = false;

        Time.timeScale = 1.0f;
        loadingText.SetActive(false);
        for (int i = 0; i < Spawners.Length; i++)
        {
            Spawners[i].SetActive(true);
        }
        BitText.SetActive(true);
        BreakText.SetActive(true);
        PlayText.SetActive(true);
	}
	
	// Update is called once per frame
    void Update()
    {

        menuText.SetActive(true);

        if (Input.touchCount == 1)
        {
            Touch myTouch = Input.GetTouch(0);

            float x = (-640 + 1280 * myTouch.position.x / Screen.width) / 230f;
            float y = (-360 + 720 * myTouch.position.y / Screen.height) / 72f;


            if (myTouch.phase == TouchPhase.Began)
            {
                 if (x > -0.75 &&
                    x <  0.75 &&
                    y >  -0.5 &&
                    y < 0.5)
                 {
                     pressedPlay = true;
                     timer = 0;
                     next = 0;
                     playButton.GetComponent<Animation>().Play("Play Animation 2", PlayMode.StopSameLayer);
                     playBack.GetComponent<Animation>().Play("Play Animation 2", PlayMode.StopSameLayer);
                    
                 }
                if(x > -0.75 &&
                   x < 0.75 &&
                   y > -1.75 &&
                   y < -0.75)
                {
                    pressedSettings = true;
                    timer = 0;
                    next = 0;
                    settingsButton.GetComponent<Animation>().Play("Settings Animation 2", PlayMode.StopSameLayer);
                    settingsBack.GetComponent<Animation>().Play("Settings Animation 2", PlayMode.StopSameLayer);
                }
                if (x > -0.75 &&
                   x < 0.75 &&
                    y > -3.0 &&
                    y < -2.0)
                {
                    pressedAboutUs = true;
                    timer = 0;
                    aboutUsButton.GetComponent<Animation>().Play("About Us Animation 2", PlayMode.StopSameLayer);
                    aboutUsBack.GetComponent<Animation>().Play("About Us Animation 2", PlayMode.StopSameLayer);
                }
                if(x > -0.75 &&
                   x < 0.75 &&
                    y > -4.25 &&
                    y < -3.25)
                {
                    pressedHighscore = true;
                    timer = 0;
                    highscoreButton.GetComponent<Animation>().Play("Highscore Animation 2",PlayMode.StopSameLayer);
                    highscoreBack.GetComponent<Animation>().Play("Highscore Animation 2", PlayMode.StopSameLayer);
                }
            
            }
           
        }
        // If pressed Play Button
        if ( pressedPlay)
        {
            if (timer > textGapTime && next == 0)
            {
                settingsButton.GetComponent<Animation>().Play("Settings Animation 2", PlayMode.StopSameLayer);
                settingsBack.GetComponent<Animation>().Play("Settings Animation 2", PlayMode.StopSameLayer);
                next++;
            }
            if (timer > (2 * textGapTime) && next == 1)
            {
                aboutUsButton.GetComponent<Animation>().Play("About Us Animation 2", PlayMode.StopSameLayer);
                aboutUsBack.GetComponent<Animation>().Play("About Us Animation 2", PlayMode.StopSameLayer);
               
                next ++;
            }
            if(timer > (3 * textGapTime) && next == 2)
            {
                highscoreButton.GetComponent<Animation>().Play("Highscore Animation 2", PlayMode.StopSameLayer);
                highscoreBack.GetComponent<Animation>().Play("Highscore Animation 2", PlayMode.StopSameLayer);
                next++;
            }
            if (timer > loadTime)
            {
                next = 0;
                menuText.SetActive(false);
                loadingText.SetActive(true);
                SceneManager.LoadScene(2, LoadSceneMode.Single);
            }
        }
        //If pressed Settings
        if ( pressedSettings)
        {
            if (timer > textGapTime && next == 0)
            {
                aboutUsButton.GetComponent<Animation>().Play("About Us Animation 2", PlayMode.StopSameLayer);
                playButton.GetComponent<Animation>().Play("Play Animation 2", PlayMode.StopSameLayer);
                aboutUsBack.GetComponent<Animation>().Play("About Us Animation 2", PlayMode.StopSameLayer);
                playBack.GetComponent<Animation>().Play("Play Animation 2", PlayMode.StopSameLayer);
                next++;
            }
            if (timer > (2 * textGapTime) && next == 1)
            {
                highscoreButton.GetComponent<Animation>().Play("Highscore Animation 2", PlayMode.StopSameLayer);
                highscoreBack.GetComponent<Animation>().Play("Highscore Animation 2", PlayMode.StopSameLayer);
                next++;
            }
            if (timer > loadTime)
            {
                next = 0;
                menuText.SetActive(false);
                 SettingsManager.SetActive(true);
                 pressedSettings = false;
                 gameObject.SetActive(false);
            }
        }
        if ( pressedAboutUs)
        {
            if (timer > textGapTime && next == 0)
            {
                settingsButton.GetComponent<Animation>().Play("Settings Animation 2", PlayMode.StopSameLayer);
                highscoreButton.GetComponent<Animation>().Play("Highscore Animation 2", PlayMode.StopSameLayer);
                settingsBack.GetComponent<Animation>().Play("Settings Animation 2", PlayMode.StopSameLayer);
                highscoreBack.GetComponent<Animation>().Play("Highscore Animation 2", PlayMode.StopSameLayer);
                next++;
            }
            if (timer > (2 * textGapTime) && next == 1)
            {
                playButton.GetComponent<Animation>().Play("Play Animation 2", PlayMode.StopSameLayer);
                playBack.GetComponent<Animation>().Play("Play Animation 2", PlayMode.StopSameLayer);
                next++;
            }
            if (timer > loadTime)
            {
                next = 0;
                menuText.SetActive(false);
                aboutUs.GetComponent<AboutUsAnim>().timer = 0;
                aboutUs.SetActive(true);
                pressedAboutUs = false;
                gameObject.SetActive(false);
            }
        }
        if ( pressedHighscore)
        {
            if (timer > textGapTime && next == 0)
            {
                aboutUsButton.GetComponent<Animation>().Play("About Us Animation 2", PlayMode.StopSameLayer);
                aboutUsBack.GetComponent<Animation>().Play("About Us Animation 2", PlayMode.StopSameLayer);
                next++;
            }
            if (timer > (2 * textGapTime) && next == 1)
            {
                settingsButton.GetComponent<Animation>().Play("Settings Animation 2", PlayMode.StopSameLayer);
                settingsBack.GetComponent<Animation>().Play("Settings Animation 2", PlayMode.StopSameLayer);
                next++;
            }
            if (timer > (3 * textGapTime) && next == 2)
            {
                playButton.GetComponent<Animation>().Play("Play Animation 2", PlayMode.StopSameLayer);
                playBack.GetComponent<Animation>().Play("Play Animation 2", PlayMode.StopSameLayer);
                next++;
            }
            if (timer > loadTime)
            {
                next = 0;
                menuText.SetActive(false);
                highscores.SetActive(true);
                pressedHighscore = false;
                gameObject.SetActive(false);
            }
 
        }

        timer += Time.fixedDeltaTime; 
    }
  
 

}
