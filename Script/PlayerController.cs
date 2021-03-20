using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;            //Rigid2D型の変数
    Animator animator;              //アニメーター
    public GameObject starPrefab;   //starprefabを取る

    float walkForce = 50.0f;        //歩くための力
    float maxWalkSpeed = 10.0f;      //歩くときのマックススピード
    float jumpForce = 680.0f;       //ジャンプするための力
    private bool isJumping = false;
    

    public AudioClip starSE;
    AudioSource aud;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2Dを取る
        this.rigid2D = GetComponent<Rigidbody2D>();
        //アニメーターを取る
        this.animator = GetComponent<Animator>();

        this.aud = GetComponent<AudioSource>();

        

    }

   
    // Update is called once per frame
    void Update()
    {

        

        //左右移動
        float key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 0.5f;
          
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -0.5f;
         
        }

        //プレイヤの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);

        }

        //動く方向に応じて反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 0.5f, 0.5f);
        }

        else
        {
            rigid2D.velocity = new Vector2(0, rigid2D.velocity.y);


        }


        //ジャンプする
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false) 
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            this.animator.SetTrigger("JumpTrigger");
            isJumping = true;

        }

        //スターを飛ばす
        if(Input.GetKeyDown(KeyCode.S))
        {

            Instantiate(starPrefab, transform.position + new Vector3(0f, 0.6f, 0f), transform.rotation);

            this.aud.PlayOneShot(this.starSE);

        }

        //プレイヤの速度に応じてアニメーション速度を変える
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 4.0f;
        }

        else
        {
            this.animator.speed = 1.0f;
        }

        
        
    }

    //一段ジャンプ制限
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }

        


    }

    

    


    
}
