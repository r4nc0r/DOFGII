using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	//public GameObject Enemy1;
	public int Enemy1Count;
	public int Enemy1OriginBegin;
	public int Enemy1OriginWidth;

	public GameObject Enemy2;
	public int Enemy2Count;
	public int Enemy2OriginBegin;
	public int Enemy2OriginWidth;

	//public GameObject Enemy3;
	public int Enemy3Count;
	public int Enemy3OriginBegin;
	public int Enemy3OriginWidth;

	public GameObject Boundary;
	float distance;

	GameObject player;
    BonusController bonusController;
    PlayerController playercontroller;
    public GameObject[] EnemyArray;
    private static int level;
    private const int levelPoints = 15;
    public Text LevelText;

    public Material[] Skyboxes;

    MaterialPropertyBlock mat;
    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
        level++;
        RenderSettings.skybox = Skyboxes[(int)Random.Range(0, 3)];

        LevelText.text = "Level " + level.ToString();
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        bonusController = GameObject.FindGameObjectWithTag("BonusController").GetComponent<BonusController>();
        distance = Boundary.transform.localScale.x;
        player = GameObject.FindGameObjectWithTag("Player");
        playercontroller.PlayerMoney = SceneBuffer.PlayerMoney;
        playercontroller.PlayerPoints = SceneBuffer.PlayerPoints;

    }

	// Use this for initialization
	void Start () {
        for (int i = 0; i < Enemy1Count*level; i++) {
            SpawnEnemy(EnemyArray[0], Enemy1OriginBegin,Enemy1OriginWidth);
		}
		for (int i = 0; i < Enemy2Count * level; i++) {
			SpawnEnemy(EnemyArray[1], Enemy2OriginBegin,Enemy2OriginWidth);
		}
		for (int i = 0; i < Enemy3Count * level; i++) {
			SpawnEnemy(EnemyArray[2], Enemy3OriginBegin,Enemy3OriginWidth);
		}
	}

	// Update is called once per frame
	void Update ()
    {
        
        if (playercontroller.PlayerPoints>=levelPoints*level)
        {
            SceneBuffer.PlayerMoney = playercontroller.PlayerMoney;
            SceneBuffer.PlayerPoints = playercontroller.PlayerPoints;
            Application.LoadLevel("Shop");
        }
        //Wenn weniger als angegeben dann wird ein Random Enemy auf der Boundary um den Spieler erstellt
        if(GameObject.FindGameObjectsWithTag("Enemy").Length<5)
        {
            int randomEnemy = Random.Range(0, 3);
            switch (randomEnemy)
            {
                case 0:
                   SpawnEnemy(EnemyArray[randomEnemy], Enemy1OriginBegin, Enemy1OriginWidth);
                    break;
                case 1:
                    SpawnEnemy(EnemyArray[randomEnemy], Enemy2OriginBegin, Enemy2OriginWidth);
                    break;
                case 2:
                    SpawnEnemy(EnemyArray[randomEnemy], Enemy3OriginBegin, Enemy3OriginWidth);
                    break;
            }
            
        }
	}
	Vector3 spawnPointTemp;
	/// <summary>
	/// Spawns the enemies.
	/// </summary>
	void SpawnEnemy(GameObject enemy, int offset, int width)
	{
		int i = Random.Range(offset,offset+width);
		spawnPointTemp.x = Mathf.Cos (Mathf.Deg2Rad*i) * (distance / 2) + player.transform.position.x;
        spawnPointTemp.y = 1;
		spawnPointTemp.z = Mathf.Sin (Mathf.Deg2Rad*i) * (distance / 2) + player.transform.position.z;
		Instantiate(enemy, spawnPointTemp , Quaternion.identity);
	}
}
