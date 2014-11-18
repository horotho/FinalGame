using UnityEngine;
using System.Collections;

public class FluxMovement : Movement
{
	private float jumpForce = 1000f;

	public FluxMovement ()
	{

	}

	public override void OnJump(Rigidbody2D rigidbody)
	{
		rigidbody.AddForce(new Vector2(0, jumpForce));
	}
}

