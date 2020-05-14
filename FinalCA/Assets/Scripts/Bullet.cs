using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed;

    public void SetDirection(Vector3 direction)
    {
        GetComponent<Rigidbody>().velocity = direction.normalized * speed;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
