using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static int score { get; private set; }
    float lastMatchingTime;
    int streakCount;
    float streakExpiryTime = 3;

    private void Start()
    {
        Inventory.instance.onMatching += onMatching;
        score = 0;
    }

    void onMatching() {
        if (Time.time < lastMatchingTime+streakExpiryTime)
        {
            streakCount++;
        }
        else
        {
            streakCount = 0;
        }
        lastMatchingTime = Time.time;

        score += 3 + (int)Mathf.Pow(2, streakCount);
    }
}
