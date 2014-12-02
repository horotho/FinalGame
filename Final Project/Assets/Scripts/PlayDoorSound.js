#pragma strict

var clip : AudioSource;

function OnTriggerEnter(other : Collider){
	if (other.gameObject.name == "Fence Door") {
		audio.Play();
	}
}