using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catGenerator : MonoBehaviour
{

    public GameObject catPrefab;
    float span = 7;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //7秒間隔でオブジジェクト出現
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject enemy = Instantiate(catPrefab) as GameObject;
           
            enemy.transform.position = new Vector3(30, -2.85f, 0);
        }
    }

}
