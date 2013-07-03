using UnityEngine;
using System.Collections;

public class PlatformCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			transform.parent.collider.isTrigger = false;
	}
	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player")
		{
			transform.parent.collider.isTrigger = true;	
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && Input.GetAxis("Vertical")<0)
		{
				transform.parent.collider.isTrigger = true;
		}
	}
}
