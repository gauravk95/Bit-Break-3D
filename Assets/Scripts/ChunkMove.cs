using UnityEngine;

using System.Collections;

public class ChunkMove : MonoBehaviour {

    public float speed = 1.0f;
    public Boundary boundary;
    public GameObject[] Spinks = new GameObject[8];
    public AudioSource pop;
    
    private int SFX = 0;
	void FixedUpdate () 
    {
        Vector3 chunkMovement = new Vector3(0f, 0f, -speed);
        GetComponent<Rigidbody>().velocity = chunkMovement;
     

	}
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            
            Destroy(gameObject);
        }
  
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            boundary = other.GetComponent<Boundary>();
            SFX = boundary.SFXEnable;
            if (SFX == 1)
            {
                pop.enabled = true;
            }
            else
            {
                pop.enabled = false;
            }
        }
        if (other.tag == "Player")
        {
            boundary.scoring += 1;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<DestroyTime>().enabled = true;
            for (int i = 0; i < 8; i++) Spinks[i].SetActive(true);
                Destroy(other.gameObject);
        }
        if (other.tag == "Big Chunk Blast")
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<DestroyTime>().enabled = true;
            for (int i = 0; i < 8; i++) Spinks[i].SetActive(true);
        }
    }
    void Update()
    {
     
    }
}
