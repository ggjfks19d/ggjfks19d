using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    Slider m_Slider;
    float m_Hp = 0;
    bool m_healFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Slider = GameObject.Find("Slider").GetComponent<Slider>();
        //m_Slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_Hp = 0.0f;
        if (m_healFlg && m_Slider.value < 1.0f)
        {
            m_Hp = 0.001f;
        }

        m_Slider.value += m_Hp;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_healFlg = true;
            Debug.Log("player");
        }
        else
        {
            Debug.Log("hit");
        }
    }

    //void OnTriggerExit(Collider other)
    //{
    //    if(other.gameObject.tag == "Player")
    //    {
    //        m_healFlg = false;
    //    }
    //}
}
