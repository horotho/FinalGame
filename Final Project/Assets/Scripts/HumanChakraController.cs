using UnityEngine;
using System.Collections;

public class HumanChakraController : ChakraController
{
    private float jumpForce = 200f;

    public HumanChakraController(GameObject gm)
        : base(gm)
    {
        this.isActivated = true;
    }

    public override void FixedUpdate(bool isGrounded)
    {

    }

    public override void Update(bool isGrounded)
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
    }

    public override void Ability(bool isGrounded)
    {

    }

    public override void OnStateChangeEnter()
    {
        spriteRenderer.color = Color.white;
    }

    public override void OnStateChangeExit()
    {

    }

}

