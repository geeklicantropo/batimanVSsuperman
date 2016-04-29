using UnityEngine;
using System.Collections;

public class Shooter2 : MonoBehaviour
{
    public Transform laser;
    public Transform spark;

    //public Player superman;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.End))
        {
            Instantiate(laser, transform.position, Quaternion.identity);
            Instantiate(spark, transform.position, Quaternion.identity);
        }
        Destroy(GameObject.Find("spark(Clone)"), 0.5f);
    }
}

