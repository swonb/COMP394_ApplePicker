using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    // New Oct.09
    void Awake()
    {
        // We will have a key in PlayerPrefs
        // Keyname: ApplePickerHighScore
        if (PlayerPrefs.HasKey("ApplePickerHighScore"))
        {
            score = PlayerPrefs.GetInt("ApplePickerHighScore");
        }

        PlayerPrefs.SetInt("ApplePickerHighScore", score);
    }

    static public int score = 100;  // can reference it as HighScore.score from other script


    // Update is called once per frame
    void Update()
    {
        Text highScoreTxt = this.GetComponent<Text>();
        highScoreTxt.text = "High Score: " + score;

        if (score > PlayerPrefs.GetInt("ApplePickerHighScore"))
        {
            PlayerPrefs.SetInt("ApplePickerHighScore", score);
        }
    }
}
