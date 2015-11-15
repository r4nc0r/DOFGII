using UnityEngine;
using System.Collections;

public class BondaryController : MonoBehaviour
{
    GameObject Player;
    public GameObject Boundary;
    private Vector3 offset;
    private Vector3 Pos = new Vector3();
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + offset;
        Pos = Boundary.transform.position;
    }

    //void SpawnPickUps()
    //{
    //    if (GameObject.FindGameObjectsWithTag("Pick Up").Length < 15)
    //    {
    //        Vector3 spawnPosition = new Vector3(Random.Range(-Pos.x + 40, Pos.x + 40), 1, Random.Range(-Pos.z + 40, Pos.z + 40));
    //        Quaternion rotation = Quaternion.identity;
    //        Instantiate(pickUps, spawnPosition, rotation);
    //    }
    //}
}
