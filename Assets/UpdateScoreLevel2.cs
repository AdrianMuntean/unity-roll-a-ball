using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreLevel2 : MonoBehaviour {

    public Text name1;
    public Text name2;
    public Text name3;

    public Text score1;
    public Text score2;
    public Text score3;

    private string highestScore_key = "HIGHESTSCORE_L2";
    private string highestScore2_key = "HIGHESTSCORE2_L2";
    private string highestScore3_key = "HIGHESTSCORE3_L2";

    private string highestScoreName_key = "HIGHESTSCORENAME_L2";
    private string highestScore2Name_key = "HIGHESTSCORE2NAME_L2";
    private string highestScore3Name_key = "HIGHESTSCORE3NAME_L2";

    public void Update()
    {
        getHighestValues();
    }

    public void getHighestValues()
    {
        int highScore1 = PlayerPrefs.GetInt(highestScore_key);
        if (highScore1 != 0 && PlayerPrefs.GetString(highestScoreName_key) != "")
        {
            score1.text = highScore1 + "";
            name1.text = PlayerPrefs.GetString(highestScoreName_key);
        }

        int highScore2 = PlayerPrefs.GetInt(highestScore2_key);
        if (highScore2 != 0 && PlayerPrefs.GetString(highestScore2Name_key) != "")
        {
            score2.text = highScore2 + "";
            name2.text = PlayerPrefs.GetString(highestScore2Name_key);
        }
        else
        {
            score2.text = "";
            name2.text = "";
        }
        int highScore3 = PlayerPrefs.GetInt(highestScore3_key);
        if (highScore3 != 0 && PlayerPrefs.GetString(highestScore3Name_key) != "")
        {
            score3.text = highScore3 + "";
            name3.text = PlayerPrefs.GetString(highestScore3Name_key);
        }
        else
        {
            score3.text = "";
            name3.text = "";
        }
    }
}
