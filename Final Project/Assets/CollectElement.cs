using UnityEngine;
using System.Collections;

public class CollectElement : MonoBehaviour {
	
	public ParticleSystem system;

	void OnTriggerEnter2D(Collider2D col)
	{
		// Check if Player collides with the element.
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Collected " + this.gameObject.name);

			// Start the coroutine that Plays() and Stops() the particle system.
			StartCoroutine( CollectionEmitter() );

			// Deactivate renderer for the element before object is completely destroyed.
			this.gameObject.renderer.enabled = false;
		}
	}

	// Coroutine to start and stop the emitter, then destroy.
	IEnumerator CollectionEmitter() {
		system.Play ();
		yield return new WaitForSeconds(.25f);
		system.Stop ();
		Destroy(this.gameObject);
	}
}
