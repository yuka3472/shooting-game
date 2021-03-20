using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catController : MonoBehaviour
{
    GameObject director;

    // Start is called before the first frame update
    void Start()
    {
        //ゲームディレクターを探す
        this.director = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(-0.1f, 0, 0);
        
        if(transform.position.x<-11)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //プレイヤーとぶつかったらGameDirectorのGetCat関数を呼び出す
        if (collision.gameObject.CompareTag("Player"))
        {
            this.director.GetComponent<GameDirector>().GetCat();

        }

    }


}
