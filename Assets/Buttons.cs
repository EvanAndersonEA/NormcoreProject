using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Buttons : MonoBehaviour
{
    Vector3 redLocation = new Vector3(-3.153292f, -0.05000001f, -0.6004791f);
    Vector3 blueLocation = new Vector3(-5.8f, -0.05f, -4.7f);
    [SerializeField]
    GameObject player, scenePlayer;

    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindWithTag("Player");
        if (other.gameObject.name == "HeadMesh")
        {
            Debug.Log("Hit Camera trigger");
            Teleport();
        }

        if (other.gameObject.name == "RightHandModel")
        {
            Debug.Log("Hit hand trigger");
            Teleport();
        }

        if (other.gameObject.name == "LeftHandModel")
        {
            Debug.Log("Hit hand trigger");
            Teleport();
        }
    }

    public void Teleport()
    {
        Destroy(GameObject.FindWithTag("GameController"));
        if(gameObject.name == "RedButton")
        {
            player.GetComponent<Transform>().position = redLocation;
            scenePlayer.GetComponent<Transform>().position = redLocation;
        }
        else if(gameObject.name == "BlueButton")
        {
            player.GetComponent<Transform>().position = blueLocation;
            scenePlayer.GetComponent<Transform>().position = blueLocation;
        }
    }

}
