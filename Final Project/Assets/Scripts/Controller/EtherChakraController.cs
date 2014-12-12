using UnityEngine;
using System.Collections;

public class EtherChakraController : ChakraController
{
    private float jumpForce = 22.5f;
    private GameObject prefabParticle, instParticle;
    private bool isAirborne;

    private Gradient g;
    private GradientColorKey[] gck;
    private GradientAlphaKey[] gak;

    public EtherChakraController(GameObject gm)
        : base(gm)
    {
        prefabParticle = Resources.Load<GameObject>("Prefabs/etherParticle");
        instParticle = (GameObject) MonoBehaviour.Instantiate(prefabParticle, gameObject.transform.position, Quaternion.identity);
        instParticle.particleSystem.Stop();
        isAirborne = false;

        g = new Gradient();

        gck = new GradientColorKey[2];
        gck[0].color = new Color32(222, 24, 24, 255);
        gck[0].time = 0.0f;
        gck[1].color = new Color32(186, 0, 0, 255);
        gck[1].time = 3.0f;

        gak = new GradientAlphaKey[2];
        gak[0].alpha = 1.0f;
        gak[0].time = 0.0f;
        gak[1].alpha = 1.0f;
        gak[1].time = 3.0f;

        g.SetKeys(gck, gak);
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
    }

    public override void FixedUpdate(bool isGrounded)
    {
        if(Input.GetKey(KeyCode.Space))
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
    }

    public override void Update(bool isGrounded)
    {
        spriteRenderer.color = g.Evaluate(3 * Mathf.Cos(Time.time) * Mathf.Cos(Time.time));
    }

    public override void Ability(bool isGrounded)
    {
        if(!isGrounded && !isAirborne)
        {
            isAirborne = true;
            instParticle.particleSystem.Play();
            particleSystem.Stop();
        }
        else if(isGrounded)
        {
            isAirborne = false;
            instParticle.particleSystem.Stop();
            particleSystem.Play();
        }
        else if(isAirborne)
        {
            instParticle.transform.position = gameObject.transform.position + new Vector3(0, -0.25f, 0);
        }
    }

    public override void OnStateChangeEnter()
    {
        particleSystem.startColor = Color.red;
    }

    public override void OnStateChangeExit()
    {
		spriteRenderer.color = Color.white;
        particleSystem.Play();
        instParticle.particleSystem.Stop();
        isAirborne = false;
    }
}

