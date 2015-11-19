using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WeaponBoltMover : MonoBehaviour
{
    public float Speed;

    public float Spread;

    public string TargetTag;

    public int Damage;

    GameObject Player;

    void Start()
    {
        // Initial Values:
        Rigidbody BoltRigidBody = GetComponent<Rigidbody>();

        Vector3 boltSpread = Random.insideUnitSphere * Spread;

        boltSpread.y = 0.0f;

        BoltRigidBody.velocity = (transform.forward + boltSpread) * Speed;

        //Damage = 1;

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        // Differentiate hitted Gameobject:
        if (other.gameObject.CompareTag("Enemy") && TargetTag == "Enemy")
        {
            other.GetComponent<EnemyMovement>().DestroyedByPlayer();

            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Player") && TargetTag == "Player")
        {
            Player.GetComponent<PlayerHealth>().TakeDamage(Damage);

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
