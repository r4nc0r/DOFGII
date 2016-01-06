using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	NavMeshAgent nav;
	GameObject player;
	GameObject enemy;
    public GameObject Explosion;

	float distance;
	public int shootDistance = 100;

    BonusController bonusController;
    public int HighscorePoints;
	  // Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
        bonusController = GameObject.FindGameObjectWithTag("GameController").GetComponent<BonusController>();
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
        Color color = new Color(this.GetComponentInChildren<Renderer>().material.GetColor("_Color").r, this.GetComponentInChildren<Renderer>().material.GetColor("_Color").g, this.GetComponentInChildren<Renderer>().material.GetColor("_Color").b, 0.5f);
        Destroy(this.gameObject);
        GameObject explosion = (GameObject)Instantiate(Explosion, this.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().startColor = color;
    }
}
