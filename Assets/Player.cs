using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x;
    float y;
    Rigidbody2D rb;
    float speed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");  
        Vector2 move = new Vector2(x, y);
        rb.velocity = move * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
             
            Destroy(collision.gameObject);
            GameManager.instance.RandomFood();
            GameManager.instance.point+=2;
            GameManager.instance.UpdatePoint();
            Debug.Log("Point: "+ GameManager.instance.point);
            if(GameManager.instance.point >= 10)
            {
                GameManager.instance.Victory();
                Debug.Log("Victory");
            }
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 touch = collision.GetContact(0).point;
            if (math.abs(touch.x) > 10)
            {
                Vector3 position = transform.position;
                transform.position = new Vector2(-position.x, position.y);
            }
            if (math.abs(touch.y) > 4)
            {
                Vector3 position = transform.position;
                transform.position = new Vector2(position.x, -position.y);
            }
        }
    }
}
