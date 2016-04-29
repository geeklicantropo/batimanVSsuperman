using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float bulletSpeed;
    private Rigidbody myRigidBody;

    
    void Start()
    {
        GameObject player;
        player = GameObject.Find("Camera");
        myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.AddForce(player.transform.forward * bulletSpeed);
    }

    void Update()
    {
        Destroy(gameObject, 1f);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //void OnCollisionEnter(Collider colisor)
    //{
    //    colisor.GetComponent<Collider>();
    //    if(colisor.tag == "Superman")
    //    {
    //        colisor.gameObject.SetActive(false);
    //        Destroy(this.gameObject);
    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        if (other.tag == "Superman")
        {
            other.gameObject.SetActive(false);            
        }
        
    }

    //Decide qual direção o tiro é lançado de acordo de onde o player está olhando.
    //private Vector3 direction;


    // Use this for initialization

    //void FixedUpdate()
    //{
    //    myRigidBody.velocity = direction * bulletSpeed;
    //}

    ////Ao ser instanciado no player, dá a direção da onde o hadouken deve avançar de acordo com para onde o player está olhando.
    //public void Initialize(Vector3 direction)
    //{
    //    this.direction = direction;
    //}

    ////Essa função executa a ação contida em seu escopo quando o gameObject ficar invisível para as camêras. ( Sair da tela).
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "bullet")
    //        Destroy(gameObject);
    //}

    ////Essa função executa a ação contida em seu escopo quando o gameObject ficar invisível para as camêras. ( Sair da tela).




}
