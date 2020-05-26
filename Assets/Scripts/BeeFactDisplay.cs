using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeFactDisplay : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Text text;

    private string RandomBeeFact => BEE_FACTS[Random.Range(0, BEE_FACTS.Count)];

    private readonly List<string> BEE_FACTS = new List<string>()
    {
        "Honey bees must gather nectar from two million flowers to make one pound of honey.",
        "One bee has to fly about 90,000 miles – three times around the globe – to make one pound of honey.",
        "The average bee will make only 1/12th of a teaspoon of honey in its lifetime.",
        "The bees’ buzz is the sound made by their wings which beat 11,400 times per minute.",
        "The honey bee is the only insect that produces food eaten by people",
        "Male honey bees have no stinger and do no work.",
        "A colony of bees consists of 20,000-60,000 honey bees and one queen.",
        "Honey bees communicate with one another by dancing.",
        "A honey bee visits 50 to 100 flowers during a collection trip.",
        "Bees have 5 eyes and 6 legs.",

    };

    private void Awake()
    {
        levelManager.OnLevelEnded += OnLevelEnded;
    }

    private void OnLevelEnded(int level)
    {
        text.text = RandomBeeFact;
    }

}
