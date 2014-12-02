using UnityEngine;
using System.Collections;

public class EtherChakraController : ChakraController
{
	private float jumpForce = 350f;
	
	public EtherChakraController ()
	{
		this.isActivated = false;
	}
	
	public override void OnJump (Rigidbody2D rigidbody)
	{
		rigidbody.AddForce (new Vector2 (0, jumpForce));
		rigidbody.gravityScale = 0.5f;
	}

	public override void OnStateChange(SpriteRenderer renderer)
	{
		renderer.color = Color.red;	
	}
}

