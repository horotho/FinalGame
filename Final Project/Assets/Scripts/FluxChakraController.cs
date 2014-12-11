using UnityEngine;
using System.Collections;

public class FluxChakraController : ChakraController
{
    private float jumpForce = 200f;
    private Sprite originalSprite;
    private Vector2 originalSize;
    private float originalRadius;
	private GameObject waterPrefab;
	private GameObject[] prefabs;

    public FluxChakraController(GameObject gm)
        : base(gm)
    {
        particleSystem.renderer.sortingLayerID = spriteRenderer.sortingLayerID;
        particleSystem.renderer.sortingLayerName = spriteRenderer.sortingLayerName;

        originalSprite = spriteRenderer.sprite;
        originalSize = boxCollider2D.size;
        originalRadius = circleCollider2D.radius;

		waterPrefab = Resources.Load<GameObject>("Prefabs/fluxWater");
		Debug.Log("Instantiation of water prefab " + (waterPrefab != null));

		prefabs = new GameObject[100];
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
//            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
//            particleSystem.GetParticles(particles);
//            float percent;
//            ParticleSystem.Particle p;
//
//            for(int i = 0; i < particles.Length; i++)
//            {
//                p = particles[i];
//                percent = (p.lifetime - p.startLifetime)/(p.lifetime + p.startLifetime);
//                particles[i].velocity = new Vector3(Random.value, Mathf.Cos((float) (2 * Mathf.PI * Time.time)), 0);
//            }
//
//            particleSystem.SetParticles(particles, particles.Length);
        }

        if(Input.GetKeyDown(KeyCode.F) && isGrounded)
        {
            Debug.Log("CHANGED LIQUID STATE");

            isAbilityActive = !isAbilityActive;

            if(isAbilityActive)
            {
				Vector3 pos = gameObject.transform.position;
				for(int i = 0; i < prefabs.Length; i++)
				{
					GameObject prefab = (GameObject) MonoBehaviour.Instantiate(waterPrefab, pos + new Vector3(Random.Range(-0.5f, 0.5f), 0.5f,  0), Quaternion.identity);
					SpringJoint2D joint = prefab.GetComponent<SpringJoint2D>();
					joint.connectedBody = rigidbody2D;
					prefabs[i] = prefab;
				}

				particleSystem.Stop();
				rigidbody2D.mass = 10;
                boxCollider2D.enabled = false;
                circleCollider2D.radius = 0.05f;
				spriteRenderer.sprite = null;
                animator.enabled = false;
            }
            else
            {
				OnStateChangeExit();
            }
        }

    }

    public override void OnStateChangeEnter()
    {
        spriteRenderer.color = Color.blue;
    }

    public override void OnStateChangeExit()
    {
		for(int i = 0; i < prefabs.Length; i++)
		{
			if(prefabs[i] != null) MonoBehaviour.Destroy(prefabs[i]);
		}

		particleSystem.Play();
		rigidbody2D.mass = 1;
		boxCollider2D.enabled = true;
		circleCollider2D.radius = originalRadius;
		spriteRenderer.sprite = originalSprite;
		animator.enabled = true;
		jumpForce = 200f;
    }

}

