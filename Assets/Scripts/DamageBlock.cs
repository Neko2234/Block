using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBlock : MonoBehaviour
{
    public int DamageCount = 1;
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
            GManager.instance.SubShotCount(DamageCount);
            Destroy(this.gameObject);
        }
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            GManager.instance.shotCount -= DamageCount;
            
            Destroy(this.gameObject);
        }
    }*/
}