using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;

    private void Start () {
        offset = transform.position - player.position;
    }

    private void Update () {
        

       Vector3 targetPos = player.position + offset;
       targetPos.x = 0;
       targetPos.y = transform.position.y;
       transform.position = targetPos;
    }
}
