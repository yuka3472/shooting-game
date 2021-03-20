using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤの位置をとる
        Vector3 playerPos = this.player.transform.position;

        //プレイヤの位置に移動
        transform.position = new Vector3(
            playerPos.x, transform.position.y, transform.position.z);

        //端を固定
        if (transform.position.x < 0)
        {
            transform.position = new Vector3(
                0, transform.position.y, transform.position.z);
        }

        else if(transform.position.x>20)
        {
            transform.position = new Vector3(
                20, transform.position.y, transform.position.z);
        }
    }
}
