using UnityEngine;
using System.Collections;

public class CollectElement : MonoBehaviour {


	public ParticleSystem system;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Collected " + this.gameObject.name);
			StartCoroutine( Wait() );
			this.gameObject.renderer.enabled = false;
		}
	}

	IEnumerator Wait() {
		system.Play ();
		yield return new WaitForSeconds(.25f);
		system.Stop (); 
		Destroy(this.gameObject);
	}
}
