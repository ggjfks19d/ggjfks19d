using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hoju : MonoBehaviour
{
    public GameObject takibi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(takibi.transform.position.x, takibi.transform.position.y + 25.0f, 0.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "maki")
        {
            Debug.Log("maki");
        }
        else
        {
            Debug.Log("hit");
        }
    }
}
