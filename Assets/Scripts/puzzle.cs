using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour
{
    public GameObject book;
    public GameObject[] pedras;
    public Light[] luzes;
    public GameObject player;
    private int i;

    private AudioSource win;
    private AudioSource correct;

    void Start()
    {
        //AUDIOS
        AudioSource[] audios = GetComponents<AudioSource>();
        correct = audios[0];
        win = audios[1];
    }

    
    void Update()
    {
        //DISTANCIA ENTRE AS ROCHAS E O PLAYER
        float dr1 = Vector3.Distance(player.transform.position, pedras[0].transform.position);
        float dr2 = Vector3.Distance(player.transform.position, pedras[1].transform.position);
        float dr3 = Vector3.Distance(player.transform.position, pedras[2].transform.position);
        float dr4 = Vector3.Distance(player.transform.position, pedras[3].transform.position);

        if (dr1 <= 2 && Input.GetKeyDown(KeyCode.E))
        {
            if (pedras[i] == pedras[0])
            {
                correct.Play();
                luzes[0].GetComponent<Light>().color = Color.yellow;
                i++;
            }
        }

        if (dr2 <= 2 && Input.GetKeyDown(KeyCode.E))
        {
            if (pedras[i] == pedras[1])
            {
                correct.Play();
                luzes[1].GetComponent<Light>().color = Color.yellow;
                i++;
            }
        }

        if (dr3 <= 2 && Input.GetKeyDown(KeyCode.E))
        {
            if (pedras[i] == pedras[2])
            {
                correct.Play();
                luzes[2].GetComponent<Light>().color = Color.yellow;
                i++;
            }
        }

        if (dr4 <= 2 && Input.GetKeyDown(KeyCode.E))
        {
            if (pedras[i] == pedras[3])
            {
                i++;
            }
        }

        if (i == 4)
        {
            win.Play();
            book.GetComponent<Renderer>().enabled = true;
            luzes[0].GetComponent<Light>().color = Color.magenta;
            luzes[1].GetComponent<Light>().color = Color.magenta;
            luzes[2].GetComponent<Light>().color = Color.magenta;
            luzes[3].GetComponent<Light>().color = Color.magenta;
            i++;

        }
    }
}

