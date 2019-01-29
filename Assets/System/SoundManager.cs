// SoundManager.cs 
//
// @idev Unity2018.3.2f1 / VisualStudio 2017
// @auth FCEI.No-Va
// @date 2017/01/27
//
// Copyright (C) 2019 FlyteCatEmotion Inc.
// All Rights Reserved.
//------------------------------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------------------------------------
// 音の管理 
//----------------------------------------------------------------------------------------------------
public class SoundManager : MonoBehaviour
{
	//--------------------------------------------------------------------------------
	// 効果音 ジングル 
	//--------------------------------------------------------------------------------
	public enum SE
	{
		START,		// ゲーム開始音 
		WALK,		// 歩く 
		ATTACK,		// 攻撃(鼻息) 
		HIT,		// 攻撃ヒット 
		GET,		// 枝ゲット 
		DAMAGE,		// ダメージを受ける 
		LVUP,		// レベルアップ 
		FIRE,		// 火に枝を追加 
	}

	//--------------------------------------------------------------------------------
	// BGM 
	//--------------------------------------------------------------------------------
	public enum BGM
	{
		TITLE,		// タイトル画面 
		HOME,		// 家の中 
		MAIN,		// 外(雪の音) 
	}

	//--------------------------------------------------------------------------------
	// メンバ変数 
	//--------------------------------------------------------------------------------
	static SoundManager instance;           // シングルトンインスタンス

	[SerializeField]AudioSource[] seList;   // 効果音のリスト 
	[SerializeField]AudioSource[] bgmList;  // BGM1のリスト 



	//--------------------------------------------------------------------------------
	// コンストラクタ 
	//--------------------------------------------------------------------------------
	void Awake()
	{
		// シングルトン作成 
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else {
			GameObject.Destroy(this.gameObject);
		}
	}



	//--------------------------------------------------------------------------------
	// SE再生 
	//--------------------------------------------------------------------------------
	public static void PlaySE(SE id)
	{
		if(instance == null){ Debug.LogError("Instance is null."); return; }

		AudioSource a = instance.seList[(int)id];
		if(a != null && a.clip != null){ a.Play(); }
	}

	//--------------------------------------------------------------------------------
	// SE再生確認 
	//--------------------------------------------------------------------------------
	public static bool IsPlayingSE(SE id)
	{
		if(instance == null){ Debug.LogError("Instance is null."); return false; }

		AudioSource a = instance.seList[(int)id];
		if(a != null && a.clip != null){ return a.isPlaying; }

		return false;
	}

	//--------------------------------------------------------------------------------
	// SE停止 
	//--------------------------------------------------------------------------------
	public static void StopSE(SE id)
	{
		if(instance == null){ Debug.LogError("Instance is null."); return; }

		AudioSource a = instance.seList[(int)id];
		if(a != null && a.clip != null){ a.Stop(); }
	}

	

	//--------------------------------------------------------------------------------
	// BGM再生 
	//--------------------------------------------------------------------------------
	public static void PlayBGM(BGM id, bool isMix = false)
	{
		if(instance == null){ Debug.LogError("Instance is null."); return; }

		if(!isMix){ StopBGM(); }

		AudioSource a = instance.bgmList[(int)id];
		if(a != null && a.clip != null){ a.Play(); }
	}

	//--------------------------------------------------------------------------------
	// BGM再生確認 
	//--------------------------------------------------------------------------------
	public static bool IsPlayingBGM(BGM id, bool isMix = false)
	{
		if(instance == null){ Debug.LogError("Instance is null."); return false; }

		AudioSource a = instance.bgmList[(int)id];
		if(a != null && a.clip != null){ return a.isPlaying; }

		return false;
	}

	//--------------------------------------------------------------------------------
	// BGM停止 
	//--------------------------------------------------------------------------------
	public static void StopBGM(BGM id)
	{
		if(instance == null){ Debug.LogError("Instance is null."); return; }

		AudioSource a = instance.bgmList[(int)id];
		if(a != null && a.clip != null){ a.Stop(); }
	}
	public static void StopBGM()
	{
		if(instance == null){ Debug.LogError("Instance is null."); return; }

		// すべて停止 
		for(int i = 0; i < instance.bgmList.Length; i++)
		{
			StopBGM((BGM)i);
		}
	}



	//--------------------------------------------------------------------------------
	// AudioSourcce生成 
	//--------------------------------------------------------------------------------
	[SerializeField]Transform seRoot;
	[SerializeField]Transform bgmRoot;
	[ContextMenu("EXEC_GenerateAudioSource")]
	void GenerateAudioSource()
	{
		FCEI.Util.ClearChild(seRoot.gameObject);
		FCEI.Util.ClearChild(bgmRoot.gameObject);

		// SEのAudioSouece生成 
		this.seList = new AudioSource[FCEI.Enums<SE>.Length];
		for(int i=0; i<FCEI.Enums<SE>.Length; i++)
		{
			GameObject obj = new GameObject(((SE)i).ToString());
			obj.transform.parent = seRoot;
			AudioSource source = obj.AddComponent<AudioSource>();
			source.playOnAwake = false;
			this.seList[i] = source;
		}

		// BGMのAudioSouece生成 
		this.bgmList = new AudioSource[FCEI.Enums<BGM>.Length];
		for(int i=0; i<FCEI.Enums<BGM>.Length; i++) {
			GameObject obj = new GameObject(((BGM)i).ToString());
			obj.transform.parent = bgmRoot;
			AudioSource source = obj.AddComponent<AudioSource>();
			source.playOnAwake = false;
			source.loop = true;
			this.bgmList[i] = source;
		}
	}
}
