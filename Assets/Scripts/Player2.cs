using UnityEngine;
using XboxCtrlrInput;
using System.Collections;

public class Player2 : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 20f;
    public Rigidbody rb;
    [SerializeField]
    private float pulo = 25f;

    public int joystickNumber;
    private bool noChao = false;
    private bool temParede;
    private Quaternion rotacao;
    public XboxController controller;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        ////Esse pedaço do código trabalha com detecção de paredes e do chão
        noChao = Physics.Raycast(transform.position, -Vector3.up, 2f);
        temParede = Physics.Raycast(transform.position, transform.forward, 2f);


        //////Esse pedaço do código trabalha com movimentação
        float hAxis = XCI.GetAxis(XboxAxis.LeftStickX, controller);
        float vAxis = XCI.GetAxis(XboxAxis.LeftStickY, controller);

        //transform.Translate(hAxis * velocidade * Time.deltaTime, 0, vAxis * velocidade * Time.deltaTime);


        //Esse pedaço do código detecta quando o jogador pressiona o botão de pulo.
        if (XCI.GetButtonDown(XboxButton.A))
        {
            if (noChao == true)
            {
                rb.velocity = new Vector3(0, pulo, 0);
            }
        }
    }

}