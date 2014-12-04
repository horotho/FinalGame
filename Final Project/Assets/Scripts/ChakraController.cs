using UnityEngine;
using System.Collections;

public abstract class ChakraController
{
	public bool isActivated {
		get;
		set;
	}

	public Rigidbody2D rigidbody2D;
	public SpriteRenderer renderer;

	protected ChakraController(Rigidbody2D rb, SpriteRenderer rd)
	{
		this.rigidbody2D = rb;
		this.renderer = rd;
		isActivated = false;
	}

	public abstract void Jump (bool isGrounded);

	public abstract void Ability ();

	public abstract void Climb ();

	public abstract void OnStateChange ();
}
