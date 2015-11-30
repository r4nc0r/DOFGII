using UnityEngine;
using System.Collections;

public class BoundaryController : MonoBehaviour
{
    GameObject Player;
    private Vector3 offset;
    private Vector3 Pos = new Vector3();
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - Player.transform.position;
    }
    
    void Update()
    {
        transform.position = Player.transform.position + offset;
        Pos = this.transform.position;
    }
}
