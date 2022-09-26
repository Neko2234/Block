using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    private ObjectCollision oc = null;

    // Start is called before the first frame update
    void Start()
    {
        oc = GetComponent<ObjectCollision>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (oc.playerCollide)
        {
            GManager.instance.Death();
        }
    }
}