using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class envManager : MonoBehaviour
{
    public float speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {

        for(int i=0; i<100; i++){
            GameObject bee = (GameObject)Instantiate(Resources.Load("swarm"),new Vector3(0,0,0),Quaternion.identity);
        }
        //CreateBranch();
        //InvokeRepeating("CreateBranch", 0.1f, 3.0f);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateBranch(){
        Debug.Log("anybody there?");

        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane+5)); //will get the middle of the screen

        
        GameObject branch = (GameObject)Instantiate(Resources.Load("branch"),screenPosition,Quaternion.identity);


    }
}
