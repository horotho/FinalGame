using UnityEngine;
using System.Collections;

public class AnimatorController_UI : MonoBehaviour {

	public int score;
	public float hunger;
	public float hungerSpeed;

	//create timer
	public float timer = 0;

	void Start(){
		Screen.showCursor = false;
		hungerSpeed = 1f;
		hunger = 50f;
	}

	void Update(){
		timer += Time.deltaTime;
		hunger -= Time.deltaTime * hungerSpeed;
		if (hunger <= 0) {
			Application.LoadLevel ("Game Over");
		}	
		if (Input.GetKeyDown (KeyCode.M)) {
			Destroy(GameObject.FindWithTag("Music"));
			Application.LoadLevel ("Main Menu");
		}
		if (score >= 10) {
			Application.LoadLevel ("Denouement - Scene 1");
			}
	}

	void OnTriggerEnter( Collider other ) {
		if (other.tag == "Brain" || other.tag == "Brain 2" || other.tag == "Brain 3" || other.tag == "Brain 4" 
		    || other.tag == "Brain 5" || other.tag == "Brain 6" || other.tag == "Brain 7" || other.tag == "Brain 8" || other.tag == "Brain 9" || other.tag == "Brain 10")
		{
			score += 1;
			hunger = 50f;
			audio.Play();
			//Destroy(GameObject.FindWithTag("Brain"));
		}
	}

	/*function OnTriggerEnter( other : Collider ) {
		if (other.tag == "Player") {
			GameObject.Find("Fat_zombie").GetComponent(AnimatorController_UI).score += 1;
			//AnimatorController_UI.score += 1;
			audio.Play();
			Destroy(GameObject.FindWithTag("Brain"));
		}
		
	}*/

	void OnGUI()
	{
		if (timer < 6) {
			//Render the text  
			GUI.Label (new Rect (250, 250, 190, 50), "Must.... eat.... braaainsssss...");
				}

		GUI.Label(new Rect (20, 20, 200, 40), "Brains collected: " + score.ToString() + "/10" );
		GUI.Label(new Rect (20, 60, 200, 40), "Hunger: " + (int) hunger);
		GUI.Label(new Rect (20, 100, 200, 40), "Total time: " + (int) timer);
		GUI.Label(new Rect (20, 610, 200, 40), "Press M to quit");
		//GUILayout.Label("Press Fire2 to trigger Hi animation on 2nd layer");
		//GUILayout.Label("Interaction with CharacterController in OnAnimatorMove of IdleRunJump.cs");
	}
		
}
