using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
    }

    [SerializeField]
    private float speed;

    private Rigidbody myRigidBody;

    //Decide qual direção o Hadouken é lançado de acordo de onde o player está olhando.
    private Vector2 direction;


    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        myRigidBody.velocity = direction * speed;
    }

    //Ao ser instanciado no player, dá a direção da onde o hadouken deve avançar de acordo com para onde o player está olhando.
    public void Initialize(Vector3 direction)
    {
        this.direction = direction;
    }

    //Essa função executa a ação contida em seu escopo quando o gameObject ficar invisível para as camêras. ( Sair da tela).
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
            Destroy(gameObject);
    }

}
