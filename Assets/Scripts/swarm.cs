using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class swarm : MonoBehaviour
{

    private Camera cam;
    public Vector3 swarmPos = new Vector3();
    Vector3 point = new Vector3();
    private int radius = 10;
    private bool shouldMove = true;
    public float speed = 1.0f;

    bool insideCircle(){
        if(Vector3.Distance(transform.position,point) < radius){
            return true;
        }
        else
            return false;
    }

    void Start()
    {
        cam = Camera.main;
        swarmPos.y = -10;
    }

    void OnGUI()
    {
        
        Event   currentEvent = Event.current;
        
        Vector2 mousePos = new Vector2();
        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

    }

    void Update(){
        // if(shouldMove){
        //     swarmPos.x = point.x;
        //     transform.position = swarmPos;
        // }
        Debug.Log(insideCircle());

        if(!insideCircle()){
            float step =  speed * Time.deltaTime; // calculate distance to move
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.MovePosition(Vector3.MoveTowards(transform.position, point, 0.2f));
        }


    }


    void OnTriggerEnter(Collider collision) {
        Debug.Log ("Hit Something");
        if (collision.gameObject.name.StartsWith("branch")) {            
            Debug.Log ("Hit Branch");
            shouldMove = false;
        }
        if (collision.tag == ("Bee")) {            
            Debug.Log ("Hit Bee");
        }
    }   
}
