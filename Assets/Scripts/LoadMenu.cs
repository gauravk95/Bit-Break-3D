using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadMenu : MonoBehaviour {

    public float after = 15.0f;

    private float timer = 0.0f;

	
	// Update is called once per frame
	void Update () {
        if (timer > after)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        timer += Time.fixedDeltaTime;
	}
}
