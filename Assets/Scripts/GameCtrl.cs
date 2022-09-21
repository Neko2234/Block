using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    [Header("このステージのデフォルトの弾数")] public int thisStage_defaultShotCount;
    [Header("このステージ")] public int thisStageNum;

    void Start()
    {
        if(thisStage_defaultShotCount == 0)
        {
            Debug.Log("初期弾数が設定されてない！");
        }
        thisStage_defaultShotCount = GManager.instance.defaultShotCount;
        thisStageNum = GManager.instance.stageNum;
    }
}