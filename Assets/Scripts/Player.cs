using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    

    public Animator anim;
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    public float speed;
    Vector2 playerDirection;

    [Header("Arrow Atack")]
    public Arrow arrow;
    public float firerate;
    float timeCount;




    void Update()
    {
        playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        timeCount += Time.deltaTime;
        
        if (timeCount > firerate)
        {
            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler  (0, 0,angle);      
            
            Instantiate(arrow,transform.position, rotation);

            timeCount = 0;
        }

        
        if (playerDirection.x > 0)
        {
            sprite.flipX = false;    
        }
        if (playerDirection.x < 0)
        {
            sprite.flipX = true;
        }

        if (playerDirection.sqrMagnitude > 0)
        {
            anim.SetBool("walking", true);
        }
        else 
        {
            anim.SetBool("walking", false);
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerDirection.normalized * speed * Time.deltaTime);

    }

}



