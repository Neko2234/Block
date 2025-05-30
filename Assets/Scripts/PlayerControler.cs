using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 startPos, currentPos, endPos;
    private string BlockTag = "Block";
    private string DamageBlockTag = "DamageBlock";
    private string WallTag = "Wall";
    [SerializeField] private ParticleSystem particle;

    //public Text text;
    public float playerSpeed = 10;
    public float topSpeed = 10;
    public float dec_speed = 0.995f;
    public float arrow_maltipler = 2;
    public float maxSize = 2;
    public float liftArrow = 200;
    public Transform arrow;
    [SerializeField] private AudioClip shotSE;
    [SerializeField] private AudioClip blockSE;
    [SerializeField] private AudioClip wallSE;
    [SerializeField] private AudioClip damageSE;
    [SerializeField] private AudioClip stopSE;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        SetArrowSize(0);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 force = Vector2.zero;
        if (GManager.instance.shotCount > 0)
        {
            if (Input.GetMouseButtonDown(0))// マウスを押した地点の座標を記録
            {
                startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0) && !GManager.instance.openingPanel)
            {
                
                currentPos = Input.mousePosition;
                Vector3 dir = (startPos - currentPos);

                if (dir.magnitude > liftArrow)
                {
                    //矢印の向きを決める処理
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    arrow.rotation = Quaternion.Euler(0, 0, angle);

                    //矢印の大きさを決める処理
                    float size = 0;
                    //Vector3 normal = dir.normalized;
                    size = Mathf.Sqrt(Mathf.Pow(dir.x, 2) + Mathf.Pow(dir.y, 2)) * arrow_maltipler;
                    SetArrowSize(size);
                }
                else
                {
                    SetArrowSize(0);
                }
            }
            else if (Input.GetMouseButtonUp(0) && !GManager.instance.openingPanel)// マウスを離した地点の座標から、発射方向を計算
            {
                endPos = Input.mousePosition;
                SetArrowSize(0);

                if ((startPos-endPos).magnitude > liftArrow)
                {
                    Vector2 launchDir = (startPos - endPos) / 10; //10分の1することで引っ張る距離による速度変化への影響を増やす
                    GManager.instance.PlaySE(shotSE);//ショットSE

                    if (Mathf.Sqrt(Mathf.Pow(launchDir.x, 2) + Mathf.Pow(launchDir.y, 2)) > topSpeed)//速度の上限を設定
                    {
                        this.rb.velocity = launchDir = launchDir.normalized * topSpeed * playerSpeed;
                    }
                    else
                    {
                        this.rb.velocity = launchDir * playerSpeed;//ボールの速度を直接操作
                    }
                    GManager.instance.isMove = true;

                    GManager.instance.SubShotCount(1);//弾数を減らす
                }
            }

            //スペースキー押下で停止
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                this.rb.velocity *= 0;
                GManager.instance.isMove = false;
            }*/
        }

        //スペースキー押下で停止
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GManager.instance.SubShotCount(1);//残機を減らす
            GManager.instance.PlaySE(stopSE);
            this.rb.velocity *= 0;
            GManager.instance.isMove = false;
        }
    }

    void FixedUpdate()
    {
        this.rb.velocity *= dec_speed;
        if (GManager.instance.isGameOver || GManager.instance.isGameClear)
        {
            this.rb.velocity *= 0;
            SetArrowSize(0);
            GManager.instance.shotCount = 0;

        }
    }

    void SetArrowSize(float size)
    {
        Transform image = arrow_image();
        if (size > maxSize)//サイズ上限を設定
        {
            image.localScale = new Vector3(maxSize, image.localScale.y, image.localScale.z);
        }
        else
        {
            image.localScale = new Vector3(size, image.localScale.y, image.localScale.z);
        }

    }

    Transform arrow_image()
    {
        return arrow.GetChild(0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == BlockTag || collision.collider.tag == DamageBlockTag)
        {
            ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
            if (o != null)
            {
                o.playerCollide = true;        //ぶつかったものに対してぶつかった事を通知する
            }
            else
            {
                Debug.Log("ObjectCollisionが付いてないよ!");
            }

            if (collision.collider.tag == BlockTag)
            {
                GManager.instance.PlaySE(blockSE);
            }
            else if(collision.collider.tag == DamageBlockTag)
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
                GManager.instance.PlaySE(damageSE);
            }
        }
        if(collision.collider.tag == WallTag)
        {
            GManager.instance.PlaySE(wallSE);
        }
    }
}
