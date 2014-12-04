using UnityEngine;
using System.Collections;

public class EtherChakraController : ChakraController
{
	private float jumpForce = 15f;
	
	public EtherChakraController (Rigidbody2D rb, SpriteRenderer rd) : base(rb, rd)
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
		renderer.color = Color.red;
	}
}

