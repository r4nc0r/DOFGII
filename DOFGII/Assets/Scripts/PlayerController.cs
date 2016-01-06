using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Movement related Variables
    [Range(1, 50)]
    public float forwardSpeed;
    [Range(1, 50)]
    public float straveSpeed;
    [Range(.1f, 10)]
    public int turnSpeed;
    Rigidbody playerRigidbody;

    // Weapon related Variables:
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float NextShot;
    public Image WeaponImage;
    public AudioClip shotAudio;
    private Weapon currentWeapon;

    // Highscore and Money:
    public int PlayerMoney { get; set; }
    public int PlayerPoints { get; set; }

    void Start()
    {
        // Initialize Game Logic variables:
        Cursor.visible = false;
        playerRigidbody = GetComponent<Rigidbody>();
        currentWeapon = SceneBuffer.PlayerWeapon;
        checkWeapon();
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
            
            GameObject newShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation ) as GameObject;
            AudioSource.PlayClipAtPoint(shotAudio, playerRigidbody.transform.position);

            // Overload Shot values:
            newShot.GetComponent<WeaponBoltMover>().Speed = (float) currentWeapon.ProjectileSpeed;
            newShot.GetComponent<WeaponBoltMover>().Spread = (float)currentWeapon.Spread;
            newShot.GetComponent<WeaponBoltMover>().TargetTag = "Enemy";

        }
    }

    /// <summary>
    /// Chek if the player has a Weapon if not give player the standard weapon
    /// </summary>
    void checkWeapon()
    {
        if (currentWeapon != null)
        {
            WeaponImage.sprite = currentWeapon.WeaponSprite;
            shot = currentWeapon.Bolt;
        }
        else
        {
            currentWeapon = new Weapon();
            currentWeapon.FireRate = 1;
            currentWeapon.ProjectileSpeed = 22;
            currentWeapon.Spread = 0;
            currentWeapon.Bolt = shot;
        }
        fireRate = (float)currentWeapon.FireRate;
    }
}

