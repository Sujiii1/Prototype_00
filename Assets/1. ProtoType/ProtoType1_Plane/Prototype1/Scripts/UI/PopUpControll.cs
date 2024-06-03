using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpControll : MonoBehaviour
{
    public TMP_Text[] tMP_Texts;

    private void OnEnable()
    {
       ScoreManager.instance.AddScoreToRanking(ScoreManager.instance.score);

        OnPopUpClosed();
       
    }
    public void OnPopUpClosed()
    {
        string[] rankTexts = ScoreManager.instance.GetRankTexts();

        for (int i= 0; i< rankTexts.Length; i++ )
        {
            tMP_Texts[i].text = rankTexts[i];
        }        
    }
}
