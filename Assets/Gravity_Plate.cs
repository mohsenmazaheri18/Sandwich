using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Plate : MonoBehaviour
{
    public float gravity = -9.81f;
    public Rigidbody rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        var rigidbodyVelocity = rigidbody.velocity;
        
        rigidbodyVelocity.y = Mathf.Sqrt(1 * -2f * gravity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
