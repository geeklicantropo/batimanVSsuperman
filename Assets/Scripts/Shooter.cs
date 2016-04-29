using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

    public Transform bala;
    public Transform faisca;
    //public Transform pontoDeImpacto;


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

            //    RaycastHit tiro = new RaycastHit();

            //    if(Physics.Raycast(transform.position, transform.forward, out tiro))
            //    {
            //        if (tiro.== "Superman")
            //        {
            //            Instantiate(pontoDeImpacto, bala.collider.gameObject.transform.position, Quaternion.identity);
            //            bala.collider.gameObject.SetActive(false);


            //        }
            //    }
            //}
            //Destroy(GameObject.Find("pontoDeImpacto(Clone)"), 1.0f);
            
        }
        Destroy(GameObject.Find("faisca(Clone)"), 0.5f);





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

