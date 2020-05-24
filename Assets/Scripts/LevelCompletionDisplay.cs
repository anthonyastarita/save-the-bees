using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEditor.Advertisements;

public class LevelCompletionDisplay : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject display;


    //specific for andriod
    private string gameId = "3619589";

    //keep this true before deployment otherwise we get flagged for fraud
    private bool testMode = true;

    //used so every 2 levels an ad plays
    private int adCount = 0;

    private string placementId = "video";
    private string rewarded_video_ad = "rewardedVideo";



    private Button nextLevelButton;

    public event Action OnClick;

    private const float DISPLAY_DELAY = 2.5f;

    private void Awake()
    {

        Advertisement.Initialize(gameId, testMode);

        nextLevelButton = GetComponentInChildren<Button>(includeInactive: true);
        nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);

        levelManager.OnLevelEnded += OnLevelEnded;

        Display(false);
    }

    private void OnLevelEnded(int level)
    {
        StartCoroutine(DisplayDelay());
    }

    private IEnumerator DisplayDelay()
    {
        yield return new WaitForSeconds(DISPLAY_DELAY);
        Display();
    }

    private void Display(bool show = true)
    {
        display.gameObject.SetActive(show);
    }

    private void OnNextLevelButtonClicked()
    {

        //todo: add advertisement here
        ShowSimpleVideoAd();

        OnClick?.Invoke();
        Display(false);


    }



    void ShowSimpleVideoAd()
    {
        adCount++;
        if (adCount % 2 == 0)
        {
            Debug.Log(Advertisement.IsReady());
            if (Advertisement.IsReady())
            {

                Debug.Log(Advertisement.isInitialized);

                Advertisement.Show(placementId);
                Debug.Log("showed.");
            }
            adCount = 0;
        }

    }






}
