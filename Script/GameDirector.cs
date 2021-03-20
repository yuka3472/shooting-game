using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject TimerText;
    GameObject pointText;
    float time = 30.0f;
    public static int point;
    

    //ネズミと当たった時の得点
    public void GetMouse()
    {
        point += 20;

    }
    //猫と当たった時に減点する
    public void GetCat()
    {
        point -= 5;

    }

    // Start is called before the first frame update
    void Start()
    {
        //textをとってくる
        this.TimerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        //pointを引き継がないようにする
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //timeとpointを表示

        this.time -= Time.deltaTime;
        this.TimerText.GetComponent<Text>().text =
            this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text =
            point.ToString() + "point";

        //timeが０になったらclearsceneへ移動

        if (time<=0)
        {
            SceneManager.LoadScene("ClearScene");
        }

        

    }
    //pointを他のsceneへ渡すめの関数
    public static int GetPoint()
    {
        
        return point;
    }

    


}
