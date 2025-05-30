using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageAdm : MonoBehaviour
{

    public int stage_num; // スコア変数
    public GameObject ni;
    public GameObject san;
    public GameObject yon;
    public GameObject go;
    public GameObject roku;
    public GameObject nana;
    public GameObject hachi;
    public GameObject clearText;

    // Use this for initialization
    void Start()
    {
        //現在のstage_numを呼び出す
        stage_num = PlayerPrefs.GetInt("SCORE", 0);
        Debug.Log(stage_num);
    }

    // Update is called once per frame
    void Update()
    {
        //デバッグ用　上キーでデータ削除
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerPrefs.DeleteKey("SCORE");
        }

        //stage_numが２以上のとき、ステージ２を解放する。以下同様
        if (stage_num >= 2)
        {
            ni.SetActive(true);
        }

        if (stage_num >= 3)
        {
            san.SetActive(true);
        }

        if (stage_num >= 4)
        {
            yon.SetActive(true);
        }

        if (stage_num >= 5)
        {
            go.SetActive(true);
        }

        if (stage_num >= 6)
        {
            roku.SetActive(true);
        }

        if (stage_num >= 7)
        {
            nana.SetActive(true);
        }

        if (stage_num >= 8)
        {
            hachi.SetActive(true);
        }

        if (stage_num >= 9)
        {
            clearText.SetActive(true);
        }
    }
}