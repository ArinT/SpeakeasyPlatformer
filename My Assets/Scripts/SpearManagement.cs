using UnityEngine;
using System.Collections;
public class SpearManagement : MonoBehaviour {
	private Animator anim;
	private HashIDs hash;
	public GameObject cue;
	public float spearCadence = 2f;
	private float lastSpear  = 0f;
	private float dif=0;
	private Quaternion q;
	private GhostsNGoblinsMovement g;
	private Vector3 spearPos;
	void Awake()
	{
		
		anim = GetComponent<Animator>();
		g    = GetComponent<GhostsNGoblinsMovement>();
		hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
	}
	void Update()
	{
		dif = Time.time - lastSpear;
		if (Input.GetButtonDown("Spear")&& (dif>spearCadence))
		{
				
				anim.SetBool(hash.throwBool, true);
				Throw();
		}
		else
		{
				anim.SetBool(hash.throwBool, false);
		}
	}
	void Throw()
	{
			spearPos = transform.position;
			spearPos.y+=2;
			if (g.facingRight)
				spearPos.x+=1.1f;
			else
				spearPos.x-=1.1f;
			q = Quaternion.LookRotation(g.facingRight?Vector3.forward:Vector3.back, g.facingRight?Vector3.left:Vector3.right);
			MonoBehaviour.Instantiate(cue, spearPos, q);
			lastSpear = Time.time;
	}
}
