using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	NavMeshAgent nav;
	GameObject player;
	GameObject enemy;

	float distance;
	public int shootDistance = 100;

    BonusController bonusController;
    public int HighscorePoints;
	  // Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");

        bonusController = GameObject.FindGameObjectWithTag("GameController").GetComponent<BonusController>();

        Debug.Log (player);

		enemy = this.gameObject;

		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		double distance = Vector3.Distance(player.transform.position,enemy.transform.position);
        if (distance > shootDistance)
        {
            nav.SetDestination(player.transform.position);
        }
        else if (distance <= shootDistance)
        {
            nav.SetDestination(player.transform.position);
            if(this.GetComponent<EnemyShotController>() != null)
            {
                this.GetComponent<EnemyShotController>().enabled = true;
            }
        }
		nav.SetDestination(player.transform.position);
	}

    public void DestroyedByPlayer()
    {

        bonusController.showPoints();

        bonusController.spawnBonus(this.transform.position);

        Destroy(this.gameObject);
    }
}
