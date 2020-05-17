using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManager : MonoBehaviour
{

    public delegate void PassBranch();
    public static event PassBranch onPassBranch;


    void Awake()
    {
        onPassBranch();
    }


}
