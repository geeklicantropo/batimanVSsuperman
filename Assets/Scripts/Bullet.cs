﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    private Rigidbody myRigidBody;
    public Transform pontoDeImpacto;

    private healthSuperman damg;
    [SerializeField]
    private int bulletDamage;
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
        Destroy(gameObject, 1f);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    Destroy(this.gameObject);
    //    if (other.tag == "Superman")
    //    {

    //        Instantiate(pontoDeImpacto, transform.position, Quaternion.identity);
    //        other.gameObject.SetActive(false);            
    //    }

    //}

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

    //void OnTriggerStay(Collider other)
    //{
    //    //Destroy(this.gameObject);
    //    if (other.tag == "Superman" && Timer < Time.time)
    //    {
    //        damg.Damage(bulletDamage);
    //        Timer = Time.time + 0.5f;
    //    }
    //}
}
