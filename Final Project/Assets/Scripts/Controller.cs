using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
	private Animator anim;
	private bool facingRight = true;
	public float maxSpeed = 10f;
	public float jumpForce;

	private Vector3 originalPosition;
	private SpriteRenderer spriteRenderer;

	public Transform ground;
	public LayerMask mask;
	
	public bool grounded;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		originalPosition = transform.position;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate() 
	{
		float move = Input.GetAxis("Horizontal");
		grounded = Physics2D.OverlapCircle(ground.transform.position, 0.25f, mask);

		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

		if(move > 0 && !facingRight) Flip();
		else if(move < 0 && facingRight) Flip();

		anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
		anim.SetBool("Grounded", grounded);
	}

	void Update()
	{
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}

		if(Mathf.Abs(transform.position.y - originalPosition.y) > 100) transform.position = originalPosition;

		if(Input.GetKeyDown(KeyCode.Keypad1)) spriteRenderer.color = Color.red;
		else if(Input.GetKeyDown(KeyCode.Keypad2)) spriteRenderer.color = Color.green;
		else if(Input.GetKeyDown(KeyCode.Keypad3)) spriteRenderer.color = Color.blue;
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
