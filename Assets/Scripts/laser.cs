using UnityEngine;
using System.Collections;

public class laser: MonoBehaviour
{
    [SerializeField]
    private float laserSpeed;
    private Rigidbody myRigidBody;
    public Transform pontoDeImpactoBatman;

    private healthBatman damg;
    [SerializeField]
    private int laserDamage;
    private float Timer;

    void Start()
    {
        GameObject player;
        player = GameObject.Find("Camera2");
        myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.AddForce(player.transform.forward * laserSpeed);
    }

    void Update()
    {
        Destroy(gameObject, 10.0f);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject, 5.0f);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    Destroy(this.gameObject);
    //    if (other.tag == "Superman")
    //    {

    //        Instantiate(pontoDeImpacto, transform.position, Quaternion.identity);
    //        other.gameObject.SetActive(false);            
    //    }

    //}

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        if (other.tag == "Batman")
        {
            Instantiate(pontoDeImpactoBatman, transform.position, Quaternion.identity);
            damg = other.GetComponent<healthBatman>();
            damg.Damage(laserDamage);
            

            //Timer = Time.time + 0.5f;

            //other.gameObject.SetActive(false);
        }
        
    }
    //void OnTriggerExit()
    //{
    //    Destroy(GameObject.Find("pontoDeImpactoBatman(Clone)"), 1.0f);
    //}

    //void OnTriggerStay(Collider other)
    //{
    //    //Destroy(this.gameObject);
    //    if (other.tag == "Superman" && Timer < Time.time)
    //    {
    //        damg.Damage(bulletDamage);
    //        Timer = Time.time + 0.5f;
    //    }
    //}
}
