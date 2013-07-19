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
	bool FacingRight() //fix
	{
		return transform.rotation.y == 0f;	
	}
	void OnCollisionEnter (Collision other)
	{
		if (other.transform.tag == "Environment")
		{
			Destroy (rigidbody);
			transform.collider.isTrigger = true;
			transform.parent = other.transform;
		}
		else if (other.transform.tag == "Player")
		{
			
		}
		else
		{
			
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter (Collider other)
	{
		if (other.transform.tag == "Projectile")
		{
			Destroy(gameObject);	
		}
	}
	
}
