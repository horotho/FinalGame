using UnityEngine;
using System.Collections;

public class EtherChakraController : ChakraController
{
	private float jumpForce = 100f;
	
	public EtherChakraController ()
	{
		isActivated = false;
	}
	
	public override void OnJump (Rigidbody2D rigidbody)
	{
		rigidbody.AddForce (new Vector2 (0, jumpForce));
	}

	public override void OnStateChange(SpriteRenderer renderer)
	{
		renderer.color = Color.red;	
	}
}

