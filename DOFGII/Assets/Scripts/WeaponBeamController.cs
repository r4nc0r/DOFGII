using UnityEngine;
using System.Collections;

public class WeaponBeamController : MonoBehaviour
{
    // Variables for GameLogic and Renderer: 
    RaycastHit hit;

    LineRenderer LineRender;

    public GameObject Shooter;

    string TargetTag;

    float spawntime;

    // Balancing Variables:
    public int DamagePerSecond;

    public float FiringTime;

    public float CooldownTime;

    public float Range;

    void Start()
    {
        // Initialization Values:
        spawntime = Time.time;
        
        LineRender = GetComponent<LineRenderer>();

        // add Beam to Hierarchy:
        Transform Spawnpoint = Shooter.transform.FindChild("ShotSpawn");

        this.transform.parent = Spawnpoint;
    }


    void FixedUpdate()
    {
        // Destroy Beam parrent object When firing Time is over:
        if (Time.time >= spawntime + FiringTime)
        {
            Destroy(this.gameObject);
        }

        // Collider related Game Logic:
        bool hitting = Physics.Raycast(transform.position, transform.forward, out hit, Range);

        if (hitting && hit.collider.CompareTag("Enemy"))
        {
            hit.collider.GetComponent<EnemyMovement>().DestroyedByPlayer();
        }
        else if (hitting && hit.collider.CompareTag("Player"))
        {
            hit.collider.GetComponent<PlayerHealth>().TakeDamage(DamagePerSecond);
        }

        // Setting positions for next rendering call:
        LineRender.SetPosition(0, transform.position - transform.forward);
        if (hitting)
        {
            LineRender.SetPosition(1, hit.point);
        }
        else
        {
            LineRender.SetPosition(1, transform.position + transform.forward * Range);
        }
    }
}
