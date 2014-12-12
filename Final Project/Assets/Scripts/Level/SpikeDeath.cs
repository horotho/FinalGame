using UnityEngine;
using System.Collections;

public class SpikeDeath : MonoBehaviour {

	public GameObject player;
	private AudioClip clip;

	// Use this for initialization
	void Start () 
	{
		clip = Resources.Load<AudioClip>("squish");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Player") {
			AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
			//Application.LoadLevel(Application.loadedLevel);
			Controller c = col.gameObject.GetComponent<Controller>();
			ScreenFade.Instance.Fade(Application.loadedLevel, 0.2f, c);
		}
	}
}
