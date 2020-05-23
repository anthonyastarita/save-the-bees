using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{

    private string gameId = "3619589";
    private bool testMode = true;

    private string placementId = "video";
    private string rewarded_video_ad = "rewardedVideo";

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);

        Debug.Log("about to show:");


		
        Advertisement.Show(rewarded_video_ad);
        Debug.Log("showed.");

        
            
    }









}
