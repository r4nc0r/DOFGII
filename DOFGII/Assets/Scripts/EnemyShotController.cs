using UnityEngine;
using System.Collections;

public class EnemyShotController : MonoBehaviour {
    public GameObject shot;
    public int ShotDamage;
    public float FireRate;
    public float ShotSpeed;
    public float ShotSpread;
    public float NextShot;
	
    void Start()
    {
        NextShot = NextShot + Random.Range(0.0f, 2);
    }
	// Update is called once per frame
	void Update ()
    {
	    if (NextShot <= Time.time)
        {
            Shoot();
        }
	}
    /// <summary>
    /// Controll weapons
    /// </summary>
    void Shoot()
    {
        // initialize Shot
        NextShot = Time.time + FireRate;

        GameObject newShot = Instantiate(shot, this.transform.position + this.transform.forward, this.transform.rotation) as GameObject;

        // overload Shot values:
        newShot.GetComponent<WeaponBoltMover>().Damage = ShotDamage;

        newShot.GetComponent<WeaponBoltMover>().Speed = ShotSpeed;

        newShot.GetComponent<WeaponBoltMover>().Spread = ShotSpread;

        newShot.GetComponent<WeaponBoltMover>().TargetTag = "Player";

    }
}
