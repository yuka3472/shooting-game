using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverDirector : MonoBehaviour
{
    
    public int reset;
    GameObject PointText;
    GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        //GameDirectorスクリプトからポイントをとってくる
        
        
       
        this.PointText = GameObject.Find("point");
    }

    // Update is called once per frame
    void Update()
    {
        //スペースを押したらゲーム開始シーンに移動
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            SceneManager.LoadScene("StartScene");
        }

        //pointを表示
        this.PointText.GetComponent<Text>().text =
            score.ToString() + "point";

    }
}
