using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBehaviour : MonoBehaviour
{
    #region FIELDS

    private Rigidbody2D rb2d;

    private Vector2 directionSpeed;

    private SpriteRenderer spriteRenderer;

    private DirectionEnum direction;
    

    private float speed = 3f;

    #endregion



    public void Constructor(DirectionEnum dir)
    {
        this.direction = dir;
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if (rb2d != null)
        {
            spriteRenderer = rb2d.GetComponent<SpriteRenderer>();
  
            directionSpeed = VelocityDirection(direction);
            rb2d.velocity = directionSpeed * speed;
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = SpriteDirection(direction);
        }
    }

    void Update()
    {
        if (transform.position.y < ScreenUtils.ScreenBottom ||
            transform.position.y > ScreenUtils.ScreenTop ||
            transform.position.x < ScreenUtils.ScreenLeft ||
            transform.position.x > ScreenUtils.ScreenRight)
        {

            Destroy(gameObject);
        }
    }

    #region METHODS

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Dart")
        {
            return;
        }
    }
    public Vector2 VelocityDirection(DirectionEnum dir)
    {
        switch (dir)
        {
            case DirectionEnum.Left:
                return (new Vector2(-1, 0));

            case DirectionEnum.Right:
                return (new Vector2(1, 0));

            case DirectionEnum.Up:
                return (new Vector2(0, 1));

            case DirectionEnum.Down:
                return (new Vector2(0, -1));
        }

        return new Vector2(0, 0);
    }

    public Sprite SpriteDirection(DirectionEnum dir)
    {
        switch (dir)
        {
            case DirectionEnum.Left:
                return Resources.Load<Sprite>("Sprites/Darts/LEFT");

            case DirectionEnum.Right:
                return Resources.Load<Sprite>("Sprites/Darts/RIGHT");

            case DirectionEnum.Up:
                return Resources.Load<Sprite>("Sprites/Darts/UP");

            case DirectionEnum.Down:
                return Resources.Load<Sprite>("Sprites/Darts/DOWN");
        }

        return Resources.Load<Sprite>("Sprites/Darts/DOWN");
    }

    #endregion
}
