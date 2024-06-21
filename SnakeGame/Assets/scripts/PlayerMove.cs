using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector2 vector = Vector2.right;

    private List<Transform> list = new List<Transform>();
    public Transform pre;


    void Start()
    {
        list.Add(transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            vector = Vector2.up;       
        }else if (Input.GetKeyDown(KeyCode.S))
        {
            vector = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            vector = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            vector = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            list[i].position = list[i - 1].position;
        }


        transform.position = new Vector3(Mathf.Round(transform.position.x) + vector.x, Mathf.Round(transform.position.y) + vector.y, 0.0f);

    }

    public void grow()
    {
        Transform trans = Instantiate(pre);
        trans.position = list[list.Count - 1].position;
        list.Add(trans);
    }
    public void gameOver()
    {
        Debug.Log("gameOver");
        Time.timeScale = 0.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Food")
        {
            grow();
        }
        if(collision.tag == "Wall")
        {
            gameOver();
        }
    }
}
