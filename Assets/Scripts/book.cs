using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book : MonoBehaviour
{

    public GameObject player;
    private AudioSource get_book;

    void Start()
    {
        get_book = this.GetComponent<AudioSource>();
    }

   
    void Update()
    {
        float d = Vector3.Distance(this.transform.position, player.transform.position);

        if (d <= 2 && Input.GetKeyDown(KeyCode.E))
        {
            get_book.Play();
        }
    }
}
