using UnityEngine;
using System.Collections;

public abstract class ChakraController
{
    public bool isActivated
    {
        get;
        set;
    }
	
    public enum Chakras : int { VIM, ETHER, FLUX, HUMAN };

    public GameObject gameObject;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;
    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;
    public Animator animator;
    public ParticleSystem particleSystem;
    public bool isAbilityActive;

    protected ChakraController(GameObject gameObject)
    {
        this.gameObject = gameObject;
        this.spriteRenderer = (SpriteRenderer) gameObject.renderer;
        this.rigidbody2D = gameObject.rigidbody2D;
        this.boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        this.circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        this.animator = gameObject.GetComponent<Animator>();
        this.particleSystem = gameObject.GetComponent<ParticleSystem>();

        isActivated = false;
        isAbilityActive = false;
    }

    public abstract void Jump(bool isGrounded);

    public abstract void Ability(bool isGrounded);

    public abstract void Climb();

    public abstract void OnStateChangeEnter();

    public abstract void OnStateChangeExit();

}
