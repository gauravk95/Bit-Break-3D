using UnityEngine;
using System.Collections;

public class MenuSpawnner : MonoBehaviour {

    public GameObject[] Cubes;


    private float timer = 0.0f;
    private float cubeSpawnTime = 0.5f;
    private int cubeNo;
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (timer > cubeSpawnTime)
        {
            timer = 0.0f;
            cubeNo = Random.Range(0,Cubes.Length);
            Cubes[cubeNo].GetComponent<MenuCubeScript>().rotator = Random.Range(1, 10);
            Cubes[cubeNo].GetComponent<MenuCubeScript>().movementX = Random.Range(-15, 15);
            Cubes[cubeNo].GetComponent<MenuCubeScript>().movementZ = Random.Range(-15, 15);
            Instantiate(Cubes[cubeNo], transform.position, transform.rotation);
        }

        timer += Time.fixedDeltaTime;
	}
}
