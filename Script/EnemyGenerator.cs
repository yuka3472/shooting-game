using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject mousePrefab;
    float span = 1;
    float delta = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //一秒毎にランダムでネズミを出現させる
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject enemy = Instantiate(mousePrefab) as GameObject;
            float x = Random.Range(-10, 22);
            enemy.transform.position = new Vector3(x, 3, 0);

        }
    }
}
