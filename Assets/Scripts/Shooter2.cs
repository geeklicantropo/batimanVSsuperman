using UnityEngine;
using XboxCtrlrInput;
using System.Collections;

public class Shooter2 : MonoBehaviour
{
    public Transform laser;
    public Transform spark;
    public XboxController controller;

    //public Player superman;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (XCI.GetButtonDown(XboxButton.RightBumper, controller))
        {
            Instantiate(laser, transform.position, Quaternion.Euler(0,90,90));
            Instantiate(spark, transform.position, Quaternion.identity);
        }
        Destroy(GameObject.Find("spark(Clone)"), 0.5f);
        Destroy(GameObject.Find("pontoDeImpactoBatman(Clone)"), 1.0f);
    }
}

