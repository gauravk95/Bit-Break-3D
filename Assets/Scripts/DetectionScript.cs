using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetectionScript : MonoBehaviour {

    public GameManager Manager;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Chunks" || other.tag == "Big Chunk")
        {
            Manager.gameOver = true;
        }
       
    }
}
