using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	NavMeshAgent nav;
	GameObject player;
	

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination(player.transform.position);
	}
}
