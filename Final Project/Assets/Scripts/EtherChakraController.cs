using UnityEngine;
using System.Collections;

public class EtherChakraController : ChakraController
{
    private float jumpForce = 22.5f;
    private GameObject prefabParticle, instParticle;
    private bool isAirborne;

    public EtherChakraController(GameObject gm)
        : base(gm)
    {
        prefabParticle = Resources.Load<GameObject>("Prefabs/etherParticle");
        instParticle = (GameObject) MonoBehaviour.Instantiate(prefabParticle, gameObject.transform.position, Quaternion.identity);
        instParticle.particleSystem.Stop();
        isAirborne = false;
    }


    public override void FixedUpdate(bool isGrounded)
    {
        if(Input.GetKey(KeyCode.Space))
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
    }

    public override void Update(bool isGrounded)
    {

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
        spriteRenderer.color = Color.red;
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

