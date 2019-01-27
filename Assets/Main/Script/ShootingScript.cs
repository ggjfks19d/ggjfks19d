﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // bullet prefab
    public GameObject Bullet;

    // 弾丸発射点
    public Transform Muzzle;

    // 弾丸の速度
    public float speed = 1000;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // z キーが押された時
        if (Input.GetButtonDown("Fire1"))
        {

            // 弾丸の複製
            GameObject bullets = Instantiate(Bullet) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * speed;

            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);

            // 弾丸の位置を調整
            bullets.transform.position = new Vector3(Muzzle.position.x , Muzzle.position.y, Muzzle.position.z);
        }
    }
}
