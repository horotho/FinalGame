using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
	private Animator anim;
	private bool facingRight = true;
	public float maxSpeed = 10f;
	private Vector3 originalPosition;
	private SpriteRenderer spriteRenderer;
	public Transform ground;
	public LayerMask mask;
	public bool grounded;
	public ChakraController currentController;
	private ChakraController[] chakraControllers;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		originalPosition = transform.position;
		spriteRenderer = GetComponent<SpriteRenderer> ();

		chakraControllers = new ChakraController[4];
		chakraControllers [0] = new FluxChakraController ();
		chakraControllers [1] = new EtherChakraController ();
		chakraControllers [2] = new VimChakraController ();
		chakraControllers [3] = new HumanChakraController ();

		currentController = chakraControllers [3];
	}

	void SetControllerActive(string elementName)
	{
		if(elementName == "flux") chakraControllers[0].isActivated = true;
		else if (elementName == "vim") chakraControllers[2].isActivated = true;
		else if (elementName == "ether") chakraControllers[1].isActivated = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float move = Input.GetAxis ("Horizontal");
		grounded = Physics2D.OverlapCircle (ground.transform.position, 0.4f, mask);

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		anim.SetBool ("Grounded", grounded);
	}

	void Update ()
	{
		if (grounded && Input.GetKeyDown (KeyCode.Space))
		{
			currentController.OnJump (rigidbody2D);
		}

		if (Mathf.Abs (transform.position.y - originalPosition.y) > 100)
			transform.position = originalPosition;

		if (Input.GetKeyDown (KeyCode.Alpha1) && chakraControllers[0].isActivated)
		{
			currentController = chakraControllers[0];
			currentController.OnStateChange(spriteRenderer);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2) && chakraControllers[1].isActivated)
		{
			currentController = chakraControllers[1];
			currentController.OnStateChange(spriteRenderer);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)&& chakraControllers[2].isActivated)
		{
			currentController = chakraControllers[2];
			currentController.OnStateChange(spriteRenderer);
		}
			
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
