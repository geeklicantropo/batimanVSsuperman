using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

    public GameObject shot;
    public float bulletSpeed;
    public KeyCode shootKey;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        //if(dir != Vector3.zero)
        //{
        //    transform.forward = Vector3.Normalize(dir);
        //}        

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            RaycastHit tiro = new RaycastHit();

            if (Physics.Raycast(transform.position, transform.forward, out tiro))
            {
                if(tiro.collider.tag == "Superman")
                {
                    tiro.collider.gameObject.SetActive(false);
                }
            }
        }


        if (Input.GetKeyDown(shootKey))
        {
            GameObject instance = Instantiate(shot, transform.position, transform.rotation) as GameObject;

            Rigidbody bulletRigidbody = instance.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.AddForce(instance.transform.forward * bulletSpeed);
            }
        }
    }

}
