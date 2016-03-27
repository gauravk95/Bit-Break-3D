using UnityEngine;
using System.Collections;
public class BigChunkProperties : MonoBehaviour 
{

    public float speed = 1.0f;
    public float times = 0;
    public GameObject bigChunkFill;
    public GameObject bigBlastSound;
    public GameObject bigChunkBlast;
    public GameObject blastVoid;
    public Boundary boundary;
    public float setTimes;
    public AudioSource blast;

    private bool destroyed = false;
    private Rigidbody bigchunkRigid;
    private Transform fillTransform;


    private int SFX = 0;
    public void BigChunk1Calling(float Z, float X, float distance, float size)
    {
        times = 2 * size;
        setTimes = times;

        transform.localScale = new Vector3(((size - 3) * distance / 4) + ((size) * .25f), 1, ((size - 3) * distance / 4) + ((size) * .25f));
        Instantiate(gameObject, new Vector3(X + ((distance * (size-1))/2), 0f, Z + ((distance * (size-1))/2)), new Quaternion(0f,0f,0f,0f));
       
    }
    void Start()
    {
        bigchunkRigid = GetComponent<Rigidbody>();
        fillTransform = bigChunkFill.GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        Vector3 chunkMovement = new Vector3(0f, 0f, -speed);
        bigchunkRigid.velocity = chunkMovement;

    }

 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !destroyed)
        {
            if (times > 0)
            {
                times--;
                fillTransform.localScale = new Vector3((setTimes-times)/setTimes * 1.0f,
                                                                                fillTransform.localScale.y,
                                                                                (setTimes-times)/setTimes * 1.0f);
                Destroy(other.gameObject);
            }
            else
            {
                boundary.scoring += (int)setTimes;
                destroyed = true;
                Instantiate(bigBlastSound);
                GetComponent<BoxCollider>().enabled = false;

                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<DestroyTime>().enabled = true;
                blastVoid.SetActive(true);
                bigChunkBlast.SetActive(true);
                bigChunkFill.SetActive(false);
                Destroy(other.gameObject);

            }
        }

        if (other.tag == "Boundary")
        {
            boundary = other.GetComponent<Boundary>();
            SFX = boundary.SFXEnable;
            if (SFX == 1)
            {
                blast.enabled = true;
            }
            else
            {
                blast.enabled = false;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
            if (other.tag == "Boundary")
            {
                Destroy(gameObject);
            }
    }
	
}
