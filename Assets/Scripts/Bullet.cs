using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
    }
}
