using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonsHUD : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int HP;
    string path;
    void Start()
    {
        HP = 1;
        path = "Sprites/ActualBalloon/" + HP;

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
        if (HP <= 8)
        {
            path = "Sprites/ActualBalloon/" + HP;
            spriteRenderer.sprite = Resources.Load<Sprite>(path);

        }
        else
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/ActualBalloon/9");
        }
    }

    #endregion
}
