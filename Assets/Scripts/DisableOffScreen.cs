using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOffScreen : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        if(transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y)
            gameObject.SetActive(false);
    }
}
