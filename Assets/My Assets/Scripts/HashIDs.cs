using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {

	public int deadBool;
	public int speedFloat;
	public int jumpBool;
	public int throwBool;
	void Awake()
	{
		deadBool = Animator.StringToHash("Dead");	
		speedFloat = Animator.StringToHash("Speed");
		jumpBool   = Animator.StringToHash ("Airborne");
		throwBool  = Animator.StringToHash("Throw");
	}
}
