using UnityEngine;
using System.Collections;

public class EnterDoor : MonoBehaviour
{

    static public int level = 1;

    // Use this for initialization
    void Start()
    {
		level++;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //Debug.Log("Entered Door");
            //Application.LoadLevel("Level " + level);
			//ScreenFade.Instance.Fade(level, 1, col.gameObject.GetComponent<Controller>());
			Controller c = col.gameObject.GetComponent<Controller>();
			ScreenFade.Instance.Fade(Application.loadedLevel + 1, 0.1f, c);
        }
    }
}
