using UnityEngine;
using System.Collections;

public class VimChakraController : ChakraController
{
    private float jumpForce = 200f;
    private float groundPoundForce = -1000f;
    private bool isGroundPounding;

    private Gradient g;
    private GradientColorKey[] gck;
    private GradientAlphaKey[] gak;

    public VimChakraController(GameObject gm)
        : base(gm)
    {

        g = new Gradient();

        gck = new GradientColorKey[2];
        gck[0].color = new Color32(27, 207, 69, 255);
        gck[0].time = 0.0f;
        gck[1].color = new Color32(12, 148, 44, 255);
        gck[1].time = 3.0f;

        gak = new GradientAlphaKey[2];
        gak[0].alpha = 1.0f;
        gak[0].time = 0.0f;
        gak[1].alpha = 1.0f;
        gak[1].time = 3.0f;

        g.SetKeys(gck, gak);

        isGroundPounding = false;
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if(isGroundPounding)
        {
            MonoBehaviour.Destroy(col.gameObject);
        }

        isGroundPounding = false;
    }

    public override void FixedUpdate(bool isGrounded)
    {

    }

    public override void Update(bool isGrounded)
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
            rigidbody2D.AddForce(new Vector2(0, jumpForce));

        spriteRenderer.color = g.Evaluate(3 * Mathf.Cos(Time.time) * Mathf.Cos(Time.time));
    }

    public override void Ability(bool isGrounded)
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            isAbilityActive = true;
        }

        if(Input.GetKeyDown(KeyCode.F) && !isGrounded && !isGroundPounding)
        {
            isGroundPounding = true;
            rigidbody2D.AddForce(new Vector2(0, groundPoundForce));
        }
    }

    public override void OnStateChangeEnter()
    {
        particleSystem.startColor = Color.green;
    }

    public override void OnStateChangeExit()
    {
        isAbilityActive = false;
    }
}

