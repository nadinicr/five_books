using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate_animation : MonoBehaviour
{
    public GameObject player;
    private AudioSource gate_audio;
    private Animator gate_anim;

    private bool op_cl = false;

    void Start()
    {
        gate_anim = this.GetComponent<Animator>();
        gate_audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float d = Vector3.Distance(transform.position, player.transform.position);

        if (d <= 5 && Input.GetKeyDown(KeyCode.E))
        {
            if (op_cl == false)
            {
                gate_anim.SetBool("open", true);
                gate_anim.SetBool("close", false);
                gate_audio.Play();
                op_cl = true;
            }
            else{
                gate_anim.SetBool("close", true);
                gate_anim.SetBool("open", false);
                gate_audio.Play();
                op_cl = false;
            }
        }
    }
}
