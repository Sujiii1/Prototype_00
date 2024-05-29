using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreControll : MonoBehaviour
{
    public TMP_Text scoreTextUI;

    private void Update()
    {
        scoreTextUI.text = ScoreManager.instance.GetScoreTexts();
    }
}
