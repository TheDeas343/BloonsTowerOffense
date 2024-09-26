using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPHUD : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int HP;
    string path;
    void Start()
    {
        HP = 1;
        path = "Sprites/HUD/HPNumbers/" + HP;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>(path);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    #region METHODS
    public void ChangeHP(int newHP)
    {
        HP = newHP;
        if(HP <= 8)
        {
        path = "Sprites/HUD/HPNumbers/" + HP;
        spriteRenderer.sprite = Resources.Load<Sprite>(path);

        }
        else
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/HUD/HPNumbers/infinity");
        }
    }

    #endregion
}
