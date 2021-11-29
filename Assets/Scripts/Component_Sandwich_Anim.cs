using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component_Sandwich_Anim : MonoBehaviour
{
    private bool Move_Manage = true;

    private void Start()
    {
        StartCoroutine(movingUpDown());
    }

    private void Update()
    {
        switch (Move_Manage)
        {
            case true:
                transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime);
                break;
            case false:
                transform.Translate(new Vector3(0, 0, -1)* Time.deltaTime);
                break;
        }
    }

    IEnumerator movingUpDown()
    {
        yield return new WaitForSeconds(1f);
        Move_Manage = false;
        yield return new WaitForSeconds(1f);
        Move_Manage = true;
        StartCoroutine(movingUpDown());
    }
}
