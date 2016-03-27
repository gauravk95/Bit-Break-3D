using UnityEngine;
using System.Collections;

public class MenuCubeScript : MonoBehaviour {

    public float rotator;
    public float movementX;
    public float movementZ;
    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
        Vector3 movement = new Vector3(movementX * speed, 0, movementZ * speed);
        GetComponent<Rigidbody>().velocity = movement;

	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(new Vector3(0, rotator, 0), Space.Self);
	}

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
