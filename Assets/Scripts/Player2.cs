using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour
{
    public float velocidade = 10f;
    public Rigidbody rb;
    public float pulo = 15f;
    private bool noChao = false;
    private bool temParede;
    private Quaternion rotacao;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Esse pedaço do código trabalha com detecção de paredes e do chão
        noChao = Physics.Raycast(transform.position, -Vector3.up, 2f);
        temParede = Physics.Raycast(transform.position, transform.forward, 2f);


        ////Esse pedaço do código trabalha com movimentação
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Translate(hAxis * velocidade * Time.deltaTime, 0, vAxis * velocidade * Time.deltaTime);

        //rb.MovePosition(transform.position + movement);

        ////Detecta a direção que o jogador está olhando
        //if (Input.GetAxis("Horizontal") != 0)
        //{
        //    rotacao.SetLookRotation(new Vector3(Input.GetAxis("Horizontal"), 0, 0));
        //    transform.rotation = rotacao;
        //}

        //Esse pedaço do código detecta quando o jogador pressiona o botão de pulo.
        if (Input.GetButtonDown("Jump"))
        {
            if (noChao == true)
            {
                rb.velocity = new Vector3(0, pulo, 0);
            }
        }
    }

}