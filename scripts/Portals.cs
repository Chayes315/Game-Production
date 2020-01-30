using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public Transform destination;

    public bool isLeft;
    public bool isRight;
    public float distance = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (isRight)
        {
            destination = GameObject.FindGameObjectWithTag("LeftPortal").GetComponent<Transform>();
        }
        else if(!isRight)
        {
            destination = GameObject.FindGameObjectWithTag("RightPortal").GetComponent<Transform>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        transform.localRotation = Quaternion.Euler(180, 0, 0);

        if (Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
        }
    }
}