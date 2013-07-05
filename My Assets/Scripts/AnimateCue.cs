using UnityEngine;
using System.Collections;

public class AnimateCue : MonoBehaviour {
	public float force;
	void Awake()
	{
		if (FacingRight())
		{
			transform.rigidbody.AddForce(Vector3.right*force);
		}
		else
		{
			transform.rigidbody.AddForce(Vector3.left*force);
		}
	}
	bool FacingRight()
	{
		return transform.rotation.y == 0f;	
	}
	void OnCollisionEnter (Collision other)
	{
		if (other.transform.tag == "Environment")
		{
			Destroy (rigidbody);
			transform.collider.isTrigger = true;
		}
		else if (other.transform.tag == "Player")
		{
			
		}
		else
		{
			
			Destroy (gameObject);
		}
	}
	
}
