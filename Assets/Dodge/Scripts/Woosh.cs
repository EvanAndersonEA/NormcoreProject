using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woosh : MonoBehaviour
{
    new public AudioSource src;

    private void OnTriggerEnter(Collider other)
    {
        src.PlayOneShot(src.clip);
    }
}
