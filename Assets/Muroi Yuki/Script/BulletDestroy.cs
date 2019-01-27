using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyScript : MonoBehaviour
{
    private GameObject Bullet;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(Bullet, 3);
        //Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed);
    }
}
