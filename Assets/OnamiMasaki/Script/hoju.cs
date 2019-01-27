using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hoju : MonoBehaviour
{

    private bool m_HojuFlg;
    Slider m_Slider;

    // Start is called before the first frame update
    void Start()
    {
        m_Slider = GameObject.Find("FireSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //薪("maki")が焚火の補充範囲内に入ったら、燃える時間を60秒分回復する。
        if (m_HojuFlg)
        {
            m_Slider.value += 60.0f / 180.0f;
        }
        //薪("maki")が焚火の補充範囲外に出たら、燃える時間が180秒で燃え尽きるように減る。
        else
        {
            m_Slider.value -= Time.deltaTime / 180.0f;
        }

        m_HojuFlg = false;
    }

    //薪("maki")が焚火の補充範囲内に入ったら、フラグをtrueにする。
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

    //void OnTriggerExit(Collider other)
    //{
    //    if(other.gameObject.tag == "maki")
    //    {
    //        m_HojuFlg = false;
    //    }
    //}

    void OnGUI()
    {
        //焚火の燃える時間
        float time = m_Slider.value * 180.0f;
        //GUILayout.Button(time.ToString());

    }
}
