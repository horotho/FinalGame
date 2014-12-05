using UnityEngine;
using System.Collections;

public class ClimbUpward : MonoBehaviour
{

    private bool canClimb;
    public GameObject player;
    public float maxSpeed = 3f;

    // Use this for initialization
    void Start()
    {
        canClimb = false;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");
        //Debug.Log (canClimb);
        if(canClimb == true)
        {
            // Deactivate gravity and create drag to simulate climbing.
            Physics2D.gravity = new Vector3(0, 0, 0);
            player.rigidbody2D.drag = 5;

            if(Input.GetKey(KeyCode.W))
            {
                //Debug.Log ("Player pressed W button");
                player.rigidbody2D.velocity = new Vector2(0, move * maxSpeed);
            }
            if(Input.GetKey(KeyCode.S))
            {
                //Debug.Log ("Player pressed S button");
                player.rigidbody2D.velocity = new Vector2(0, move * maxSpeed);
            }
        }
        else
        {
            Physics2D.gravity = new Vector3(0, -9.8f, 0);
            player.rigidbody2D.drag = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Check when Player enters trigger.
        if(col.gameObject.tag == "Player")
        {
            canClimb = true;
            //Debug.Log ("canClimb = true");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Check when Player exits trigger.
        if(col.gameObject.tag == "Player")
        {
            canClimb = false;
            //Debug.Log ("canClimb = false");
        }
    }
}
