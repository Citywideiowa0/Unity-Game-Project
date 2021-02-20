using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameObject snowball;
    public Transform shotPoint;
    [SerializeField] private float speed;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        Shoot();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        for(int i = 0; i < 5; i++)
        {
            Vector2 thrust = new Vector2(1 * speed, 1 * speed);
            GameObject NewSnowball = (GameObject)Instantiate(snowball, shotPoint.position, shotPoint.rotation);
            NewSnowball.GetComponent<Rigidbody2D>().AddForce(thrust, ForceMode2D.Impulse);

            
            yield return new WaitForSeconds(2);

        }
       
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        

        
        
    }
    
}







