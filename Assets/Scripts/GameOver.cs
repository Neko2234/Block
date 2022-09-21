using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        if (!GManager.instance.isMove)
        {
            Debug.Log("動いてる判定");
        }

        //shotCountが０かつブロックが残っていて、速度が0になったらゲームオーバー
        if (GManager.instance.shotCount == 0 && !GManager.instance.isMove && !GManager.instance.isGameClear)
        {
            Debug.Log("ゲームオーバー");
            GManager.instance.isGameOver = true;
        }
    }
}
