using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    //private Rigidbody rid;
    // bullet prefab
    public GameObject Bullet;

    // 弾丸発射点
    public Transform Muzzle;

    // 弾丸の速度
    public float Bulletspeed = 1000;

    // 移動スクリプト 
    MoveScript moveScript = null;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = this.gameObject.GetComponent<MoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.time += Time.deltaTime;
        //if (time > 2)
        //{
        //    Destroy(gameObject);
        //    Instantiate(Bullet, transform.position, Quaternion.identity);
        //}
        
        //moveScript.diff 



        // z キーが押された時
        if (Input.GetButtonDown("Fire1"))
        {

            // 弾丸の複製
            GameObject bullets = Instantiate(Bullet) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * Bulletspeed;

            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);

            // 弾丸の位置を調整
            bullets.transform.position = new Vector3(Muzzle.position.x , Muzzle.position.y, Muzzle.position.z);
        }
        
    }
}

