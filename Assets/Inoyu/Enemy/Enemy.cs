using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Cube;
    float time = 1;
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
            Vector3 CreatePoint = new Vector3(Random.Range(0, 9),0, Random.Range(0,9));
            Instantiate(Cube, CreatePoint, Quaternion.identity);
            time = 1;
        }
    }
}
