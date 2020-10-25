using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Vector3 pos;
    public float speed = 2.5f;
    public float rightBound = 10f;
    public float leftBound = -10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(x, 0, 0);
        pos = transform.position;

        transform.position = new Vector3(Mathf.Clamp(pos.x, leftBound, rightBound), pos.y, pos.z);
    }
    
}
