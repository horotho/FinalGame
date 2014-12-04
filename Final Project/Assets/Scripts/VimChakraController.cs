using UnityEngine;
using System.Collections;

public class VimChakraController : ChakraController
{
	private float jumpForce = 100f;
	
	public VimChakraController (GameObject gm) : base(gm)
	{
	}
	
	public override void Jump (bool isGrounded)
	{
		if(isGrounded && Input.GetKeyDown(KeyCode.Space))
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
		spriteRenderer.color = Color.green;
	}
}

