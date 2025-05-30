using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBlock : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [Header("鍵")] public PlayerTriggerCheck playerCheck;

    public AudioClip keySE;

    void FixedUpdate()
    {
        //プレイヤーが判定内に入ったら
        if (playerCheck.isOn)
        {
            GManager.instance.PlaySE(keySE);
            // パーティクルシステムのインスタンスを生成する。
            ParticleSystem newParticle = Instantiate(particle);
            // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
            newParticle.transform.position = this.transform.position;
            // パーティクルを発生させる。
            newParticle.Play();
            // インスタンス化したパーティクルシステムのGameObjectを削除する。(任意)
            // ※第一引数をnewParticleだけにするとコンポーネントしか削除されない。
            Destroy(this.gameObject);
        }
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            Destroy(this.gameObject);
        }
    }*/
}
