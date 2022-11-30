using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    public bool Get_Water = false;
    public bool Set_Water = false;
    public bool Set_Ground = false;
    public static bool Revival = false;

    private void Start()
    {
        Get_Water = false;
        Set_Water = false;
        Set_Ground = false;
        Revival = false;

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (Input.GetKey("up"))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
        else if (Input.GetKey("down"))
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
        }
        else if (!Input.GetKey("left") && !Input.GetKey("right") && !Input.GetKey("up") && !Input.GetKey("down"))
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    void Update()
    {
        if (Set_Water == true)
        {
            if (Input.GetKey(KeyCode.B))
            {
                Debug.Log("êÖÉQÉbÉgÇæÇ∫");
                Get_Water = true;
            }
        }

        if (Set_Ground == true)
        {
            if (Input.GetKey(KeyCode.B) && Get_Water)
            {
                Debug.Log("î®Ç…êÖÇÉXÉçÅ[ÉCÉì");
                Get_Water = false;
                Revival = true;
            }
            else if (Input.GetKey(KeyCode.B) && !Get_Water)
            {
                Debug.Log("êÖéùÇ¡Çƒñ≥Ç¢ÇÊ");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Beans")
        {
            Debug.Log("ìñÇΩÇ¡ÇΩ");
            GameManger.beans -= 1;
            Destroy(collision.gameObject);
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("êÖÇ…êGÇÍÇƒÇ‹Å`Ç∑");
            Set_Water = true;
        }

        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("î®ÇÃé¸ÇËÇæÇÊÅ`");
            Set_Ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("ó£ÇÍÇΩÇÊ");
            Set_Water = false;
        }
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("ó£ÇÍÇΩÇÊ");
            Set_Ground = false;
        }
    }
}
