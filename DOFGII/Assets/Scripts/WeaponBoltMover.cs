using UnityEngine;
using System.Collections;

public class WeaponBoltMover : MonoBehaviour
{
    public float Speed;
    public float Spread;

    void Start()
    {
        Rigidbody BoltRigidBody = GetComponent<Rigidbody>();
        Vector3 boltSpread = Random.insideUnitSphere * Spread;
        boltSpread.y = 0.0f;
        BoltRigidBody.velocity = (transform.forward + boltSpread) * Speed;
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Pick Up"))
        //{
        //    Destroy(other.gameObject);

        //    Destroy(this.gameObject);
        //}
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            Destroy(this.gameObject);
        }
    }
}
