using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
	//--------------------------------------------------------------------------------
	// メンバ変数  
	//--------------------------------------------------------------------------------
	Transform tf;	// 自身のTransformへのアクセスを早くするために保持 

	public GameObject cube;
    Transform player;

    [SerializeField] float sx;
    [SerializeField] float sz;

	// 出現させたエミッタ―(自身のコピー)の位置リスト 
	static List<Transform> copyList = new List<Transform>();

	//--------------------------------------------------------------------------------
	// 初期化 
	//--------------------------------------------------------------------------------
	void Start()
    {
		// 高速化用のTransform保持  
		tf = this.gameObject.transform;

		// 自身をコピーリストに加えておく 
		copyList.Add(tf);

		// プレイヤーを取得 
        player = GameObject.Find("Player").transform;
    }

	//--------------------------------------------------------------------------------
	// 終了処理  
	//--------------------------------------------------------------------------------
	void OnDestroy()
	{
		copyList.Remove(tf);
	}


	//--------------------------------------------------------------------------------
	// 更新 
	//--------------------------------------------------------------------------------
	void Update()
    {
		if(IsNearPlayer())
		{
			// 画面にランダムに障害物を生成 
			if(copyList.Count > 1){ GenerateScreen(); }

			// 上下左右位置画面分先に自身を複製 
			CopySelfDiff(new Vector3( sx, 0,   0));
			CopySelfDiff(new Vector3(  0, 0,  sz));
			CopySelfDiff(new Vector3(-sx, 0,   0));
			CopySelfDiff(new Vector3(  0, 0, -sz));

			// 本体は眠る 
			this.gameObject.SetActive(false);
		}        
    }

	//--------------------------------------------------------------------------------
	// 1画面分の障害物を生成 
	//--------------------------------------------------------------------------------
	void GenerateScreen()
    {
		int count = Random.Range(0, 8);
		for(int i=0; i<count; i++)
		{
			float x = Random.Range(-sx/2, sx/2) + tf.position.x;
			float y = tf.position.y;
			float z = Random.Range(-sz/2, sz/2) + tf.position.z;

			Instantiate(cube, new Vector3(x, y, z), Quaternion.identity);
		}
	}

	//--------------------------------------------------------------------------------
	// プレイヤーが近づいているか判定 
	//--------------------------------------------------------------------------------
	bool IsNearPlayer()
	{
		float dx = Mathf.Abs(player.position.x - tf.position.x);
		float dz = Mathf.Abs(player.position.z - tf.position.z);

		return (dx < sx && dz < sz);
	}

	//--------------------------------------------------------------------------------
	// 自身をdistだけずらした位置に複製 
	//--------------------------------------------------------------------------------
	void CopySelfDiff(Vector3 diff)
	{
		Vector3 targetPos = tf.position + diff;

		if(IsCopy(targetPos) == false)
		{
			GameObject obj = Instantiate(this.gameObject, targetPos, Quaternion.identity);
			obj.name = string.Format("({0}, {1}, {2})", targetPos.x, targetPos.y, targetPos.z);
		}
	}

	//--------------------------------------------------------------------------------
	// 指定した場所にコピーがいるかどうか判定 
	//--------------------------------------------------------------------------------
	bool IsCopy(Vector3 pos)
	{
		foreach(Transform copy in copyList)
		{
			bool x = (int)(copy.position.x) == (int)(pos.x);
			bool y = (int)(copy.position.y) == (int)(pos.y);
			bool z = (int)(copy.position.z) == (int)(pos.z);

			if(x && y && z){ return true; } 
		}

		return false;
	}

	//--------------------------------------------------------------------------------
	// Debug 
	//--------------------------------------------------------------------------------
	//private void OnGUI()
	//{
	//	for(int i=0; i<copyList.Count; i++)
	//	{
	//		Vector3 pos = copyList[i].position;
	//		GUILayout.Label(string.Format("({0}, {1}, {2})", pos.x, pos.y, pos.z));
	//	}
	//}
}
