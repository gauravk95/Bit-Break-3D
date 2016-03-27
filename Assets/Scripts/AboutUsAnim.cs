using UnityEngine;
using System.Collections;

public class AboutUsAnim : MonoBehaviour {

    public float goBack;

    public GameObject menuManager;

    [HideInInspector]public float timer = 0;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.touchCount == 1)
        {
            Touch myTouch = Input.GetTouch(0);


            if (myTouch.phase == TouchPhase.Began)
            {
                menuManager.SetActive(true);
                gameObject.SetActive(false);
            }
        }
        if (goBack < timer)
        {
            menuManager.SetActive(true);
            gameObject.SetActive(false);
        }
        timer += Time.deltaTime;

	}
}
