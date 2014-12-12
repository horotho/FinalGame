using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
	public Transform ground;
	public LayerMask mask;
	public bool grounded;
	public float maxSpeed = 10f;

    private Animator anim;
    private bool facingRight = true;
    private Vector3 originalPosition;
    private ChakraController[] chakraControllers;
	private ChakraController currentController;
    private KeyCode[] keyCodes;

	public bool movementAllowed {get; set;}

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        originalPosition = transform.position;

        chakraControllers = new ChakraController[4];
        chakraControllers[(int) ChakraController.Chakras.FLUX] = new FluxChakraController(gameObject);
        chakraControllers[(int) ChakraController.Chakras.ETHER] = new EtherChakraController(gameObject);
        chakraControllers[(int) ChakraController.Chakras.VIM] = new VimChakraController(gameObject);
        chakraControllers[(int) ChakraController.Chakras.HUMAN] = new HumanChakraController(gameObject);

        keyCodes = new KeyCode[4];
        keyCodes[(int) ChakraController.Chakras.FLUX] = KeyCode.Alpha2;
        keyCodes[(int) ChakraController.Chakras.ETHER] = KeyCode.Alpha1;
        keyCodes[(int) ChakraController.Chakras.VIM] = KeyCode.Alpha3;
        keyCodes[(int) ChakraController.Chakras.HUMAN] = KeyCode.Alpha4;

        currentController = chakraControllers[(int) ChakraController.Chakras.HUMAN];
		movementAllowed = true;
		grounded = true;
    }

    void SetControllerActive(int index)
    {
        chakraControllers[index].isActivated = true;
    }

    public bool IsChakraAbilityActive(int index)
    {
        return chakraControllers[index].isAbilityActive && chakraControllers[index] == currentController;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        grounded = Physics2D.OverlapCircle(ground.transform.position, 0.4f, mask);

		if(movementAllowed)
		{
			rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
			
			if(move > 0 && !facingRight)
				Flip();
			else if(move < 0 && facingRight)
				Flip();
			
			anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
			anim.SetFloat("vSpeed", rigidbody2D.velocity.y);

			currentController.isMoving = (rigidbody2D.velocity.y != 0) && move != 0;
		}
        	
        anim.SetBool("Grounded", grounded);
        currentController.FixedUpdate(grounded);
    }

    void Update()
    {
        currentController.Update(grounded);
        currentController.Ability(grounded);

        if(Mathf.Abs(transform.position.y - originalPosition.y) > 100)
            transform.position = originalPosition;


        for(int i = 0; i < keyCodes.Length; i++)
        {
            if(Input.GetKeyDown(keyCodes[i]) && chakraControllers[i].isActivated)
            {
                currentController.OnStateChangeExit();
                currentController = chakraControllers[i];
                currentController.OnStateChangeEnter();
            }
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        currentController.OnCollisionEnter2D(col);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
