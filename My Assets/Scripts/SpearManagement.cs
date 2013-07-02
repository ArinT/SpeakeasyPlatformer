using UnityEngine;
using System.Collections;

public class SpearManagement : MonoBehaviour {
	private Animator anim;
	private HashIDs hash;
	void Awake()
	{
		
		anim = GetComponent<Animator>();
		
		hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
	}
	void Update()
	{
		if (Input.GetButtonDown("Spear"))
		{
				anim.SetBool(hash.throwBool, true);
		}
		else
		{
				anim.SetBool(hash.throwBool, false);
		}
	}
}
