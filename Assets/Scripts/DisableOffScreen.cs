using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOffScreen : MonoBehaviour
{

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
