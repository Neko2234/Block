using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text gameOverMessage;
    [SerializeField] private Rigidbody2D player_rb;//プレイヤーのRigidBodyを取得

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GManager.instance.shotCount == 0 && player_rb.velocity == new Vector2 (0,0) && !GManager.instance.isGameClear)
        {
            Debug.Log("ゲームオーバー");
            // Game Overと表示する
            GManager.instance.isGameOver = true;
        }
    }
}
