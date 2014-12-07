using UnityEngine;
using System.Collections;

public class FluxChakraController : ChakraController
{
    private float jumpForce = 200f;
    private Sprite originalSprite;
    private Vector2 originalSize;
    private float originalRadius;

    public FluxChakraController(GameObject gm)
        : base(gm)
    {
        originalSprite = spriteRenderer.sprite;
        originalSize = boxCollider2D.size;
        originalRadius = circleCollider2D.radius;
    }

    public override void Jump(bool isGrounded)
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
    }

    public override void Ability(bool isGrounded)
    {
        if(Input.GetKeyDown(KeyCode.F) && isGrounded)
        {
            Debug.Log("CHANGED LIQUID STATE");

            isAbilityActive = !isAbilityActive;

            if(isAbilityActive)
            {
                boxCollider2D.size = new Vector2(0.07f, 0.07f);
                circleCollider2D.radius = 0;
                spriteRenderer.sprite = null;
                animator.enabled = false;
            }
            else
            {
                boxCollider2D.size = originalSize;
                circleCollider2D.radius = originalRadius;
                spriteRenderer.sprite = originalSprite;
                animator.enabled = true;
            }
        }
    }

    public override void Climb()
    {

    }

    public override void OnStateChangeEnter()
    {
        spriteRenderer.color = Color.blue;
    }

    public override void OnStateChangeExit()
    {
        boxCollider2D.size = originalSize;
        circleCollider2D.radius = originalRadius;
        spriteRenderer.sprite = originalSprite;
        spriteRenderer.color = Color.white;
    }

}

