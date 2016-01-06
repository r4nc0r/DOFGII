using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WeaponBoltMover : MonoBehaviour
{
    // Game Logic related Variables:
    GameObject Player;
    public string TargetTag;

    // Balancing related Variables, these will be changed by the Object shooting the bolt:
    public int Damage;
    public float Speed;
    public float Spread;

    void Start()
    {
        // Initial Values:
        Rigidbody BoltRigidBody = GetComponent<Rigidbody>();
        Vector3 boltSpread = Random.insideUnitSphere * Spread;
        boltSpread.y = 0.0f;
        BoltRigidBody.velocity = (transform.forward + boltSpread) * Speed;
    }

    void OnTriggerEnter(Collider other)
    {
        // Differentiate whitch Gameobject got hit:
        if (other.gameObject.CompareTag("Enemy") && TargetTag == "Enemy")
        {
            other.GetComponent<EnemyMovement>().DestroyedByPlayer();
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Player") && TargetTag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(Damage);
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
