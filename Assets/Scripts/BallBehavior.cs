using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    Rigidbody rb;
    public float ballSpeed = 5f;
    Vector3 pos;
    

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(14f,14f, 0f);
    }

    public void resetBall()
    {
        rb.velocity = new Vector3(0f,0f,0f);
        transform.position = new Vector3(Mathf.Clamp(pos.x, -4f, 4f), pos.y, pos.z);
        rb.velocity = new Vector3(14f, 14f, 0f);
    }
}
