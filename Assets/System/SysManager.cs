﻿// SysManager.cs 
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

//----------------------------------------------------------------------------------------------------
// ゲームの流れを管理する  
//----------------------------------------------------------------------------------------------------
public class SysManager : MonoBehaviour
{
	//--------------------------------------------------------------------------------
	// メンバ変数 
	//--------------------------------------------------------------------------------
	static SysManager instance;           // シングルトンインスタンス

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
	// ステート管理フロー  
	//--------------------------------------------------------------------------------
	IEnumerator Start()
	{


		while(true) 
		{
			yield return null;
		}
	}
}