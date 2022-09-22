using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speedX = 10;
    public float speedY = 10;

    // Start is called before the first frame update
    void Start()
    {
        GManager.instance.isMove = false;

        rb = this.gameObject.GetComponent<Rigidbody2D>();

        Vector2 force = new Vector2(speedX, speedY);

        rb.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        // 速さが一定以下になったことを検知し、ボールを停止
        if (this.rb.velocity.magnitude < 1.0f && this.rb.velocity.magnitude != 0)
        {
            Debug.Log(this.rb.velocity.magnitude);
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GManager.instance.isMove = false;
        }

        if(this.rb.velocity.magnitude == 0)
        {
            GManager.instance.isMove = false;
        }
    }
}
