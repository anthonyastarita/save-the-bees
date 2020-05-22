using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpeed : MonoBehaviour
{
    //[SerializeField] private LevelManager levelManager;
    private Rigidbody2D rb;
    private float speed;
    //private int level => levelManager.CurrentLevel;


    void Awake(){
        rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rb.bodyType = RigidbodyType2D.Kinematic;
        speed = -10.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0.0f, (speed));
    }
}
