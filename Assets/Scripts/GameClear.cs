using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public Text gameClearMessage;
    Transform myTransform;

    void Start()
    {
        // Transformコンポーネントを保持しておく
        myTransform = transform;
    }

    void Update()
    {
        // 子供がいなくなったらisGameClearフラグを立てる
        if (myTransform.childCount == 0)
        {
            GManager.instance.isGameClear = true;
        }
    }
}
