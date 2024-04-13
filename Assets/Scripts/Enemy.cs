using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    public float speed;

    GameObject player;
    Vector2 enemyDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyDirection = player.transform.position - transform.position;

        if (enemyDirection.x > 0)
        {
            sprite.flipX = false;
        }
        if (enemyDirection.x < 0)
        {
           
            sprite.flipX = true;
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + enemyDirection.normalized* speed * Time.deltaTime);
    }


}
