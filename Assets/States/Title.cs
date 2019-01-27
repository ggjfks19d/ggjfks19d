using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------------------------------------
// タイトル画面 
//----------------------------------------------------------------------------------------------------
public class Title : MonoBehaviour
{
	//--------------------------------------------------------------------------------
	// メンバ変数 
	//--------------------------------------------------------------------------------
	[SerializeField]Transform  logo = null;
	[SerializeField]GameObject text = null;

	[SerializeField]float animSpeed = 0;

	//--------------------------------------------------------------------------------
	// メインスレッド 
	//--------------------------------------------------------------------------------
	IEnumerator Start()
	{
		// タイトルBGM 
		SoundManager.PlayBGM(SoundManager.BGM.TITLE);

		// ロゴの初期値変更 
		Vector3 logoPos = logo.localPosition;
		logo.localPosition = new Vector3(0, -1024, 0);

		// PUSHANYKEYを隠す 
		text.SetActive(false);

		while(true)
		{
			if(logo.localPosition.y < logoPos.y) 
			{
				logo.localPosition += new Vector3(0, animSpeed * Time.deltaTime, 0); 
			}
			else
			{
				// PUSHANYKEYが出ていなかったら出す 
				if(!text.activeSelf)
				{
					text.SetActive(true);
				}

				if(Input.anyKeyDown){
					text.SetActive(false);
					SoundManager.StopBGM();
					SoundManager.PlaySE(SoundManager.SE.START);
					SysManager.GoToMain();
					yield break;
				}
			}

			yield return null;
		}
	}
}
