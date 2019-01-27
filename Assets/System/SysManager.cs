// SysManager.cs 
//
// @idev Unity2018.3.2f1 / VisualStudio 2017 
// @auth FCEI.No-Va
// @date 2019/01/26
//
// Copyright (C) 2019 FlyteCatEmotion Inc.
// All Rights Reserved.
//------------------------------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//----------------------------------------------------------------------------------------------------
// ゲームの流れを管理する  
//----------------------------------------------------------------------------------------------------
public class SysManager : MonoBehaviour
{
	//--------------------------------------------------------------------------------
	// メンバ変数 
	//--------------------------------------------------------------------------------
	static SysManager instance;		// シングルトンインスタンス
	static float playTime = 0;		// メインを遊んだ時間(リザルト用) 

	//--------------------------------------------------------------------------------
	// コンストラクタ 
	//--------------------------------------------------------------------------------
	void Awake()
	{
		// シングルトン作成 
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else{
			GameObject.Destroy(this.gameObject);
		}
	}

	//--------------------------------------------------------------------------------
	// ステート管理フロー  
	//--------------------------------------------------------------------------------
	IEnumerator Start()
	{
		SceneManager.LoadScene("Title");
		yield return null;

		while(true) 
		{
			playTime += Time.deltaTime;
			yield return null;
		}
	}

	//--------------------------------------------------------------------------------
	// タイトル画面へ  
	//--------------------------------------------------------------------------------
	public static void GoToTitle()
	{
		// 全てのBGMを止める 
		SoundManager.StopBGM();

		// フェードしてタイトルへ 
		FadeManager.FadeOut(FADE_SPEED, 
			()=>{
				SceneManager.LoadScene("Title");
				FadeManager.FadeIn(FADE_SPEED);
			}
		);
	}

	//--------------------------------------------------------------------------------
	// メイン画面へ  
	//--------------------------------------------------------------------------------
	public static void GoToMain()
	{
		// フェードしてメインへ 
		FadeManager.FadeOut(FADE_SPEED,
			() => {
				SceneManager.LoadScene("MainScene");
				FadeManager.FadeIn(FADE_SPEED);
				playTime = 0;
			}
		);
	}

	//--------------------------------------------------------------------------------
	// リザルト表示 
	//--------------------------------------------------------------------------------
	public static void GoToResult()
	{
		// リザルト情報を表示する 
		SceneManager.LoadScene("Result", LoadSceneMode.Additive);
	}

	//--------------------------------------------------------------------------------
	// 定数  
	//--------------------------------------------------------------------------------
	const float FADE_SPEED = 1.5f;
}
