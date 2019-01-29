using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------------------------------------
// 自動的にスプライトのアニメーションを再生する機構 
//----------------------------------------------------------------------------------------------------
public class AutoSpriteAnim : MonoBehaviour
{
    [SerializeField]SpriteRendererIndexer sprite;
	[SerializeField]float spd = 0.1f;

	IEnumerator Start()
	{
		while(true)
		{
			yield return new WaitForSeconds(spd);
			sprite.index++;
		}
	}
}
