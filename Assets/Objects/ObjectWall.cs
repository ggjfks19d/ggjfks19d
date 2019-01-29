using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWall : MonoBehaviour
{
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			MoveScript player = other.gameObject.GetComponent<MoveScript>();
			player.isCollision = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			MoveScript player = other.gameObject.GetComponent<MoveScript>();
			player.isCollision = false;
		}
	}
}
