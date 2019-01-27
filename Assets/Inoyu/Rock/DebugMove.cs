using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMove : MonoBehaviour
{
	Transform tf;

	void Awake()
	{
		tf = this.gameObject.transform;
	}

	// Update is called once per frame
	void Update()
    {
		if(Input.GetKey(KeyCode.UpArrow   )){ tf.position += new Vector3( 0, 0,  1); }
		if(Input.GetKey(KeyCode.DownArrow )){ tf.position += new Vector3( 0, 0, -1); }
		if(Input.GetKey(KeyCode.LeftArrow )){ tf.position += new Vector3(-1, 0,  0); }
		if(Input.GetKey(KeyCode.RightArrow)){ tf.position += new Vector3( 1, 0,  0); }
	}
}
