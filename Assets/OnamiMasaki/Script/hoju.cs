using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hoju : MonoBehaviour
{
    private bool m_HojuFlg;
    public GameObject takibi;
    Slider m_Slider;
    // Start is called before the first frame update
    void Start()
    {
        m_Slider = GameObject.Find("FireSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //m_Slider.transform.position = new Vector3(takibi.transform.position.x, takibi.transform.position.y + 25.0f, 0.0f);

        if (m_HojuFlg)
        {
            m_Slider.value = 1.0f;
        }
        else
        {
            m_Slider.value -= 0.0002f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "maki")
        {
            m_HojuFlg = true;
            Debug.Log("maki");
        }
        //else
        //{
        //    Debug.Log("hit");
        //}
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "maki")
        {
            m_HojuFlg = false;
        }
    }
}
