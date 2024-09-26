using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class MonkeyBehaviour : MonoBehaviour
{
    #region FIELDS

    [SerializeField] 
    private GameObject dartPrefab;
    [SerializeField]
    private DirectionEnum actualDirection;
    [SerializeField]
    private float frequency;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    private int frameCounter;

    public Timer attackTime;

    //Dart Variables
    GameObject dartObject;
    DartBehaviour dartScript;
    Vector3 position;


    float width;
    float length;

    #endregion
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();

        //Frequency of monkey attack
        attackTime = gameObject.AddComponent<Timer>();
        attackTime.Duration = frequency/4;
        attackTime.Run();


        if (spriteRenderer != null && spriteRenderer.sprite != null)
        {
            spriteRenderer.sprite = SpriteDirection(actualDirection);
            Vector2 spriteSize = spriteRenderer.bounds.size;
            width = spriteSize.x;
            length = spriteSize.y;
        }

        


    }

    // Update is called once per frame
    void Update()
    {
        if(attackTime.Finished && MenuManager.Pause == false)
        {
            position = rb2d.position;
            position += NewPosition(actualDirection);

            dartObject = Instantiate(dartPrefab);
            dartObject.transform.position = position;

            dartScript = dartObject.GetComponent<DartBehaviour>();
            dartScript.Constructor(actualDirection);

            attackTime.Duration = frequency;
            attackTime.Run();
        }
        frameCounter += 1;

        
    }

    #region METHODS
    public Vector3 NewPosition(DirectionEnum dir)
    {
        switch (dir)
        {
            case DirectionEnum.Left:
                return (new Vector3(-width/2, 0, 0));

            case DirectionEnum.Right:
                return (new Vector3(width/2,0 , 0));

            case DirectionEnum.Up:
                return (new Vector3(0, length/2 , 0));

            case DirectionEnum.Down:
                return (new Vector3(0, -length/2, 0));
        }

        return new Vector3(0,0,0);
    }

    public Sprite SpriteDirection(DirectionEnum dir)
    {
        switch (dir)
        {
            case DirectionEnum.Left:
                return Resources.Load<Sprite>("Sprites/Monkeys/Default/LEFT");

            case DirectionEnum.Right:
                return Resources.Load<Sprite>("Sprites/Monkeys/Default/RIGHT");

            case DirectionEnum.Up:
                return Resources.Load<Sprite>("Sprites/Monkeys/Default/UP");

            case DirectionEnum.Down:
                return Resources.Load<Sprite>("Sprites/Monkeys/Default/DOWN");
        }

        return Resources.Load<Sprite>("Sprites/Monkeys/Default/DOWN");
    }

    #endregion
}
