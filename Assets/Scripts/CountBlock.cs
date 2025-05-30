using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountBlock : MonoBehaviour
{
    [SerializeField]private GameObject CBUI;
    private Text blockCountText = null;
    [SerializeField] private int blockCount;
    private ObjectCollision oc = null;
    [SerializeField] private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        blockCountText = CBUI.transform.Find("countText").GetComponent<Text>();
        blockCountText.text = "" + blockCount;
        oc = GetComponent<ObjectCollision>();
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        if (oc.playerCollide)
        {
            blockCount--;

            if(blockCount == 0)
            {
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
    }*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            blockCount--;
            blockCountText.text = "" + blockCount;
            if (blockCount == 0)
            {
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
    }
}
