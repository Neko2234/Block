using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private bool doGameOver = false;
    [SerializeField] private AudioClip overSE;

    void Update()
    {
        //shotCountが０かつブロックが残っていて、速度が0になったらゲームオーバー
        if (!doGameOver && GManager.instance.shotCount == 0 && !GManager.instance.isMove && !GManager.instance.isGameClear)
        {
            //Debug.Log("ゲームオーバー");
            GManager.instance.PlaySE(overSE);
            GManager.instance.isGameOver = true;
            doGameOver = true;
        }
    }
}
