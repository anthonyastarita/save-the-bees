using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryWhenOffScreen : MonoBehaviour
{
     void OnBecameInvisible() {
         Destroy(gameObject);
     }
}
