using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BalloonMovment : MonoBehaviour
{
    #region FIELDS

    #region STATES
    [SerializeField]
    private GameObject explosionPrefab;

    private Rigidbody2D rb2d;

    private float balloonSpeed = 2f;
    private int balloonLife = 1;

    private SpriteRenderer renderSprite;

    private BalloonColor actualColor;

    private GameObject objectTag1;
    private HPHUD scriptTag1;
    private GameObject objectTag2;
    private BloonsHUD scriptTag2;
    private GameObject objectTag3;
    private HeliumHUD scriptTag3;

    private GameObject newExplosion;


    private Vector2 moveDirection;
    private Vector3 movePosition;
    #endregion

    #endregion

    void Start()
    {
        actualColor = BalloonColor.RED;
        rb2d = GetComponent<Rigidbody2D>();
        renderSprite = GetComponent<SpriteRenderer>();
        balloonSpeed = ChangeSpeed(actualColor);
        balloonLife = ChangeLife(actualColor);

        objectTag1 = GameObject.FindGameObjectWithTag("HP");
        scriptTag1 = objectTag1.GetComponent<HPHUD>();

        objectTag2 = GameObject.FindGameObjectWithTag("Bloon");
        scriptTag2 = objectTag2.GetComponent<BloonsHUD>();

        objectTag3 = GameObject.FindGameObjectWithTag("Helium");
        scriptTag3 = objectTag3.GetComponent<HeliumHUD>();

    }

    private void Update()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));



        if (Input.GetButtonDown("Upgrade") && scriptTag3.getHelium() >= 100 && actualColor != BalloonColor.METAL)
        {
           
            scriptTag3.ChangeHelium(scriptTag3.getHelium() - 100);

            actualColor = ChangeColor(actualColor, +1);
            renderSprite.sprite = ChangeSprite(actualColor);
            balloonSpeed = ChangeSpeed(actualColor);
            balloonLife = ChangeLife(actualColor);

            if (scriptTag1 != null)
            {
                scriptTag1.ChangeHP(balloonLife);
            }

            if (scriptTag2 != null)
            {
                scriptTag2.ChangeHP(balloonLife);
            }
        }


    }
    private void FixedUpdate()
    {
        movePosition = (balloonSpeed* Time.fixedDeltaTime * moveDirection.normalized) + rb2d.position;
        rb2d.MovePosition(movePosition);
    }



    #region METHODS

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Play POP animation on balloon

        
        if(collision.gameObject.tag == "Dart")
        {
            if(actualColor != BalloonColor.METAL)
            {
                newExplosion = Instantiate(explosionPrefab);
                newExplosion.transform.position = this.transform.position;
                if (actualColor != BalloonColor.RED)
                {
                    actualColor = ChangeColor(actualColor, -1);
                    renderSprite.sprite = ChangeSprite(actualColor);
                    balloonSpeed = ChangeSpeed(actualColor);
                    balloonLife = ChangeLife(actualColor);
                    if (scriptTag1 != null)
                    {
                        scriptTag1.ChangeHP(balloonLife);
                    }

                    if (scriptTag2 != null)
                    {
                        scriptTag2.ChangeHP(balloonLife);
                    }
                }

                else {
                    Destroy(gameObject);
                    balloonLife = ChangeLife(BalloonColor.DEAD);
                    MenuManager.Pause = true;
                    MenuManager.GoToMenu(MenuName.LoseMenu);
                }

                
                
            }
            

            Destroy(collision.gameObject);
            Destroy(newExplosion);
        }

        if (collision.gameObject.tag == "HeParticle")
        {

            scriptTag3.ChangeHelium(scriptTag3.getHelium() + 100);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Final")
        {
            MenuManager.Pause = true;
            MenuManager.GoToMenu(MenuName.WinMenu);
        }


    }

    private float ChangeSpeed(BalloonColor color)
    {
        float newSpeed = 2f;
        switch (color)
        {
            case BalloonColor.RED:
                newSpeed = 2f;
                break;

            case BalloonColor.BLUE:
                newSpeed = 3f;
                break;

            case BalloonColor.GREEN:
                newSpeed = 4f;
                break;

            case BalloonColor.YELLOW:
                newSpeed = 5f;
                break;

            case BalloonColor.PINK:
                newSpeed = 5f;
                break;

            case BalloonColor.BLACK:
                newSpeed = 6f;
                break;

            case BalloonColor.WHITE:
                newSpeed = 6f;
                break;

            case BalloonColor.RAINBOW:
                newSpeed = 7f;
                break;

            case BalloonColor.METAL:
                newSpeed = 3f;
                break;
        }

        return newSpeed;
    }

    private int ChangeLife(BalloonColor color)
    {
        int newLife = 1;

        switch (color)
        {
            case BalloonColor.DEAD:
                newLife = 0;
                break;
            case BalloonColor.RED:
                newLife = 1;
                break;

            case BalloonColor.BLUE:
                newLife = 2;
                break;

            case BalloonColor.GREEN:
                newLife = 3;
                break;

            case BalloonColor.YELLOW:
                newLife = 4;
                break;

            case BalloonColor.PINK:
                newLife = 5;
                break;

            case BalloonColor.BLACK:
                newLife = 6;
                break;

            case BalloonColor.WHITE:
                newLife = 7;
                break;

            case BalloonColor.RAINBOW:
                newLife = 8;
                break;

            case BalloonColor.METAL:
                newLife = 1000;
                break;
        }

        return newLife;
    }

    private BalloonColor ChangeColor(BalloonColor color, int delta)
    {
        BalloonColor newColor = color;

        switch (color)
        {
            case BalloonColor.RED:
                if(delta == +1)
                {
                    newColor = BalloonColor.BLUE;
                }
                break;

            case BalloonColor.BLUE:
                if (delta == +1)
                {
                    newColor = BalloonColor.GREEN;
                }
                else
                {
                    newColor = BalloonColor.RED;
                }
                break;

            case BalloonColor.GREEN:
                if (delta == +1)
                {
                    newColor = BalloonColor.YELLOW;
                }
                else
                {
                    newColor = BalloonColor.BLUE;
                }
                break;

            case BalloonColor.YELLOW:
                if (delta == +1)
                {
                    newColor = BalloonColor.PINK;
                }
                else
                {
                    newColor = BalloonColor.GREEN;
                }
                break;

            case BalloonColor.PINK:
                if (delta == +1)
                {
                    newColor = BalloonColor.BLACK;
                }
                else
                {
                    newColor = BalloonColor.YELLOW;
                }
                break;

            case BalloonColor.BLACK:
                if (delta == +1)
                {
                    newColor = BalloonColor.WHITE;
                }
                else
                {
                    newColor = BalloonColor.PINK;
                }
                break;

            case BalloonColor.WHITE:
                if (delta == +1)
                {
                    newColor = BalloonColor.RAINBOW;
                }
                else
                {
                    newColor = BalloonColor.BLACK;
                }
                break;

            case BalloonColor.RAINBOW:
                if (delta == +1)
                {
                    newColor = BalloonColor.METAL;
                }
                else
                {
                    newColor = BalloonColor.WHITE;
                }
                break;

            case BalloonColor.METAL:
                if (delta == -1)
                {
                    newColor = BalloonColor.RAINBOW;
                }
               
                break;
        }

        return newColor;
    }

    private Sprite ChangeSprite(BalloonColor color)
    {

        switch (color)
        {
            case BalloonColor.RED:
                return Resources.Load<Sprite>("Sprites/Balloons/RED");
                

            case BalloonColor.BLUE:
                return Resources.Load<Sprite>("Sprites/Balloons/BLUE");
              

            case BalloonColor.GREEN:
                return Resources.Load<Sprite>("Sprites/Balloons/GREEN");

            case BalloonColor.YELLOW:
                return Resources.Load<Sprite>("Sprites/Balloons/YELLOW");

            case BalloonColor.PINK:
                return Resources.Load<Sprite>("Sprites/Balloons/PINK");

            case BalloonColor.BLACK:
                return Resources.Load<Sprite>("Sprites/Balloons/BLACK");

            case BalloonColor.WHITE:
                return Resources.Load<Sprite>("Sprites/Balloons/WHITE");

            case BalloonColor.RAINBOW:
                return Resources.Load<Sprite>("Sprites/Balloons/RAINBOW");

            case BalloonColor.METAL:
                return Resources.Load<Sprite>("Sprites/Balloons/METAL");
        }
        return Resources.Load<Sprite>("Sprites/Balloons/ERROR");
    }

    #endregion
}
