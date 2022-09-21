using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    [Header("現在の弾数")] public int shotCount;
    [Header("デフォルトの弾数")] public int defaultShotCount;
    [Header("現在のステージ")] public int stageNum;
    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public bool isGameClear = false;
    [HideInInspector] public bool isMove = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddShotCount()
    {
        if (shotCount < 99)
        {
            ++shotCount;
        }
    }

    public void SubShotCount(int damage)
    {
        if(shotCount > damage)
        {
            shotCount -= damage;
        }
        else
        {
            shotCount = 0;
        }
    }

    /// <summary>
    /// 最初から始める時の処理
    /// </summary>
    public void RetryGame()
    {
        isGameOver = false;
        isMove = false;
        shotCount = defaultShotCount;
        stageNum = 1;
    }
}
