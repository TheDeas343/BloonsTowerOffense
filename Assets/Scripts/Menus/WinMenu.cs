using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            Time.timeScale = 1;
            MenuManager.Pause = false;
            Destroy(gameObject);
            MenuManager.GoToMenu(MenuName.MainMenu);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            MenuManager.Pause = false;
            Destroy(gameObject);
            MenuManager.GoToMenu(MenuName.Level01);
        }
    }
}
