using UnityEngine;
using System.Collections;

public class ExplodeOnDestroy : MonoBehaviour {

    public GameObject Explosion;
    bool isQuitting;

    // Prevent Objects from strying in Hierarchy
    void OnApplicationQuit()
    {
        isQuitting = true;
    }
    void OnDestroy()
    {
        if (!isQuitting)
        {
            Instantiate(Explosion, this.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }       
}
