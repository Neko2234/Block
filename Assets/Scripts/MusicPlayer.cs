using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;

    /*public void OnClickPlay()
    {
        // オーディオを再生します
        AudioSource.Play();
    }

    public void OnClickPause()
    {
        // オーディオを一時停止します
        AudioSource.Pause();
    }

    public void OnClickStop()
    {
        // オーディオを停止します
        AudioSource.Stop();
    }*/

    void Update()
    {
        if (GManager.instance.isGameOver || GManager.instance.isGameClear)
        {
            // オーディオを停止します
            AudioSource.Stop();
        }
    }
}
