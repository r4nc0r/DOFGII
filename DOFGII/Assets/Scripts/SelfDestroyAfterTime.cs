using UnityEngine;
using System.Collections;

public class SelfDestroyAfterTime : MonoBehaviour {
    public float TimeToDestroy = 1f;
	void Start () {
        Destroy(this, TimeToDestroy);
	}
}
