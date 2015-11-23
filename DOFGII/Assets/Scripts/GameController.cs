using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject Enemy1;
	public int Enemy1Count;
	public int Enemy1OriginBegin;
	public int Enemy1OriginWidth;

	public GameObject Enemy2;
	public int Enemy2Count;
	public int Enemy2OriginBegin;
	public int Enemy2OriginWidth;

	public GameObject Enemy3;
	public int Enemy3Count;
	public int Enemy3OriginBegin;
	public int Enemy3OriginWidth;

	public GameObject Boundary;
	public GameObject Player;
	float distance;

    PlayerController playercontroller;
    private static int counter;
    


	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		distance = 50;//Vector3.Distance (Player.transform.position, Boundary.transform.position);

	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < Enemy1Count; i++) {
			SpawnEnemy(Enemy1, Enemy1Count, Enemy1OriginBegin,Enemy1OriginWidth);
		}
		for (int i = 0; i < Enemy2Count; i++) {
			SpawnEnemy(Enemy2, Enemy2Count, Enemy2OriginBegin,Enemy2OriginWidth);
		}
		for (int i = 0; i < Enemy3Count; i++) {
			SpawnEnemy(Enemy3, Enemy3Count, Enemy3OriginBegin,Enemy3OriginWidth);
		}
	}

	// Update is called once per frame
	void Update () {
        if (playercontroller.PlayerPoints>=15)
        {
            Application.LoadLevel("Shop");
        }
	}
	Vector3 spawnPointTemp;
	/// <summary>
	/// Spawns the enemies.
	/// </summary>
	void SpawnEnemy(GameObject enemy, int enemyCount, int offset, int width)
	{
		int i = Random.Range(offset,offset+width);
		spawnPointTemp.x = Mathf.Cos (Mathf.Deg2Rad*i) * (distance / 2);
        spawnPointTemp.y = 1;
		spawnPointTemp.z = Mathf.Sin (Mathf.Deg2Rad*i) * (distance / 2);
		Instantiate(enemy, spawnPointTemp , Quaternion.identity);
	}

    public static void SetCounter(int value)
    {
        counter+=value;
        
    }
}
