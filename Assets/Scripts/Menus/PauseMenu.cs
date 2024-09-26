using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.Pause = false;
            Time.timeScale = 1;
            Destroy(gameObject);
        }

        if(Input.GetKeyDown(KeyCode.M)){
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