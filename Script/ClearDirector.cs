using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearDirector : MonoBehaviour
{
    public int point;
    GameObject PointText;

    // Start is called before the first frame update
    void Start()
    {
        //gamedirectorスクリプトからポイントをとってくる
        point = GameDirector.GetPoint();
        print(point);
        this.PointText = GameObject.Find("point");
    }


    // Update is called once per frame
    void Update()
    {
        //スペースを押したら、startsceneに移動
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("StartScene");
        }
        //ポイントを表示
        this.PointText.GetComponent<Text>().text =
            point.ToString() + "point";

    }
}
