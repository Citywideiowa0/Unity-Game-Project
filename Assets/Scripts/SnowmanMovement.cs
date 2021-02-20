// +----------------------+------------------------------------------------------------------
// |   Acknowledgements   |
// +----------------------+
// Written by: Michael Spicer and Carlos Piedrasanta

// Following a Bezier Curve: https://www.youtube.com/watch?v=11ofnLOE8pw&feature=emb_title





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

    /* Slide Path */
    [SerializeField]
    private Transform slidePath;

    /* Slide speed modifier when going down the slide */
    private float slideModifier = 1.05f;

    /* helper variables to keep track of position along slide */
    float tStart;
    float tEnd;

    /* Keep track if using slide or moving along the ground */
    bool onSlide;





    // +-----------------------+------------------------------------------------------------------
    // |  Basic Unity Methods  |
    // +-----------------------+

    /* Start is called before the first frame update */
    void Start()
    {
        // Initialize Snowman direction to left
        direction = Vector3.left;

        // Initialize Snowman moving along ground
        onSlide = false;
    }


    /* Update is called once per frame */
    void Update()
    {
        // Move Snowman according to 'direction' if not on slide
        if (!onSlide)
            this.transform.Translate(direction * Time.deltaTime * speed);
    }

    // +-----------------------+------------------------------------------------------------------
    // |  More Unity Methods   |
    // +-----------------------+

    /* Enter if collision with a trigger collider occurs*/
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Collided with Trigger");
        // if Snowman collided with the right boundary trigger collider
        if (other.gameObject.tag == "Slide Top" && !onSlide)
        {
            //Debug.Log("Collided with Slide Top");
            // Change 'direction' to right
            direction = Vector3.right;

            // Go down slide
            onSlide = true;
            StartCoroutine("UseSlide", "down");
        }

        if (other.gameObject.tag == "Slide Bot" && !onSlide)
        {
            //Debug.Log("Collided with Slide Top");
            // Change 'direction' to right
            direction = Vector3.right;

            // Go down slide
            onSlide = true;
            StartCoroutine("UseSlide", "up");
        }

        // if Snowman collided with the right boundary trigger collider
        if (other.gameObject.tag == "Right Boundary")
        {
            // Flip Snowman to face left
            // * Note: Snowman faces left by default
            transform.localScale = new Vector3(1, 1, 1);

            // Change 'direction' to left
            direction = Vector3.left;

            
        }
    }

    // +------------------------+------------------------------------------------------------------
    // |   Custom Procedures    |
    // +------------------------+

    private IEnumerator UseSlide(string path)
    {
        Debug.Log("Entered 'UseSlide' coroutine");
        Debug.Log(" Headed " + path);
        Vector3 p0 = slidePath.GetChild(0).position;
        Vector3 p1 = slidePath.GetChild(1).position;
        Vector3 p2 = slidePath.GetChild(2).position;
        Vector3 p3 = slidePath.GetChild(3).position;

        if (path == "down")
        {
            for (float t = 0f; t < .5f; t += Time.deltaTime / speed)
            {
                Debug.Log("Going Down Slide...");
                MoveAlongSlide(p0, p1, p2, p3, t);
                yield return null;
            }

            // Flip Snowman to face right
            transform.localScale = new Vector3(-1, 1, 1);

            for (float t = .5f; t <= 1f; t += Time.deltaTime * slideModifier)
            {
                Debug.Log("Going Down Slide...");
                MoveAlongSlide(p0, p1, p2, p3, t);
                yield return null;
            }
        }
        else if (path == "up")
        {
            for (float t = 1f; t > .5f; t -= Time.deltaTime * slideModifier)
            {
                Debug.Log("Going Up Slide...");
                MoveAlongSlide(p0, p1, p2, p3, t);
                yield return null;
            }

            // Flip Snowman to face right
            transform.localScale = new Vector3(-1, 1, 1);

            for (float t = .5f; t >= 0f; t -= Time.deltaTime / speed)
            {
                Debug.Log("Going Up Slide...");
                MoveAlongSlide(p0, p1, p2, p3, t);
                yield return null;
            }
        }

        onSlide = false;


    }


    // +------------------------+------------------------------------------------------------------
    // |    Helper Procedures   |
    // +------------------------+

    private void MoveAlongSlide(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        this.transform.position = Mathf.Pow(1 - t, 3) * p0 +
                                  3 * Mathf.Pow(1 - t, 2) * t * p1 +
                                  3 * (1 - t) * Mathf.Pow(t, 2) * p2 +
                                  Mathf.Pow(t, 3) * p3; ;
    }
}
