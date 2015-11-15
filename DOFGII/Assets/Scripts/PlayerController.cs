using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Movement related Variables
    public float forwardSpeed;
    public float straveSpeed;
    public int turnSpeed;
    Rigidbody playerRigidbody;

    // Weapon related Variables:
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float NextShot;
    void Start()
    {
        // Initialize Game Logic variables:
        playerRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        fireWeapon();
    }
    void FixedUpdate()
    {
        movePlayer();
    }
    /// <summary>
    /// Gets Movement Input Values for Player and Controlls Movement
    /// </summary>
    void movePlayer()
    {
        // Get input Values:
        float moveForward = Input.GetAxis("Vertical");

        float moveStrave = Input.GetAxis("Horizontal");

        float turning = Input.GetAxis("Turning");

        // Move Playerobject:
        transform.RotateAround(transform.position, new Vector3(0, 1, 0), turning * turnSpeed);

        Vector3 Strave = this.gameObject.transform.right * moveStrave * straveSpeed;

        Vector3 Forward = this.gameObject.transform.forward * moveForward * forwardSpeed;

        playerRigidbody.velocity = Strave + Forward;
    }
    /// <summary>
    /// Controlls firing of current equipped Weapon
    /// </summary>
    void fireWeapon()
    {
        // Check for Weapon Activation and Execute if True:
        if (Input.GetButton("Fire1") && NextShot <= Time.time)
        {
            NextShot = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
    /// <summary>
    /// Collision Detection
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Pick Up"))
        //{
        //    Destroy(other.gameObject);
        //}
    }
}

