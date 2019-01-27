using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyScript : MonoBehaviour
{
    public GameObject Bullet;
    public float time = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(Bullet,time);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
