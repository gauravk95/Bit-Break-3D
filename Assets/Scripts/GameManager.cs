using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Public Variables
    public GameObject bullet;
    public GameObject chunk;
    public GameObject bigChunk;
    public GameObject pauseBackground;
    public GameObject gameOverBackground;
    public GameObject waveText, textBackground;
    public GameObject pauseImage;
    public GameObject playImage;
    public GameObject menuButton;
    public GameObject restartImage;
    public GameObject scoreBackground;
    public GameObject playPos, restartPos, menuPos;


    public int chunkQuantity = 17;
    public int score = 0;

    public float spawnZ = 0.0f;
    public float touchZLimit = 0.0f;
    public float waveTime = 8.0f, waves = 0.0f;
    public float increamentalSpeed = 0.02f, timer = 0.0f;

    public bool gameOver = false;
    

    public Text gameOverText, pauseText;
    public Text highScoreText;

    public Blur blur;

    public BigChunkProperties BigScript;

    public Boundary boundary;
    [HideInInspector]
    public bool newHighscoreBool = false;



    //Private Variables
    private bool disable = true;
    private int size = 6, Xpos, Zpos = -1;
    private int newHighscore = 0;
    private float distance = 0.0f;
    private float spawnTime;
    private float pastTime, nextWaveTime;
    private float presentDistance = 0.0f;
    private int j;
    private float initialSpeed = 0.28f;
    private Text text_waveText;
    private Animation anim_waveText, anim_waveBackground;
    private ChunkMove chunkmovement;
    private BigChunkProperties bigchunkprop;
    private bool once = true;
    void Start()
    {
        pastTime = 0.0f;
        nextWaveTime = 0.0f;
        distance = 5.3f / chunkQuantity;
        waves = 1;
        Time.timeScale = 1.0f;
        text_waveText = waveText.GetComponent<Text>();
        anim_waveText = waveText.GetComponent<Animation>();
        anim_waveBackground = textBackground.GetComponent<Animation>();
        chunkmovement = chunk.GetComponent<ChunkMove>();
        bigchunkprop = bigChunk.GetComponent<BigChunkProperties>();


        text_waveText.text = "WAVE " + waves;
        anim_waveText.Play();
        anim_waveBackground.Play();
        Xpos = size;
        chunkmovement.speed = initialSpeed;
        bigchunkprop.speed = initialSpeed;
        spawnTime = (distance / chunkmovement.speed);
        pauseImage.SetActive(true);
        playImage.SetActive(false);
        menuButton.SetActive(false);
        restartImage.SetActive(false);
        blur.enabled = false;
        if (PlayerPrefs.GetInt("Music", 0) == 1)
        {
            GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            GetComponent<AudioSource>().enabled = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        TouchFunc();


        if (gameOver)
        {
            menuButton.SetActive(true);

            gameOverBackground.SetActive(true);
            gameOverText.text = "GAME OVER";

            scoreBackground.SetActive(false);
            playImage.SetActive(true);
            blur.enabled = true;
            menuButton.SetActive(true);
            pauseImage.SetActive(false);
            score = boundary.scoring;
            newHighscore = score;

            StoreHighscore();
            if (newHighscoreBool)
            {
                highScoreText.text = "NEW HIGHSCORE";
                newHighscoreBool = false;
            }

        }
    }
    void FixedUpdate()
    {
        ChunkGeneration();
        NextWave();
    }

    void NextWave()
    {
        if (waveTime <= nextWaveTime && !gameOver)
        {
            waves++;
            text_waveText.text = "WAVE " + waves;
            chunkmovement.speed += increamentalSpeed;
            bigchunkprop.speed += increamentalSpeed;
            spawnTime = 20.0f;
            nextWaveTime = 0.0f;
        }
        if (timer > (waveTime + spawnTime) && !gameOver)
        {
            anim_waveText.Play();
            anim_waveBackground.Play();
            timer = 0.0f;
        }
        nextWaveTime += Time.fixedDeltaTime;
        timer += Time.fixedDeltaTime;
    }
    void ChunkGeneration()
    {
        if (spawnTime <= pastTime)
        {
            spawnTime = (distance / chunkmovement.speed);
            presentDistance = -2.5f;
            pastTime = 0.0f;
            for (int i = 0; i < chunkQuantity; i++, presentDistance += distance)
            {
                if (((int)(Random.value * 10)) % 5 == 0 && i <= (chunkQuantity - 2) && disable == true)
                {
                    size = (int)Random.Range(2, (chunkQuantity - i - 1 < 7) ? (chunkQuantity - 1 - i) : 7);
                    disable = false;
                    Zpos = i;
                    Xpos = size;
                }
                //Big Chunk Spawn
                if (i == Zpos && disable == false)
                {
                    if (size > (Xpos))
                    {
                        disable = false;
                        Xpos++;
                        presentDistance += (distance * (size - 1));
                        i += (size - 1);
                        if (size == (Xpos + 1))
                        {
                            disable = true;
                            Zpos = -1;
                        }

                        continue;
                    }
                    else if (size <= (Xpos))
                    {
                        disable = false;
                        BigScript.BigChunk1Calling(spawnZ, presentDistance, distance, size);

                        presentDistance += (distance * (size - 1));
                        i += (size - 1);
                        Xpos = 0;
                        continue;
                    }
                }
                //Chunk Spawn
                else
                {
                    GameObject spawnPoint = Instantiate(chunk);
                    spawnPoint.transform.position = new Vector3(presentDistance, 0f, spawnZ);
                }

            }
        }
        pastTime += Time.fixedDeltaTime;
    }

    void TouchFunc()
    {
        if (Input.touchCount >= 1)
        {
            Touch myTouch = Input.GetTouch(0);

            float x = (-640 + 1280 * myTouch.position.x / Screen.width) / 230f;
            float y = (-360 + 720 * myTouch.position.y / Screen.height) / 72f;


            if (myTouch.phase == TouchPhase.Began)
            {
                //Menu Button
                if (x > (menuPos.GetComponent<Transform>().position.x - 0.5f) &&
                   x < (menuPos.GetComponent<Transform>().position.x + 0.5f) &&
                   y > (menuPos.GetComponent<Transform>().position.z - 0.5f) &&
                   y < (menuPos.GetComponent<Transform>().position.z + 0.5f) &&
                    Time.timeScale == 0.0f)
                {
                    StoreHighscore();
                    SceneManager.LoadScene(1, LoadSceneMode.Single);
                }
                //Bullet Shots within box range
                if (y < touchZLimit && !gameOver && Time.timeScale != 0.0f)
                {
                    gameOverText.text = " ";
                    GameObject shooter = Instantiate(bullet);
                    shooter.transform.position = new Vector3(x, 0f, y);

                }
                //Pause Button
                if (x > (pauseImage.GetComponent<Transform>().position.x - .5f) &&
                    x < (pauseImage.GetComponent<Transform>().position.x + .5f) &&
                    y > (pauseImage.GetComponent<Transform>().position.z - .5f) &&
                    y < (pauseImage.GetComponent<Transform>().position.z + .5f) &&
                    Time.timeScale == 1.0f && !gameOver)
                {

                    pauseBackground.SetActive(true);

                    if (PlayerPrefs.GetInt("Music", 0) == 1)
                    {
                        GetComponent<AudioSource>().Pause();
                    }
                    pauseText.text = "PAUSE";
                    menuButton.SetActive(true);
                    playImage.SetActive(true);
                    pauseImage.SetActive(false);
                    blur.enabled = true;
                    newHighscore = score;
                    StoreHighscore();
                    scoreBackground.SetActive(false);
                    restartImage.SetActive(true);
                    waveText.GetComponent<Text>().text = " ";
                    Time.timeScale = 0.0f;
                }
                //Play button on pause
                else if (x > (playPos.GetComponent<Transform>().position.x - .5f) &&
                    x < (playPos.GetComponent<Transform>().position.x + .5f) &&
                    y > (playPos.GetComponent<Transform>().position.z - .5f) &&
                    y < (playPos.GetComponent<Transform>().position.z + .5f) &&
                    Time.timeScale == 0.0f && !gameOver)
                {
                    pauseBackground.SetActive(false);
                    if (PlayerPrefs.GetInt("Music", 0) == 1)
                    {
                        GetComponent<AudioSource>().Play();
                    }
                    pauseText.text = " ";
                    menuButton.SetActive(false);
                    playImage.SetActive(false);
                    pauseImage.SetActive(true);
                    blur.enabled = false;

                    scoreBackground.SetActive(true);
                    restartImage.SetActive(false);
                    text_waveText.text = "WAVE " + waves;
                    Time.timeScale = 1.0f;
                }
                //Restart Button
                if (x > (restartPos.GetComponent<Transform>().position.x - .5f) &&
                 x < (restartPos.GetComponent<Transform>().position.x + .5f) &&
                 y > (restartPos.GetComponent<Transform>().position.z - .5f) &&
                 y < (restartPos.GetComponent<Transform>().position.z + .5f) &&
                    Time.timeScale == 0.0f)
                {
                    once = true;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                //Game Over
                if (gameOver)
                {
                    if (x > (playPos.GetComponent<Transform>().position.x - .5f) &&
                     x < (playPos.GetComponent<Transform>().position.x + .5f) &&
                     y > (playPos.GetComponent<Transform>().position.z - .5f) &&
                     y < (playPos.GetComponent<Transform>().position.z + .5))
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                    if (x > (menuPos.GetComponent<Transform>().position.x - 0.5f) &&
                  x < (menuPos.GetComponent<Transform>().position.x + 0.5f) &&
                  y > (menuPos.GetComponent<Transform>().position.z - 0.5f) &&
                  y < (menuPos.GetComponent<Transform>().position.z + 0.5f))
                    {
                        SceneManager.LoadScene(1, LoadSceneMode.Single);
                    }
                }



            }
            //Second Tap
            Touch myTouch2 = Input.GetTouch(1);

            float x2 = (-640 + 1280 * myTouch2.position.x / Screen.width) / 230f;
            float y2 = (-360 + 720 * myTouch2.position.y / Screen.height) / 72f;
            if (myTouch2.phase == TouchPhase.Began)
            {
                if (y2 < touchZLimit && !gameOver && Time.timeScale != 0.0f)
                {
                    gameOverText.text = " ";
                    GameObject shooter = Instantiate(bullet);
                    shooter.transform.position = new Vector3(x2, 0f, y2);
                }


            }
            //Comparing and Storing the Highscore

        }
    }
    void StoreHighscore()
    {

        if (once)
        {
            once = false;
            int oldHighscore = PlayerPrefs.GetInt("Highscore" + 0, 0);
            if (newHighscore > oldHighscore)
            {
                newHighscoreBool = true;
            }
            for (int i = 0; i < 5; i++)
            {
                if (newHighscore > PlayerPrefs.GetInt("Highscore" + i, 0))
                {
                    int Temp = PlayerPrefs.GetInt("Highscore" + i, 0);
                    PlayerPrefs.SetInt("Highscore" + i, newHighscore);
                    newHighscore = Temp;
                }
            }
        }

    }
}