using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    private float speed;

    private float x; //x方向のImputの値
    private float z; //z方向のInputの値
 
    Vector3 prePos;
    public Vector3 diff{ get; private set; }

    [SerializeField]Transform model = null;
    
    //private Rigidbody rigd;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //横に移動
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position += new Vector3((Input.GetAxis("Horizontal") * speed * Time.deltaTime), 0.0f, 0.0f);
        }   
           
        //縦に移動
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += new Vector3(0.0f, 0.0f, (Input.GetAxis("Vertical") * speed * Time.deltaTime));
        }

        {
            diff = this.gameObject.transform.position - prePos;
            if(diff.magnitude > 0.50f)
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
