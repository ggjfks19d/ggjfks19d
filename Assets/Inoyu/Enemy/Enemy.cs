using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject cube;

    //プレイヤーの進んだ方向に敵を出す
    //
    // Start is called before the first frame update
    void Start()
    {
         
        //GameObject.Find("Player").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);


        for (int i = 0; i< 10; i++) {

            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(-5.0f, 5.0f);

            Instantiate(cube, new Vector2(x, y), Quaternion.identity);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
