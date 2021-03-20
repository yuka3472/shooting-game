using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamewayDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //スペースを押したらゲームシーンに移動
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            SceneManager.LoadScene("GameScene");
        }
    }

}
