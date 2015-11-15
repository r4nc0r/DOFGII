using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	NavMeshAgent nav;
	GameObject player;
	GameObject enemy;
	float distance;
	public int shootDistance = 100;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		Debug.Log (player);
		enemy = this.gameObject;
		nav = GetComponent<NavMeshAgent> ();
	}

	void Shoot()
	{
		Debug.Log (this.gameObject+" :Shoot");
//		NextShot = Time.time + fireRate;
//		shotPosition = new Vector3(enemy.position.x,enemy.position.y+3,enemy.position.z);
//		Instantiate(shot, shotPosition, enemy.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		double distance = Vector3.Distance(player.transform.position,enemy.transform.position);
		if (distance > shootDistance) {
			nav.SetDestination (player.transform.position);
		}
		else if (distance  <= shootDistance) {
			nav.SetDestination (player.transform.position);
			Shoot();

		} 
		else {

		}

		nav.SetDestination(player.transform.position);
	}
}
