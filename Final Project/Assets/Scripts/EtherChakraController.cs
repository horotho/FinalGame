using UnityEngine;
using System.Collections;

public class EtherChakraController : ChakraController
{
	private float jumpForce = 15f;
	
	public EtherChakraController (GameObject gm) : base(gm)
	{

	}
	
	public override void Jump (bool isGrounded)
	{
		if(Input.GetKey(KeyCode.Space))
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
	}
	
	public override void Ability ()
	{
		
	}
	
	public override void Climb ()
	{
		
	}
	
	public override void OnStateChange ()
	{
		spriteRenderer.color = Color.red;
	}
}

