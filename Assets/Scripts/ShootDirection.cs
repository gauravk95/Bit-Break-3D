using UnityEngine;
using System.Collections;

public class ShootDirection : MonoBehaviour 
{
	public float speed = 1.0f;
    private Rigidbody bulletRigid;
  
    [HideInInspector]public int overAllScore = 0;

    void Start()
    {
        bulletRigid = GetComponent<Rigidbody>();
    }
	void FixedUpdate ()
	{
		Vector3 movement = new Vector3(0f, 0f, speed);
		bulletRigid.velocity = movement;
	}

	// Update is called once per frame

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Boundary")
		{
			Destroy(gameObject);
		}
	}
	
}
