using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSlectCtrl : MonoBehaviour
{
    [Header("フェード")] public FadeImage fade;

    private int stageNum;
    private bool firstPush = false;
    private bool goNextScene = false;

    //ステージボタンを押されたら呼ばれる
    public void SelectBt(int Stage)
    {
        //Debug.Log("Press Start!");
        if (!firstPush)
        {
            Debug.Log("Go Next Scene!");
            stageNum = Stage;
            fade.StartFadeOut();
            firstPush = true;
        }
    }

    private void Update()
    {
        if (!goNextScene && fade.IsFadeOutComplete())
        {
            SceneManager.LoadScene("Stage" + stageNum);
            goNextScene = true;
        }
    }
}