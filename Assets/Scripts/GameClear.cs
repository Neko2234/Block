using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    private bool doGameClear = false;
    Transform myTransform;

    void Start()
    {
        // Transformコンポーネントを保持しておく
        myTransform = transform;
    }

    void Update()
    {
        // 子供がいなくなったらisGameClearフラグを立てる
        if (myTransform.childCount == 0 && !doGameClear)
        {
            GManager.instance.isGameClear = true;
            doGameClear = true;
        }
    }
}
