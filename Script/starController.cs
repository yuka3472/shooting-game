using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starController : MonoBehaviour
{
    
    private SpriteRenderer sr = null;
    public PlayerController playerController;        //スクリプトを取ってくる
    public bool isleft;                              //プレイヤの向きを認識するための変数
    GameObject player;                                                                           
    private int speed = 30;                          //スターの速さ
    
    // Start is called before the first frame update
    void Start()
    {
        this.sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("player");
        Rigidbody2D rigid2D = GetComponent<Rigidbody2D>();

        //スターを動かす
        rigid2D.velocity = new Vector2(speed * player.transform.localScale.x, rigid2D.velocity.y);
        Vector2 temp = transform.localScale;
        temp.x = player.transform.localScale.x * 0.01f;
        transform.localScale = temp;

        //5秒後に破壊する
        Destroy(gameObject, 5);


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //敵かかべにぶつかったらobgectを消す
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("wall"))
        {

            Destroy(gameObject);
        }


    }


}
