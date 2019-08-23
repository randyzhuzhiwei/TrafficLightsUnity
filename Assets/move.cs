using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 6.0F;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Vector3 moveDirection = Vector3.forward;
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }
}
