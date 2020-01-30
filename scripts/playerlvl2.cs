using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerlvl2 : MonoBehaviour
{
    public float speed = 10.0f;

    private Vector2 direction = Vector2.zero;
    private int count;

    public Text winText;
    public Text countText;

    void Start()
    {

    }

    void Update()
    {
        ButtonPress();

        Movement();

        Rotate();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 4;
            SetCountText();
        }
        if (other.gameObject.CompareTag("PowerUp"))
        {
            other.gameObject.SetActive(false);
            count += 16;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= 872)
        {
            SceneManager.LoadScene(4);
        }
    }
    void ButtonPress()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }

    }

    void Movement()
    {
        transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime;
    }

    void Rotate()
    {
        if (direction == Vector2.left)
        {
            //transform.localScale = new Vector3(-1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (direction == Vector2.right)
        {
            //transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (direction == Vector2.up)
        {
            //transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 180, 90);
        }
        if (direction == Vector2.down)
        {
            //transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
    }

}