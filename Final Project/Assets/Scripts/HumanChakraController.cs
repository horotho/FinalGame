using UnityEngine;
using System.Collections;

public class HumanChakraController : ChakraController
{
	private float jumpForce = 100f;
	
	public HumanChakraController (Rigidbody2D rb, SpriteRenderer rd) : base(rb, rd)
	{
		this.isActivated = true;
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
		renderer.color = Color.white;
	}
	
}

