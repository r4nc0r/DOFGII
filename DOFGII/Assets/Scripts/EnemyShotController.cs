using UnityEngine;
using System.Collections;

public class EnemyShotController : MonoBehaviour {
    // Game Logic related Variables:
    public GameObject shot;
    public AudioClip shotEnemy;

    // Balance related Variables:
    public int ShotDamage;
    public float FireRate;
    public float ShotSpeed;
    public float ShotSpread;
    public float NextShot;
    	
    void Start()
    {
        NextShot = NextShot + Random.Range(0.0f, 2);
    }
	
	void Update ()
    {
	    if (NextShot <= Time.time)
        {
            Shoot();
        }
	}
    /// <summary>
    /// Controling weapon
    /// </summary>
    void Shoot()
    {
        // initialize Shot:
        NextShot = Time.time + FireRate;

        GameObject newShot = Instantiate(shot, this.transform.position + this.transform.forward, this.transform.rotation) as GameObject;

        AudioSource.PlayClipAtPoint(shotEnemy, this.transform.position);

        // overload Shot values:
        newShot.GetComponent<WeaponBoltMover>().Damage = ShotDamage;

        newShot.GetComponent<WeaponBoltMover>().Speed = ShotSpeed;

        newShot.GetComponent<WeaponBoltMover>().Spread = ShotSpread;

        newShot.GetComponent<WeaponBoltMover>().TargetTag = "Player";
    }
}
