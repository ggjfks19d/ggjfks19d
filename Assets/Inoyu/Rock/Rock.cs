using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject cube;
    Transform t;
    Transform e;

    [SerializeField] float sx;
    [SerializeField] float sy;


    // Start is called before the first frame update
    void Start()
    {
        t = GameObject.Find("Player").transform;
        e = GameObject.Find("Empty").transform;


        //10体増やす
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(-sx, sx);
            float y = Random.Range(-sy, sy);

            Instantiate(cube, new Vector2(x / 2, y / 2), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateScreen()
    {
        

    }

    void GenerateRockRight()
    {
        
        //float x = Random.Range(sx, sx / 2);
        //float y = Random.Range(sy / 2, -sy / 2);
        //if (-(t.position.x - e.position.x) < sx)
        //{

        //    Instantiate(cube, new Vector2(x, y), Quaternion.identity);
        //}
    }
    void GenerateRockLeft()
    {
        
    }
}
