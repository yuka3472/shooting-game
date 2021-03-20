using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyController : MonoBehaviour
{
    public float dropSpeed = -0.03f;        //落下スピード
    private bool isWalk = false;            
    Renderer targetRenderer;
    Rigidbody2D rigid2D;
    GameObject player;
    GameObject director;
    

    // Start is called before the first frame update
    void Start()
    {
        
        targetRenderer = GetComponent<Renderer>();
        rigid2D = GetComponent<Rigidbody2D>();
        this.player = GameObject.Find("player");
        this.director = GameObject.Find("GameDirector");


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //mouseが落下中かの判断
        if (other.gameObject.CompareTag("Floor"))
        {
            isWalk = true;
        }

        //スターに当たったら、GameDirectorのGetMouse関数を呼び出しオブジェクトを消す
        if (other.gameObject.CompareTag("Star"))
        {

            this.director.GetComponent<GameDirector>().GetMouse();
            Destroy(gameObject);
            
        }
        //catに当たったら、object消去
        if(other.gameObject.CompareTag("cat"))
        {
            Destroy(gameObject);
        }
        //playerに当たったら、gameoversceneへ移動
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOverScene");
        }

        



    }

    // Update is called once per frame
    void Update()
    {

        
        //床の上にいる時
        if (isWalk == true)
        {
            //画面上に見えている時
            if (targetRenderer.isVisible)
            {
                //playerの向きに移動させる
                //playerの位置を取得
                Vector2 targetPos = player.transform.position;
                //playerのx座標を取得
                float x = targetPos.x;
                //y座標は常に0
                float y = 0;
                //移動を計算
                Vector2 direction = new Vector2(
                    x - transform.position.x, y).normalized;
                
                //移動速度
                rigid2D.velocity = direction * 2;

                Vector3 scale = transform.localScale;
                if (rigid2D.velocity.x > 1)         // 右方向に動いている
                    scale.x = -0.05f;               // 通常方向(スプライトと同じ右向き)
                else if (rigid2D.velocity.x < -1)   // 左方向に動いている
                    scale.x = 0.05f;                // 反転
                                 
                transform.localScale = scale;       //更新



            }

            //画面上から見えなくなったらオブジェクトを消す
            else
            {
                Destroy(gameObject);
            }
        }
        //床の上にいない時
        else
        {
            transform.Translate(0, this.dropSpeed, 0);
        }
    }
}
