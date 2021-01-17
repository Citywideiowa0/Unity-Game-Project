using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(direction.x);
        this.transform.Translate(direction * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Entered OnTrigger");
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Right Boundary")
        {
            Debug.Log("Right Boundary Collision");
            direction = Vector3.left;
        }

        if (other.gameObject.tag == "Left Boundary")
        {
            Debug.Log("Left Boundary Collision");
            direction = Vector3.right;
        }
    }
}
