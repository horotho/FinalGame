using UnityEngine;
using System.Collections;

public class FluxChakraController : ChakraController
{
	private float jumpForce = 200f;
	private bool isLiquid;
	private Sprite original;
	private ParticleSystem ps;
	private Animator animator;
	private BoxCollider2D bc2d;
	private CircleCollider2D cc2d;
	private Vector2 bsize;
	private float radius;
	
	public FluxChakraController (GameObject gm) : base(gm)
	{
		isLiquid = false;
		original = spriteRenderer.sprite;
		ps = gameObject.GetComponent<ParticleSystem>();
		animator = gameObject.GetComponent<Animator>();


		bc2d =  gameObject.GetComponent<BoxCollider2D>();
		bsize = bc2d.size;

		cc2d =  gameObject.GetComponent<CircleCollider2D>();
		radius = cc2d.radius;
	}
	
	public override void Jump (bool isGrounded)
	{
		if(isGrounded && Input.GetKeyDown(KeyCode.Space))
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
	}
	
	public override void Ability ()
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
			Debug.Log("CHANGED LIQUID STATE");

			isLiquid = !isLiquid;

			if(isLiquid)
			{
				bc2d.size = new Vector2(0.07f, 1);
				cc2d.radius = 0;
				spriteRenderer.sprite = null;
				animator.enabled = false;
			}
			else
			{
				bc2d.size = bsize;
				cc2d.radius = radius;
				spriteRenderer.sprite = original;
				animator.enabled = true;
			}
		}
	}
	
	public override void Climb ()
	{
		
	}
	
	public override void OnStateChange ()
	{
		spriteRenderer.color = Color.blue;
	}
}

