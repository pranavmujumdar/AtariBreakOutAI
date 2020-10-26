using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public PaddleAgent agent;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            //Debug.Log("Dead");
            //Debug.Log(collision.gameObject.tag);
            agent.Died();
        }
        if (collision.gameObject.CompareTag("Brick"))
        {
            //Debug.Log("Dead");
            // Debug.Log(collision.gameObject.tag);
            agent.Scored();
        }
        if (collision.gameObject.CompareTag("Paddle"))
        {
            agent.hitPaddle();
        }
    }

}
