using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayBehavioour : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !MenuManager.Pause)
        {
            MenuManager.Pause = true;
            MenuManager.GoToMenu(MenuName.PauseMenu);
        }
    }
}
