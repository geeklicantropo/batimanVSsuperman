using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    private Rigidbody myRigidBody;
    public Transform pontoDeImpacto;

    private healthSuperman damg;
    public int bulletDamage;
    private float Timer;

    void Start()
    {
        GameObject player;
        player = GameObject.Find("Camera");
        myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.AddForce(player.transform.forward * bulletSpeed);
    }

    void Update()
    {
        Destroy(gameObject, 10.0f);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject,5.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        if (other.tag == "Superman" )
        {
            Instantiate(pontoDeImpacto, transform.position, Quaternion.identity);
            damg = other.GetComponent<healthSuperman>();            
            damg.Damage(bulletDamage);
            

            //Timer = Time.time + 0.5f;

            //other.gameObject.SetActive(false);
        }        
    }

    //void OnTriggerExit()
    //{
    //    Destroy(GameObject.Find("pontoDeImpacto(Clone)"), 1.0f);
    //}
}
