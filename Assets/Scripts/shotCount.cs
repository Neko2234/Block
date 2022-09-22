using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shotCount : MonoBehaviour
{
    private Text shotCountText = null;
    private int oldShotCount = 0;
    private PlayerControler player;

    // Start is called before the first frame update
    void Start()
    {
        shotCountText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            shotCountText.text = ""+GManager.instance.shotCount;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れてるよ！");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(oldShotCount != GManager.instance.shotCount)
        {
            shotCountText.text = ""+GManager.instance.shotCount;
            oldShotCount = GManager.instance.shotCount;
        }

        //ゲームオーバーを表示
        if(GManager.instance.isGameOver)
        {
            shotCountText.text = "";
        }

        //ゲームクリアを表示
        if (GManager.instance.isGameClear)
        {
            shotCountText.text = "";
        }
    }
}
