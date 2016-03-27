using UnityEngine;
using System.Collections;

public class SettingsManager : MonoBehaviour {


    [HideInInspector] public bool Music = true;
    [HideInInspector] public bool SFX = true;
    

    public float callDelay = 2.5f;

    public GameObject menuManager;
    public GameObject settingsCanvas;
    public GameObject settingText, SFXText, musicText, backText;
    public GameObject SFXBack, musicBack, backButtonBack;
    public GameObject SFXCB, musicCB;
    public GameObject SFXFill, MusicFill;
 
    private float timer = 0.0f;

    public bool menu;
    public int m_SFX, m_Music;
	// Use this for initialization
	void Start () 
    {
        menu = false;
        settingsCanvas.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () 
    {
        settingsCanvas.SetActive(true);
        m_SFX = PlayerPrefs.GetInt("SFX", 1);
        m_Music = PlayerPrefs.GetInt("Music", 1);
        if (m_SFX == 1) SFXFill.SetActive(true);
        else SFXFill.SetActive(false);
        if (m_Music == 1) MusicFill.SetActive(true);
        else MusicFill.SetActive(false);
        
        if (Input.touchCount == 1)
        {
            Touch myTouch = Input.GetTouch(0);

            float x = (-640 + 1280 * myTouch.position.x / Screen.width) / 230f;
            float y = (-360 + 720 * myTouch.position.y / Screen.height) / 72f;


            if (myTouch.phase == TouchPhase.Began)
            {
                //Back Button

                if (x > -1 &&
                    x < 1 &&
                    y > -3 &&
                    y < -2)
                {

                        menu = true;
                        timer = 0.0f;
                        settingText.GetComponent<Animation>().Play("Settings Op Animation 2", PlayMode.StopSameLayer);
                        SFXText.GetComponent<Animation>().Play("SFX Animation 2", PlayMode.StopSameLayer);
                        musicText.GetComponent<Animation>().Play("Music Animation 2", PlayMode.StopSameLayer);
                        backText.GetComponent<Animation>().Play("Back Animation 2", PlayMode.StopSameLayer);
                        SFXBack.GetComponent<Animation>().Play("SFX Animation 2", PlayMode.StopSameLayer);
                        musicBack.GetComponent<Animation>().Play("Music Animation 2", PlayMode.StopSameLayer);
                        backButtonBack.GetComponent<Animation>().Play("Back Animation 2", PlayMode.StopSameLayer);
                        SFXCB.GetComponent<Animation>().Play("SFX CB Animation 2", PlayMode.StopSameLayer);
                        musicCB.GetComponent<Animation>().Play("Music CB Animation 2", PlayMode.StopSameLayer);
                }
                if (x > 1.1 &&
                    x < 2.1 &&
                    y > -0.5 &&
                    y < .3)
                {
                    m_Music = PlayerPrefs.GetInt("Music",1);
                    if (m_Music == 1)
                    {
                       
                        m_Music = 0;
                    }
                    else
                    {
                        
                        m_Music = 1;
                    }
                    PlayerPrefs.SetInt("Music", m_Music);
                }
                if (x > 0.86 &&
                    x < 1.86 &&
                    y > .35 &&
                    y < 1.15)
                {
                    m_SFX = PlayerPrefs.GetInt("SFX", 1);
                    if (m_SFX == 1)
                    {
                        m_SFX = 0;
                    }
                    else
                    {
                        m_SFX = 1;
                    }
                    PlayerPrefs.SetInt("SFX",m_SFX);
                }
            }
           
        }
    
        if (timer > callDelay && menu)
        {

            menu = false;
            settingsCanvas.SetActive(false);
            menuManager.SetActive(true);
            gameObject.SetActive(false);
        }
        timer += Time.fixedDeltaTime;
	}
}
