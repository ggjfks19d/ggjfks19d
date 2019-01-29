using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject cube;
    Transform t;
    private Vector3 playerpos;

    [SerializeField]float sx;
    [SerializeField]float sy;

    //初期化処理
    void Start()
    {
        t = GameObject.Find("Player").transform;
        //GameObject.Find("Player").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
        
        //for (int i = 0; i < 10; i++) {

        //    float x = Random.Range(-5.0f, 5.0f);
        //    float y = Random.Range(-5.0f, 5.0f);

        //    Instantiate(cube, new Vector2(x, y), Quaternion.identity);

        //    // 初期位置保存
        //    playerpos = t.position;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(t.position.x > playerpos.x + 10 )
        {
            playerpos = t.position;

            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(-5.0f, 5.0f);

            Instantiate(cube, new Vector2(x, y), Quaternion.identity);

        }

    }

    //画面外（上）に敵を出す
    void GenerateEnemyUp()
    {

        float x = Random.Range(-sx / 2, sx / 2);
        float y = Random.Range(sy / 2, sy);


        Instantiate(cube, new Vector2(x, y), Quaternion.identity);

    }
    void GenerateDown()
    {
        float x = Random.Range(-sx / 2, sx / 2);
        float y = Random.Range(-sy / 2, -sy);

        Instantiate(cube, new Vector2(x, y), Quaternion.identity);

    }
    [ContextMenu("EXEC_GenerateLeft")]
    void GenerateLeft()
    {
        float x = Random.Range(-sx, -sx / 2);
        float y = Random.Range(sy / 2, -sy / 2);

        Debug.Log("sx:" + sx + " sy:" + sy);
        Instantiate(cube, new Vector2(x, y), Quaternion.identity);
    }
    void GenerateRight()
    {

        float x = Random.Range(sx, sx / 2);
        float y = Random.Range(sy / 2, -sy / 2);

        Instantiate(cube, new Vector2(x, y), Quaternion.identity);
    }

}
