using UnityEngine;
using System.Collections;

public class GhostsNGoblinsMovement : MonoBehaviour {
	public float charSpeed=10f;
	public float jumpSpeed=10f;
	public bool facingRight;
	public bool grounded;
	private HashIDs hash;
	public AnimationClip idleAnimation;
	public AnimationClip runAnimation;
	public AnimationClip jumpPoseAnimation;
	public float turnSmoothing=100f;
	//implement ducking
	private CharacterController charCont;
	private Vector3 moveDirection;
	
	public Animator anim;
	void Awake () {
		facingRight = true;
		anim = GetComponent<Animator>();
		charCont = GetComponent<CharacterController>();
		hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
		anim.SetLayerWeight(1, 1f);
		if(!anim)
			Debug.Log("The character you would like to control doesn't have animations. Moving her might look weird.");
		if(!idleAnimation) {
			anim = null;
			Debug.Log("No idle animation found. Turning off animations.");
		}
		if(!runAnimation) {
			anim = null;
			Debug.Log("No run animation found. Turning off animations.");
		}
		if(!jumpPoseAnimation) {
			anim = null;
			Debug.Log("No jump animation found and the character has canJump enabled. Turning off animations.");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		grounded  = charCont.isGrounded;
		float h = Input.GetAxis("Horizontal");
		bool  j = Input.GetButtonDown ("Jump");
		anim.SetBool(hash.jumpBool, !grounded);
		if (h!=0)
		{
			Rotate (h);
			anim.SetFloat (hash.speedFloat,1f);
		}
		else
		{
			anim.SetFloat(hash.speedFloat,0f);	
		}
		if (grounded)
		{
			moveDirection = new Vector3(charSpeed*calcDir(h),0,0);
			if (j)
			{
				moveDirection.y = jumpSpeed;
			}
		}
		moveDirection.y -= 20f*Time.deltaTime;
		charCont.Move (moveDirection*Time.deltaTime);
	}
	float calcDir (float h)
	{
		if (h>0)
		{
			return 1;
		}
		else if ( h<0)
		{
			return -1;
		}
		return 0;
	}
	void Rotate (float horizontal)
    {
		if (horizontal>0)
		{
			facingRight = true;
			transform.eulerAngles= Vector3.Lerp(transform.eulerAngles, new Vector3(0,90,0),turnSmoothing*Time.deltaTime);
		}
		else if (horizontal<0)
		{
			facingRight = false;
			transform.eulerAngles= Vector3.Lerp(transform.eulerAngles,new Vector3(0,270,0),turnSmoothing*Time.deltaTime);
		}
		
    }
	
}
