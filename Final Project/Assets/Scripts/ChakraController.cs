using UnityEngine;
using System.Collections;

public abstract class ChakraController
{
	public bool isActivated {
		get;
		set;
	}

	public GameObject gameObject;
	public SpriteRenderer spriteRenderer;
	public Rigidbody2D rigidbody2D;

	protected ChakraController(GameObject gameObject)
	{
		this.gameObject = gameObject;
		this.spriteRenderer = (SpriteRenderer) gameObject.renderer;
		this.rigidbody2D = gameObject.rigidbody2D;
		isActivated = false;
	}

	public abstract void Jump (bool isGrounded);

	public abstract void Ability ();

	public abstract void Climb ();

	public abstract void OnStateChange ();
}
