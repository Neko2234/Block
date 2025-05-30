using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCtrl : MonoBehaviour
{
    [Header("このステージのデフォルトの弾数")] public int thisStage_defaultShotCount;
    [Header("このステージ")] public int thisStageNum;
    [Header("プレイヤーゲームオブジェクト")] public GameObject playerObj;
    [Header("コンティニュー位置")] public GameObject continuePoint;
    [Header("ゲームオーバー")] public GameObject gameOverObj;
    [Header("ゲームクリア")] public GameObject gameClearObj;
    [Header("フェード")] public FadeImage fade;
    [SerializeField] private AudioClip buttonSE;

    private PlayerControler p;
    private int nextStageNum;
    private bool startFade = false;
    private bool doGameOver = false;
    private bool doGameClear = false;
    private bool retryGame = false;
    private bool goToSelect = false;
    private bool doSceneChange = false;

    // Start is called before the first frame update
    void Start()
    {
        if (thisStage_defaultShotCount == 0)
        {
            Debug.Log("初期弾数が設定されてない！");
        }
        GManager.instance.shotCount = thisStage_defaultShotCount;
        GManager.instance.defaultShotCount = thisStage_defaultShotCount;
        GManager.instance.stageNum = thisStageNum;

        doGameOver = false;
        doGameClear = false;
        if (playerObj != null && continuePoint != null && gameOverObj != null && gameClearObj != null && fade != null)
        {
            gameOverObj.SetActive(false);
            gameClearObj.SetActive(false);
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
        //Debug.Log(GManager.instance.shotCount);
        //ゲームオーバー時の処理
        if (GManager.instance.isGameOver && !doGameOver)
        {
            gameOverObj.SetActive(true);
            doGameOver = true;
        }

        //ゲームクリア時の処理
        if (GManager.instance.isGameClear && !doGameClear)
        {
            gameClearObj.SetActive(true);
            doGameClear = true;

            //次のステージを開放
            //PlayerPrefsのSCOREに次のステージ番号を入れる
            if (PlayerPrefs.GetInt("SCORE") <= thisStageNum)
            {
                PlayerPrefs.SetInt("SCORE", thisStageNum + 1);
                //PlayerPrefsをセーブする         
                PlayerPrefs.Save();
                Debug.Log(thisStageNum + 1);
            }
        }

        //ステージを切り替える
        if (fade != null && startFade && !doSceneChange)
        {
            if (fade.IsFadeOutComplete())
            {
                //ゲームリトライ
                if (retryGame || goToSelect)
                {
                    //GManager.instance.shotCount = thisStage_defaultShotCount;
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
        GManager.instance.PlaySE(buttonSE);
        if (fade != null)
        {
            nextStageNum = num;
            fade.StartFadeOut();
            startFade = true;
        }
    }
}