using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Cube;
    float time = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Vector2 CreatePoint = new Vector2(Random.Range(0, 5), Random.Range(0,5));
            Instantiate(Cube, CreatePoint, Quaternion.identity);
            time = 3;
        }
    }
}
