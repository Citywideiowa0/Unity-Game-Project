using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanMovement : MonoBehaviour
{

    // +----------------------+------------------------------------------------------------------
    // | Fields & Properties  |
    // +----------------------+

    /* Snowman Movement Speed */
    [SerializeField]
    private float speed = 1;

    /* Direction snowman is moving in */
    private Vector3 direction;


    // +-----------------------+------------------------------------------------------------------
    // |  Basic Unity Methods  |
    // +-----------------------+

    /* Start is called before the first frame update */
    void Start()
    {
        // Initialize Snowman direction to left
        direction = Vector3.left;
    }


    /* Update is called once per frame */
    void Update()
    {
        // Move Snowman according to 'direction'
        this.transform.Translate(direction * Time.deltaTime * speed);
    }

    // +-----------------------+------------------------------------------------------------------
    // |  More Unity Methods   |
    // +-----------------------+

    /* Enter if collision with a trigger collider occurs*/
    void OnTriggerEnter2D(Collider2D other)
    {
        // if Snowman collided with the right boundary trigger collider
        if (other.gameObject.tag == "Right Boundary")
            // Change 'direction' to left
            direction = Vector3.left;

        // if Snowman collided with the right boundary trigger collider
        if (other.gameObject.tag == "Left Boundary")
            // Change 'direction' to right
            direction = Vector3.right;
    }
}
