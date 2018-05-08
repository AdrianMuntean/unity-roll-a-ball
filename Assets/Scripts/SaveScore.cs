using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScore : MonoBehaviour {
    public Text score;
    public Text name;
    public Transform highScoreMenu;

    private string highestScore_key = "HIGHESTSCORE_L1";
    private string highestScore2_key = "HIGHESTSCORE2_L2";
    private string highestScore3_key = "HIGHESTSCORE3_L3";

    private string highestScoreName_key = "HIGHESTSCORENAME_L1";
    private string highestScore2Name_key = "HIGHESTSCORE2NAME_L2";
    private string highestScore3Name_key = "HIGHESTSCORE3NAME_L3";

    // Update is called once per frame
    void Update () {
		if (!highScoreMenu.gameObject.active || score.text == "")
        {
            return;
        }

        int highestScore = PlayerPrefs.GetInt(highestScore_key);
        if (highestScore == 0)
        {
            PlayerPrefs.SetInt(highestScore_key, int.Parse(score.text));
            PlayerPrefs.SetString(highestScoreName_key, name.text);
        } else
        {
            int highestScore2 = PlayerPrefs.GetInt(highestScore2_key);
            int highestScore3 = PlayerPrefs.GetInt(highestScore3_key);

            saveOnAppropriatePossition(highestScore, highestScore2, highestScore3);
        }

        name.text = "";
        score.text = "";
	}

    private void saveOnAppropriatePossition(int highestScore, int highestScore2, int highestScore3)
    {
        int userScore = int.Parse(score.text);

        if (userScore >= highestScore)
        {
            saveOnPosition1(userScore, highestScore, highestScore2, highestScore3);
        } else 
        if (userScore >= highestScore2)
        {
            saveOnPosition2(userScore, name.text, highestScore2, highestScore3);
        } else
        if (userScore >= highestScore3)
        {
            saveOnPosition3(userScore, name.text);
        }
    }

    private void saveOnPosition3(int userScore, string userName)
    {
        PlayerPrefs.SetInt(highestScore3_key, userScore);
        PlayerPrefs.SetString(highestScore3Name_key, userName);
    }

    private void saveOnPosition2(int userScore, string userName, int highestScore2, int highestScore3)
    {
        String name2 = PlayerPrefs.GetString(highestScore2Name_key);
        PlayerPrefs.SetString(highestScore2Name_key, userName);
        PlayerPrefs.SetInt(highestScore2_key, userScore);

        if (highestScore2 >= highestScore3)
        {
            saveOnPosition3(highestScore2, name2);
        }

    }

    private void saveOnPosition1(int userScore, int highestScore, int highestScore2, int highestScore3)
    {
        String name1 = PlayerPrefs.GetString(highestScoreName_key);

        PlayerPrefs.SetString(highestScoreName_key, name.text);
        PlayerPrefs.SetInt(highestScore_key, userScore);

        if (highestScore >= highestScore2)
        {
            saveOnPosition2(highestScore, name1, highestScore2, highestScore3);
        }
    }
}
