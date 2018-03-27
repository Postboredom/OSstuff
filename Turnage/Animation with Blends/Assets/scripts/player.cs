using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public Animator anim;
	public Rigidbody rbody;

	private float inputH;
	private float inputV;
	private bool run;
	private float runspeed = 1f;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		rbody = GetComponent<Rigidbody>();
		run = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("1"))
		{
			anim.Play("WAIT01",-1,0f);
		}
		if(Input.GetKeyDown("2"))
		{
			anim.Play("WAIT02",-1,0f);
		}
		if(Input.GetKeyDown("3"))
		{
			anim.Play("WAIT03",-1,0f);
		}
		if(Input.GetKeyDown("4"))
		{
			anim.Play("WAIT04",-1,0f);
		}

		if(Input.GetKey(KeyCode.Space))
		{
			anim.SetBool("jump",true);
		}
		else
		{
			anim.SetBool("jump", false);
		}

		if(Input.GetKey(KeyCode.LeftShift))
		{
			anim.SetBool("run",true);
			runspeed = 3f;
		}
		else
		{
			anim.SetBool("run", false);
			runspeed = 1f;
		}

		inputH = Input.GetAxis ("Horizontal");
		inputV = Input.GetAxis ("Vertical");

		anim.SetFloat("inputH",inputH);
		anim.SetFloat("inputV",inputV);

		float speed = 50f * runspeed;
		float moveX = inputH*speed*Time.deltaTime;
		float moveZ = inputV*speed*Time.deltaTime;

		if(moveZ <= 0f)
		{
			moveX = 0f;
		}

		//another way to make character move is to set it's velocity vector
		rbody.velocity = new Vector3(moveX,0f,moveZ);

	}
}











