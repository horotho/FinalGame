using UnityEngine;
using System.Collections;
using LibNoise;

public class FluxChakraController : ChakraController
{
    private float jumpForce = 250f;
    private Sprite originalSprite;
    private Vector2 originalSize;
    private float originalRadius;
    private GameObject waterPrefab;
    private GameObject[] prefabs;
	private AudioSource source;
	private bool space;

    private Gradient g;
    private GradientColorKey[] gck;
    private GradientAlphaKey[] gak;

    public FluxChakraController(GameObject gm)
        : base(gm)
    {
        particleSystem.renderer.sortingLayerID = spriteRenderer.sortingLayerID;
        particleSystem.renderer.sortingLayerName = spriteRenderer.sortingLayerName;

        originalSprite = spriteRenderer.sprite;
        originalSize = boxCollider2D.size;
        originalRadius = circleCollider2D.radius;

        waterPrefab = Resources.Load<GameObject>("Prefabs/fluxWater");
        prefabs = new GameObject[100];
       
        g = new Gradient();

        gck = new GradientColorKey[2];
        gck[0].color = new Color32(45, 113, 181, 255);
        gck[0].time = 0.0f;
        gck[1].color = new Color32(20, 76, 133, 255);
        gck[1].time = 3.0f;

        gak = new GradientAlphaKey[2];
        gak[0].alpha = 1.0f;
        gak[0].time = 0.0f;
        gak[1].alpha = 1.0f;
        gak[1].time = 3.0f;

        g.SetKeys(gck, gak);

		source = gameObject.AddComponent<AudioSource>();
		source.clip = Resources.Load<AudioClip>("water");
		source.volume = 0.2f;
    
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
    }

    public override void FixedUpdate(bool isGrounded)
    {
		Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + 0.5f * Vector3.up);
		space = Physics2D.OverlapCircle(gameObject.transform.position, 0.5f);
		Debug.Log(space);
    }

    public override void Update(bool isGrounded)
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
            rigidbody2D.AddForce(new Vector2(0, jumpForce));

        spriteRenderer.color = g.Evaluate(3 * Mathf.Cos(Time.time) * Mathf.Cos(Time.time));

		if(isMoving && isAbilityActive && !source.isPlaying) source.Play();
    }

    public override void Ability(bool isGrounded)
    {

		if(Input.GetKeyDown(KeyCode.F) && isGrounded)
        {
            //Debug.Log("CHANGED LIQUID STATE");

            isAbilityActive = !isAbilityActive;

            if(isAbilityActive)
            {
                Vector3 pos = gameObject.transform.position;
                for(int i = 0; i < prefabs.Length; i++)
                {
                    GameObject prefab = (GameObject) MonoBehaviour.Instantiate(waterPrefab, pos + new Vector3(Random.Range(-0.5f, 0.5f), 0.5f, 0), Quaternion.identity);
                    SpringJoint2D joint = prefab.GetComponent<SpringJoint2D>();
                    joint.connectedBody = rigidbody2D;
                    joint.distance *= Random.Range(1f, 2f);
                    joint.frequency *= Random.Range(1f, 2f);
                    prefabs[i] = prefab;
                }

                particleSystem.Stop();
                rigidbody2D.mass = 20;
                boxCollider2D.enabled = false;
                circleCollider2D.radius = 0.05f;
                spriteRenderer.sprite = null;
                animator.enabled = false;
				source.Play();
            }
            else
            {
                OnStateChangeExit();
            }
        }
    }

    public override void OnStateChangeEnter()
    {
        particleSystem.startColor = Color.blue;
    }

    public override void OnStateChangeExit()
    {
        for(int i = 0; i < prefabs.Length; i++)
        {
            if(prefabs[i] != null)
            {
                MonoBehaviour.Destroy(prefabs[i]);
            }
        }

        particleSystem.Play();
        rigidbody2D.mass = 1;
        boxCollider2D.enabled = true;
        circleCollider2D.radius = originalRadius;
        spriteRenderer.sprite = originalSprite;
        animator.enabled = true;
		isAbilityActive = false;
    }

}

