using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    //[SerializeField]Transform camera;
    //[SerializeField]Transform target;


    Slider m_Slider;
    float m_Hp = 0;
    bool m_healFlg = false;
    int m_Count = 0;

    float dbgPreSliderValue;

    // Start is called before the first frame update
    void Start()
    {
        m_Slider = GameObject.Find("Slider").GetComponent<Slider>();
        //m_Slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが焚火の範囲外にいたら（m_healFlgがfalseなら）、30秒でHPが全部なくなるように減る。
        //m_Countが増えたらHPが全部なくなるのにかかる時間が増える。
        if (!m_healFlg)
        {
            m_Slider.value -= Time.deltaTime / (30.0f + 10 * m_Count);
        }
        //プレイヤーが焚火の範囲内にいたら（m_healFlgがtrueなら）、10秒でHPを全回復する。
        //m_Countが増えたらHPが全回復するのにかかる時間が増える。
        if (m_healFlg && m_Slider.value < 1.0f)
        {
            m_Slider.value += Time.deltaTime / (10.0f + 3 * m_Count);
        }

        //敵を倒したらHPの最大値(m_Count)が増える
        //SPACEキーを押すとHPの最大値(m_Count)が増える（デバッグ用）
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RectTransform rt = m_Slider.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(rt.sizeDelta.x + 20.0f, 20.0f);
            m_Count++;
        }
        
    }

    //プレイヤー("Player")が焚火の範囲内なら回復フラグをtrueにする。
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
			if(!m_healFlg) 
			{
				SoundManager.StopBGM();
				SoundManager.PlayBGM(SoundManager.BGM.HOME);
			}

			m_healFlg = true;

            Debug.Log("player");
        }
        //else
        //{
        //    Debug.Log("hit");
        //}
    }

    //プレイヤー("Player")が焚火の範囲外なら回復フラグをfalseにする。
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_healFlg = false;

			SoundManager.StopBGM();
			SoundManager.PlayBGM(SoundManager.BGM.MAIN);
		}
	}

    void OnGUI()
    {
        //GUILayout.Button(m_Slider.value.ToString());
        //GUILayout.Button((Time.deltaTime / 30.0f).ToString());
        //GUILayout.Button((Time.deltaTime / 10.0f).ToString());

        //GUILayout.Button((m_Slider.value - dbgPreSliderValue).ToString());

        //dbgPreSliderValue = m_Slider.value;
    }

	//--------------------------------------------------------------------------------
	// 回復中かどうか外から確認できる 
	//--------------------------------------------------------------------------------
	public bool IsHealing()
	{
		return m_healFlg;
	}
}
