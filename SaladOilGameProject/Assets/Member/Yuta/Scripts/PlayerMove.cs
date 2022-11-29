using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private float speed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Vector2 positon = transform.position;

        if(Input.GetKey("left"))
        {
            positon.x -= speed;
        }
        else if (Input.GetKey("right"))
        {
            positon.x += speed;
        }
        else if (Input.GetKey("up"))
        {
            positon.y += speed;
        }
        else if (Input.GetKey("down"))
        {
            positon.y -= speed;
        }

        transform.position = positon;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Beans")
        {
            Debug.Log("èEÇ¡ÇΩ");
            GameManger.beans -= 1;
            Destroy(collision.gameObject);
        }
    }
}
