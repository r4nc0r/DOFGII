using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    GameObject Player;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
