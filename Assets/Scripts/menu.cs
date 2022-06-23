using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    void Start()
    {

    }

    public void LoadGame()
    {
        SceneManager.LoadScene("game");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("howToPlay");
    }

    public void Credit()
    {
        SceneManager.LoadScene("credits");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
