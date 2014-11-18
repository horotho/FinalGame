using UnityEngine;
using System.Collections;

public class EtherMovement : Movement
{
	private float jumpForce = 100f;
	
	public EtherMovement ()
	{
		
	}
	
	public override void OnJump(Rigidbody2D rigidbody)
	{
		rigidbody.AddForce(new Vector2(0, jumpForce));
	}
}

