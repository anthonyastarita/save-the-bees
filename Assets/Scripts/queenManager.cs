using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queenManager : MonoBehaviour
{
    private Camera cam;
    public GameObject Queen;

    private Vector3 queenPos = new Vector3();
    private Vector3 swarmUnits;

    // Start is called before the first frame update
    void Start()
    {

        cam = Camera.main;
        queenPos.y = -5;

    }

    // Update is called once per frame
    void Update()
    {
        queenPos.y = -5;
        Queen.transform.position = Vector3.Lerp(Queen.transform.position, queenPos, 0.1f);
        //Debug.Log(Queen.transform.position + " " + queenPos);

    }

    void OnGUI()
    {

        Event currentEvent = Event.current;

        Vector2 mousePos = new Vector2();
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        queenPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, 0, cam.nearClipPlane));

    }

}
