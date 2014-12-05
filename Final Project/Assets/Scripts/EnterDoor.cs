using UnityEngine;
using System.Collections;

public class EnterDoor : MonoBehaviour
{

    static public int level = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            level++;
            Debug.Log("Entered Door");
            Application.LoadLevel("Level " + level);
        }
    }
}
