using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public Transform bala;
    public Transform faisca;

    //public Player batman;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bala, transform.position, Quaternion.identity);
            Instantiate(faisca, transform.position, Quaternion.identity);
        }
        Destroy(GameObject.Find("faisca(Clone)"), 0.5f);
        Destroy(GameObject.Find("pontoDeImpacto(Clone)"), 1.0f);
    }
}

