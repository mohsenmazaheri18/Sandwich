using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    
    /*[SerializeField]
    private Transform target;
 
    [SerializeField]
    private Vector3 offsetPosition;
 
    [SerializeField]
    private Space offsetPositionSpace = Space.Self;
 
    [SerializeField]
    private bool lookAt = true;
 
    private void Update()
    {
        Refresh();
    }
 
    public void Refresh()
    {
        if(target == null)
        {
            Debug.LogWarning("Missing target ref !", this);
 
            return;
        }
 
        // compute position
        if(offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }
 
        // compute rotation
        if(lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }*/
    
    
    public GameObject player;
    Vector3 offset;

    public GameObject RotatePlayer;

    private void Start ()
    {
        offset = transform.position - player.transform.position;
    }

    private void Update ()
    {

        
       Vector3 targetPos = player.transform.position + offset;
       targetPos.x = 0;
       targetPos.y = transform.position.y;
       transform.position = targetPos;
       
    }
}
