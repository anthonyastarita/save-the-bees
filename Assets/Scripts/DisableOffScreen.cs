using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOffScreen : MonoBehaviour
{
    public event Action OnDisable;

    private void OnBecameInvisible()
    {
        if(transform != null)
        {
            if(transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y)
            {
                OnDisable?.Invoke();
                gameObject.SetActive(false);
            }
            
        }
    }
}
