using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerFreez : MonoBehaviour
{
    private Vector3 _transformPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _transformPosition = transform.position;
        _transformPosition.x = _transformPosition.x;
    }
}
