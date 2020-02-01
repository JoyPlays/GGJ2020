using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvasController : MonoBehaviour
{
    [SerializeField] GameObject mainMenu = null;
    [SerializeField] GameObject creditsMenu = null;

    public void StartGame ()
    {
        print("Begin game");
    }

    public void EnableCreditsMenu()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void DisableCreditsMenu()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Quit ()
    {
        print("Quit game");
        Application.Quit();
    }
}
