using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private float speed;

    private float x; //x方向のImputの値
    private float z; //z方向のInputの値
    Vector3 prePos;

    [SerializeField]Transform model = null;
    
    //private Rigidbody rigd;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {

        //横に移動
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position += new Vector3((Input.GetAxis("Horizontal") * speed * Time.deltaTime), 0.0f, 0.0f);
        }
        //WASD移動
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(0.1f, 0.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(0.1f, 0.0f, 0.0f);
            }
        }

        //縦に移動
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += new Vector3(0.0f, 0.0f, (Input.GetAxis("Vertical") * speed * Time.deltaTime));
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0.0f, 0.0f, 0.1f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0.0f, 0.0f, 0.1f);
            }
        }

        {
            Vector3 diff = this.gameObject.transform.position - prePos;
            if(diff.magnitude > 0.10f)
            {
                prePos = this.gameObject.transform.position;
            }
            model.rotation = Quaternion.LookRotation(diff);
        }

        /*
        {
            float dx = prePos.x - this.gameObject.transform.position.x;
            float dz = prePos.z - this.gameObject.transform.position.z;

            prePos = this.gameObject.transform.position;

            if (dx != 0 || dz != 0)
            {
                float t = Mathf.Atan(dz / dx);
                model.Rotate(new Vector3(0, t, 0));
            }
        }
        */
    }
}
