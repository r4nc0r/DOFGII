using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    public Image WeaponImage;

    private Weapon currentWeapon;
    void Start()
    {
        // Initialize Game Logic variables:
        playerRigidbody = GetComponent<Rigidbody>();
        currentWeapon = Inventory.CurrentWeapon;
        if (currentWeapon != null)
        {
            WeaponImage.sprite = currentWeapon.WeaponSprite;
        }
        else
        {
            currentWeapon = new Weapon();
            currentWeapon.FireRate = 1;
            currentWeapon.ProjectileSpeed = 22;
            currentWeapon.Spread = 0;
        }
        fireRate = (float)currentWeapon.FireRate;
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
    /// Controlls firing of currently equipped Weapon
    /// </summary>
    void fireWeapon()
    {
        // Check for Weapon Activation and activate Weapon if True:
        if (Input.GetButton("Fire1") && NextShot <= Time.time)
        {
            // Initialize Shot:
            NextShot = Time.time + fireRate;

            GameObject newShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;

            // Overload Shot values:
            newShot.GetComponent<WeaponBoltMover>().Speed = (float) currentWeapon.ProjectileSpeed;

            newShot.GetComponent<WeaponBoltMover>().Spread = (float)currentWeapon.Spread;

            newShot.GetComponent<WeaponBoltMover>().TargetTag = "Enemy";
        }
    }
    /// <summary>
    /// Collision Detection
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        
    }
}

