using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCtrl : MonoBehaviour
{
    [Header("プレイヤーゲームオブジェクト")] public GameObject playerObj;
    [Header("コンティニュー位置")] public GameObject continuePoint;
    [Header("ゲームオーバー")] public GameObject gameOverObj;
    [Header("フェード")] public FadeImage fade;

    private PlayerControler p;
    private int nextStageNum;
    private bool startFade = false;
    private bool doGameOver = false;
    private bool retryGame = false;
    private bool goToSelect = false;
    private bool doSceneChange = false;

    // Start is called before the first frame update
    void Start()
    {
        if (playerObj != null && continuePoint != null && gameOverObj != null && fade != null)
        {
            gameOverObj.SetActive(false);
            playerObj.transform.position = continuePoint.transform.position;
            p = playerObj.GetComponent<PlayerControler>();
            if (p == null)
            {
                Debug.Log("プレイヤーじゃない物がアタッチされているよ！");
            }
        }
        else
        {
            Debug.Log("設定が足りてないよ！");
        }
    }



    // Update is called once per frame
    void Update()
    {
        //ゲームオーバー時の処理
        if (GManager.instance.isGameOver && !doGameOver)
        {
            gameOverObj.SetActive(true);
            doGameOver = true;
        }

        //ステージを切り替える
        if (fade != null && startFade && !doSceneChange)
        {
            if (fade.IsFadeOutComplete())
            {
                //ゲームリトライ
                if (retryGame || goToSelect)
                {
                    GManager.instance.RetryGame();
                }
                //次のステージ
                else
                {
                    GManager.instance.stageNum = nextStageNum;
                }

                if (nextStageNum == 0)
                {
                    SceneManager.LoadScene("StageSelect");
                }
                else
                {
                    SceneManager.LoadScene("stage" + nextStageNum);
                }
                
                doSceneChange = true;
            }
        }
    }

    /// <summary>
    /// 最初から始める
    /// </summary>
    public void Retry()
    {
        ChangeScene(GManager.instance.stageNum); //同じステージに戻るので
        retryGame = true;
        Debug.Log("retry"+ GManager.instance.stageNum);
    }

    /// <summary>
    /// ステージセレクトに戻る
    /// </summary>
    public void GoToSelect()
    {
        ChangeScene(0); //セレクト画面に戻るので0
        goToSelect = true;
        Debug.Log("select" + GManager.instance.stageNum);
    }

    /// <summary>
    /// ステージを切り替えます。
    /// </summary>
    /// <param name="num">ステージ番号</param>
    public void ChangeScene(int num)
    {
        if (fade != null)
        {
            nextStageNum = num;
            fade.StartFadeOut();
            startFade = true;
        }
    }
}