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
    [HideInInspector] public bool openingPanel = false;

    private AudioSource audioSource = null;

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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    public void Death()
    {
        isGameOver = true;
    }

    /// <summary>
    /// 最初から始める時の処理
    /// </summary>
    public void RetryGame()
    {
        isGameOver = false;
        isGameClear = false;
        isMove = false;
        shotCount = defaultShotCount;
        openingPanel = false;
        //stageNum = 1;
    }

    /// <summary>
    /// SEを鳴らす
    /// </summary>
    public void PlaySE(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("オーディオソースが設定されていません");
        }
    }
}
