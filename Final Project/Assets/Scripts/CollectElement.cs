using UnityEngine;
using System.Collections;

public class CollectElement : MonoBehaviour
{
    public ParticleSystem system;
    public string elementName;
    private InGameMenu menu;

    void Start()
    {
        GameObject indicator = GameObject.FindGameObjectWithTag("Indicator");
        menu = indicator.GetComponent<InGameMenu>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Check if Player collides with the element.
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.BroadcastMessage("SetControllerActive", GetIndexFromTag(gameObject.tag));
            menu.SetIndicatorActive(gameObject.tag);

            Debug.Log("Collected " + this.gameObject.name);

            // Start the coroutine that Plays() and Stops() the particle system.
            StartCoroutine(CollectionEmitter());

            // Deactivate renderer for the element before object is completely destroyed.
            this.gameObject.renderer.enabled = false;
        }
    }

    // Coroutine to start and stop the emitter, then destroy.
    IEnumerator CollectionEmitter()
    {
        system.Play();
        yield return new WaitForSeconds(1f);
        system.Stop();
        Destroy(this.gameObject);
    }

    public int GetIndexFromTag(string tag)
    {
        if(tag == "VIM") return (int) ChakraController.Chakras.VIM;
        else if(tag == "ETHER") return (int) ChakraController.Chakras.ETHER;
        else if(tag == "FLUX") return (int) ChakraController.Chakras.FLUX;

        return -1;
    }
}
