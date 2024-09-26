using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetButtonDown("Upgrade"))
        {
            MenuManager.GoToMenu(MenuName.Level01);
        }
    }
}