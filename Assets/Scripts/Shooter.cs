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
        if (Input.GetKeyUp(shootKey))
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
