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
        particleSystem.renderer.sortingLayerID = spriteRenderer.sortingLayerID;
        particleSystem.renderer.sortingLayerName = spriteRenderer.sortingLayerName;

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

        if(isAbilityActive)
        {
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
            particleSystem.GetParticles(particles);
            float percent;
            ParticleSystem.Particle p;

            for(int i = 0; i < particles.Length; i++)
            {
                p = particles[i];
                percent = (p.lifetime - p.startLifetime)/(p.lifetime + p.startLifetime);
                particles[i].velocity = new Vector3(Random.value, Mathf.Cos((float) (2 * Mathf.PI * Time.time)), 0);
            }

            particleSystem.SetParticles(particles, particles.Length);
        }

        if(Input.GetKeyDown(KeyCode.F) && isGrounded)
        {
            Debug.Log("CHANGED LIQUID STATE");

            isAbilityActive = !isAbilityActive;

            if(isAbilityActive)
            {
                boxCollider2D.enabled = false;
                circleCollider2D.center += new Vector2(-0.5f, -0.1f);
                circleCollider2D.radius = 0.05f;
                spriteRenderer.sprite = null;
                animator.enabled = false;
            }
            else
            {
                boxCollider2D.enabled = true;
                circleCollider2D.center -= new Vector2(-0.5f, -0.1f);
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

