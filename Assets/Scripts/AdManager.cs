using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEditor.Advertisements;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{

	//[SerializeField] private LevelManager levelManager;
	//public float DELAY = 3.0f;

	//private string gameId = "3619589";
	//private bool testMode = true;

 //   //used so every 2 levels an ad plays
	//private int adCount = 0;

	//private string placementId = "video";
	//private string rewarded_video_ad = "rewardedVideo";


	//void Awake()
	//{

	//	levelManager.OnLevelEnded += AdCounter;

	//}


 //   void Start()
	//{
	//	Advertisement.Initialize(gameId, testMode);
	//}


 //   public void AdCounter(int level)
	//{
	//	adCount++;

 //       if(adCount % 2 == 0)
	//	{
	//		ShowVideoAd();
	//		adCount = 0;
	//	}

	//}


 //   void ShowVideoAd()
	//{

	//	Debug.Log(Advertisement.IsReady());
	//	if (Advertisement.IsReady())
	//	{

	//		Debug.Log(Advertisement.isInitialized);

	//		Advertisement.Show(placementId);
	//		Debug.Log("showed.");
	//	}
	//}


	//private void OnLevelEnded(int level)
	//{
	//	StartCoroutine(AdDelay());
	//}

	//private IEnumerator AdDelay()
	//{
	//	yield return new WaitForSeconds(DELAY);
	//	ShowVideoAd();
	//}









}
