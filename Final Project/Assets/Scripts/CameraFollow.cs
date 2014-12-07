using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera.orthographicSize = 6;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        transform.position = new Vector3(pos.x, pos.y, pos.z - 10);
    }
}
