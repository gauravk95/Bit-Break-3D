using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeactivateSelf : MonoBehaviour {
    public float timeOfDeactivation = 5.0f;
    private float timer = 0.0f;

  
    // Update is called once per frame
    void Update()
    {
        if (timer > timeOfDeactivation) gameObject.SetActive(false);
        timer += Time.fixedDeltaTime;
    }
}
