using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //横に移動
        if(Input.GetAxis("Horizontal") != 0)
        {
            transform.position -= new Vector3((Input.GetAxis("Horizontal") * speed * Time.deltaTime), 0.0f, 0.0f);
        }

        //縦に移動
        if(Input.GetAxis("Vertical") != 0)
        {
            transform.position += new Vector3(0.0f, 0.0f, (Input.GetAxis("Vertical") * speed * Time.deltaTime));
        }


    }
}
