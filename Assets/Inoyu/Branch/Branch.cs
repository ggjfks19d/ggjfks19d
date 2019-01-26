using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
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
