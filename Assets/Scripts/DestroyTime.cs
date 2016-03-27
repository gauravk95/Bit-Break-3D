using UnityEngine;
using System.Collections;

public class DestroyTime : MonoBehaviour {

    public float timeOfDestroy = 5.0f;
    private float timer = 0.0f;

	// Update is called once per frame
	void Update () 
    {
        if (timer > timeOfDestroy) Destroy(gameObject);
        timer += Time.fixedDeltaTime;
	}
}
