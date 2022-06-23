using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject[] livros;
    public Rigidbody rb;
    public Vector3 movement;
    public GameObject flower;
    public Canvas gameOver;

    //MENU SCORE
    book_score_manager bManager;

    private Animator animacao;
    private int livros_coletados;
    private AudioSource correr_audio;
    private AudioSource andar_audio;
    private AudioSource game_over;


    void Start()
    {
        //ANIMACAO
        animacao = this.GetComponent<Animator>();

        //AUDIO
        game_over = flower.GetComponent<AudioSource>();
        AudioSource[] audios_AC = GetComponents<AudioSource>();
        correr_audio = audios_AC[0];
        andar_audio = audios_AC[1];

        //RIGIDBODY
        rb = this.GetComponent<Rigidbody>();

        //SCORE MANAGER
        bManager = FindObjectOfType<book_score_manager>();
        bManager.Score = PlayerPrefs.GetInt("Score", 0);
    }


    void Update()
    {
        //ANDAR
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 2 * Time.deltaTime);
            animacao.SetBool("walking", true);

            //CORRER
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0, 0, 5 * Time.deltaTime);
                animacao.SetBool("walking", false);
                animacao.SetBool("running", true);
                andar_audio.Pause();
            }
            
            //AUDIO PLAY CORRER
            if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift))
            {
                correr_audio.Play();
            }

            //AUDIO STOP CORRER
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                animacao.SetBool("walking", true);
                animacao.SetBool("running", false);
                correr_audio.Stop();
            }
        }
       
        //AUDIO PLAY ANDAR E ANDAR DE COSTAS
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
       {
            andar_audio.Play();
       }

        //ANDAR DE COSTAS
        if (Input.GetKey(KeyCode.S))
       {
            transform.Translate(0, 0, -1 * Time.deltaTime);
            animacao.SetBool("walking_b", true);
       }

        //ROTACIONAR ESQUERDA
        if (Input.GetKey(KeyCode.A))
       {
            transform.Rotate(0, -200 * Time.deltaTime, 0);
       }

        //ROTACIONAR DIREIRA
        if (Input.GetKey(KeyCode.D))
       {
            transform.Rotate(0, 200 * Time.deltaTime, 0);
       }

        //PARAR DE CORRER QUANDO O W EH SOLTO ANTES
        if (Input.GetKeyUp(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
       {
            animacao.SetBool("walking", false);
            animacao.SetBool("running", false);
            correr_audio.Stop();
       }

        //ANDAR PARAR
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
       {
            animacao.SetBool("walking", false);
            animacao.SetBool("walking_b", false);
            animacao.SetBool("running", false);
            andar_audio.Stop();
       }

        //-------------------------------------------------------------------------------------------------

        //PEGAR LIVROS
        //1
        float d_0livros = Vector3.Distance(livros[0].transform.position, this.transform.position);
        if (d_0livros <= 2 && Input.GetKeyDown(KeyCode.E))
        {
            livros[0].GetComponent<Renderer>().enabled = false;
            livros_coletados++;
            bManager.Score++;
            Destroy(livros[0].GetComponent<Renderer>());
            if (livros_coletados == 5)
            {
                game_over.Play();
                gameOver.GetComponent<Canvas>().enabled = true;
            }
        }

        //2
        float d_1livros = Vector3.Distance(livros[1].transform.position, this.transform.position);
        if (d_1livros <= 2 && Input.GetKeyDown(KeyCode.E))
        {
            livros[1].GetComponent<Renderer>().enabled = false;
            livros_coletados++;
            bManager.Score++;
            Destroy(livros[1].GetComponent<Renderer>());
            if (livros_coletados == 5)
            {
                game_over.Play();
                gameOver.GetComponent<Canvas>().enabled = true;
            }
        }

        //3
        float d_2livros = Vector3.Distance(livros[2].transform.position, this.transform.position);
        if (d_2livros <= 2 && Input.GetKeyDown(KeyCode.E))
        {
            livros[2].GetComponent<Renderer>().enabled = false;
            livros_coletados++;
            bManager.Score++;
            Destroy(livros[2].GetComponent<Renderer>());
            if (livros_coletados == 5)
            {
                game_over.Play();
                gameOver.GetComponent<Canvas>().enabled = true;
            }
        }

        //4
        float d_3livros = Vector3.Distance(livros[3].transform.position, this.transform.position);
        if (d_3livros <= 2 && Input.GetKeyDown(KeyCode.E))
        {
            livros[3].GetComponent<Renderer>().enabled = false;
            livros_coletados++;
            bManager.Score++;
            Destroy(livros[3].GetComponent<Renderer>());
            if (livros_coletados == 5)
            {
                game_over.Play();
                gameOver.GetComponent<Canvas>().enabled = true;
            }
        }

        //5
        float d_4livros = Vector3.Distance(livros[4].transform.position, this.transform.position);
        if (d_4livros <= 2 && Input.GetKeyDown(KeyCode.E))
        {
            livros[4].GetComponent<Renderer>().enabled = false;
            livros_coletados++;
            bManager.Score++;
            Destroy(livros[4].GetComponent<Renderer>());
            if (livros_coletados == 5)
            {
                game_over.Play();
                gameOver.GetComponent<Canvas>().enabled = true;
            }
        }

        //-------------------------------------------------------------------------------------------------

        //SAIR
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            bManager.Score = 0;
            livros_coletados = 0;
            Application.Quit();

        }
    }
}
