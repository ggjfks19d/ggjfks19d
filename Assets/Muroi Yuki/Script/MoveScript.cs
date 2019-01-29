using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SE = SoundManager.SE;

public class MoveScript : MonoBehaviour
{
	[SerializeField]Hp hp=null;						// 体力 
	[SerializeField]ShootingScript shooting=null;	// 弾発射機構 

    private float speed;

    private float x; //x方向のImputの値
    private float z; //z方向のInputの値
 
    Vector3 prePos;
    public Vector3 diff{ get; private set; }

    [SerializeField]Transform model = null;
    
    //private Rigidbody rigd;

	bool[] runFlag = new bool[2];				// 走っているフラグ [0]:今のフレーム [1]:前フレーム  
	[SerializeField]GameObject motionStay=null; // 走りモーション 
	[SerializeField]GameObject motionRun=null;	// 待機モーション 
	public bool isCollision = false;			// 衝突中フラグ 

	[SerializeField]GameObject[] fuelModel=null;	// 
	public int fuelCount=0;							// 



	// Start is called before the first frame update
	void Start()
    {
        speed = 6.0f;
    }

    // Update is called once per frame
    void Update()
    {
		if(!isCollision)
		{
			runFlag[0] = false;

			//横に移動
			if(Input.GetAxis("Horizontal") != 0)
			{
				transform.position += new Vector3((Input.GetAxis("Horizontal") * speed * Time.deltaTime), 0.0f, 0.0f);
				runFlag[0] = true;
			}

			//縦に移動
			if(Input.GetAxis("Vertical") != 0)
			{
				transform.position += new Vector3(0.0f, 0.0f, (Input.GetAxis("Vertical") * speed * Time.deltaTime));
				runFlag[0] = true;
			}

			// 移動に合わせて向きを変える 
			if(runFlag[0])
			{
				diff = this.gameObject.transform.position - prePos;
				if(diff.magnitude > 0.01f)
				{
					model.rotation = Quaternion.LookRotation(diff);
				}
				prePos = this.gameObject.transform.position;
			}
		}
		else
		{
			MoveCancel();
		}

		// モーションを変更 
		if(!runFlag[0] && runFlag[1])
		{
			// 待機 
			ChangeMotion(true);
		}
		if(runFlag[0] && !runFlag[1])
		{	
			// 走り 
			ChangeMotion(false);
		}

		// 音を鳴らす 
		PlayRunSound();

		// 走りフラグを進める 
		runFlag[1] = runFlag[0];
    }

	//--------------------------------------------------------------------------------
	// モーションを変更する  
	//--------------------------------------------------------------------------------
	void ChangeMotion(bool isStay)
	{
		motionRun.SetActive(!isStay);	// 走り 
		motionStay.SetActive(isStay);	// 待機 
	}

	//--------------------------------------------------------------------------------
	// 足音を鳴らす  
	//--------------------------------------------------------------------------------
	void PlayRunSound()
	{
		if(runFlag[0] && !hp.IsHealing())
		{
			if(!SoundManager.IsPlayingSE(SE.WALK))
			{
				SoundManager.PlaySE(SE.WALK);
			}
		}
		else
		{
			SoundManager.StopSE(SE.WALK);
		}
	}

	//--------------------------------------------------------------------------------
	// 進む前の位置に戻る(壁などに当たった時に使用) 
	//--------------------------------------------------------------------------------
	void MoveCancel()
	{
		// ずれた位置戻す 
		transform.position -= diff/10;

		// 直前位置も同じはず 
		prePos = transform.position;
	}
}
