using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

    public Transform bala;
    public Transform faisca;
    public Transform pontoDeImpacto;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (dir != Vector3.zero)
        {
            transform.forward = Vector3.Normalize(dir);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(bala, transform.position, Quaternion.identity);
        }

        //if(Input.GetButtonDown("Fire1"))
        //{
        //    RaycastHit bala = new RaycastHit();

        //    if (Physics.Raycast(transform.position, transform.forward, out bala))
        //    {
        //        Instantiate(faisca, bala.collider.gameObject.transform.position, Quaternion.identity);

        //        if (bala.collider.tag == "Superman")
        //        {
        //            Instantiate(pontoDeImpacto, bala.collider.gameObject.transform.position, Quaternion.identity);
        //            bala.collider.gameObject.SetActive(false);
        //            Destroy(GameObject.Find("faisca(Clone)"), 1.0f);
        //            Destroy(GameObject.Find("pontoDeImpacto(Clone)"), 1.0f);
        //        }
        //    }
        //}

        Destroy(GameObject.Find("faisca(Clone)"), 1.0f);
        Destroy(GameObject.Find("pontoDeImpacto(Clone)"), 1.0f);


        //if (Input.GetKeyDown(shootKey))
        //{
        //    GameObject instance = Instantiate(shot, transform.position, transform.rotation) as GameObject;

        //    Rigidbody bulletRigidbody = instance.GetComponent<Rigidbody>();
        //    if (bulletRigidbody != null)
        //    {
        //        bulletRigidbody.AddForce(instance.transform.forward * bulletSpeed);
        //    }
        //}
    }

}
