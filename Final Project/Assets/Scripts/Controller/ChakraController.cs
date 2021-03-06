﻿using UnityEngine;
using System.Collections;

public abstract class ChakraController
{
    public enum Chakras : int { VIM, ETHER, FLUX, HUMAN };

    public GameObject gameObject;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;
    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;
    public Animator animator;
    public ParticleSystem particleSystem;
    public bool isAbilityActive;
	public bool isActivated;
	public bool isMoving;

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
		isMoving = false;
    }

    public abstract void OnCollisionEnter2D(Collision2D col);

    public abstract void FixedUpdate(bool isGrounded);

    public abstract void Update(bool isGrounded);

    public abstract void Ability(bool isGrounded);

    public abstract void OnStateChangeEnter();

    public abstract void OnStateChangeExit();

}
