using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    static bool pause = false;

    public static bool Pause
    {
        get { return pause; }

        set { pause = value; }
    }


    public static void GoToMenu(MenuName menu)
    {
        switch (menu)
        {
            case MenuName.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Level01:
                SceneManager.LoadScene("Level01");
                break;
            case MenuName.PauseMenu:
                Object.Instantiate(Resources.Load("Menus/PauseMenu"));
                break;
            case MenuName.LoseMenu:
                Object.Instantiate(Resources.Load("Menus/LoseMenu"));
                break;
            case MenuName.WinMenu:
                Object.Instantiate(Resources.Load("Menus/WinMenu"));
                break;
            

        }
    }
}