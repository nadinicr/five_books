using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject player;
    private AudioSource forest;

    void Start()
    {
       forest = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        forest.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        forest.Stop();
    }
}
