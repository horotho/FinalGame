using UnityEngine;
using System.Collections;

public class WaterProcedural : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Floor")
            particleSystem.Emit(20);
    }
}
