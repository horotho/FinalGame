using UnityEngine;
using System.Collections;

public abstract class ChakraController
{
	public bool isActivated
	{
		get; set;
	}

	public abstract void OnJump (Rigidbody2D rigidbody);
	public abstract void OnStateChange(SpriteRenderer renderer);
}
