using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regularBee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if(collision.gameObject.tag == "branch")
		{
            Debug.Log("Bee Collided");
            ContactPoint2D contact = collision.contacts[0];

            //transform.position = contact.point;
            Destroy(gameObject);
        }
        

    }

}
