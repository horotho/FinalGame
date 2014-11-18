using UnityEngine;
using System.Collections;

public class FluxChakraController : ChakraController
{
	private float jumpForce = 200f;

	public FluxChakraController ()
	{
		isActivated = false;
	}

	public override void OnJump (Rigidbody2D rigidbody)
	{
		rigidbody.AddForce (new Vector2 (0, jumpForce));
	}

	public override void OnStateChange(SpriteRenderer renderer)
	{
		renderer.color = Color.blue;
	}
}

