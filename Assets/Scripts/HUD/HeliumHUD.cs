using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliumHUD : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private int HeliumVolume;
    string path;
    void Start()
    {
        HeliumVolume = 0;
        path = "Sprites/HUD/VolumeNumbers/" + HeliumVolume ;
    
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>(path);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ChangeHelium(int newHelium)
    {
        HeliumVolume = newHelium ;
        if (HeliumVolume <= 1000)
        {
            path = "Sprites/HUD/VolumeNumbers/" + HeliumVolume;
            spriteRenderer.sprite = Resources.Load<Sprite>(path);

        }
    }

    public int getHelium()
    {
        return HeliumVolume;
    }
}
