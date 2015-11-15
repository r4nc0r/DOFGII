using UnityEngine;
using System.Collections;

public class EnemyBoltMover : MonoBehaviour
{
    public float Speed;
    public float Spread;
    PlayerHealth health;
    GameObject player;
    public int damage;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
        Rigidbody BoltRigidBody = GetComponent<Rigidbody>();
        Vector3 boltSpread = Random.insideUnitSphere * Spread;
        boltSpread.y = 0.0f;
        BoltRigidBody.velocity = (transform.forward + boltSpread) * Speed;
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == player.tag)
        {
            health.TakeDamage(damage);

            Destroy(this.gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            Destroy(this.gameObject);
        }
    }
}
