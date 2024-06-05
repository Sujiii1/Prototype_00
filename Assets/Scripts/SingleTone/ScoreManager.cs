using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance {  get; private set; }

    //Score 
    public TMP_Text scoreText;
    public int score;

    //Ranking
    private List<int> scoreLank = new List<int>();  //Rnk 저장
    [SerializeField] private TMP_Text[] RankText;
    private int preBestScore = 0;

    private void Awake()
    {
        #region[SingleTone]
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        #endregion
    }

    //Score
    public void UpScore()
    {
        score += 1000;
        UpdateScore();
    }
    private void UpdateScore()  //Score ->  ToString
    {
        scoreText.text = "Score: " + score.ToString("0,000");
    }

    //Ranking 
    public  void LoadPreviousScore()    //이전 최고 점수 가져옴
    {
        preBestScore = PlayerPrefs.GetInt("preBestScore", 0); 
    }

    public void SavePreScore()    //이전 점수 저장
    {
        PlayerPrefs.SetInt("preBestScore", preBestScore);
        PlayerPrefs.Save();
    }

    public void AddScoreToRanking(int score)       //Lank에 전달
    {
        scoreLank.Add(score);
        scoreLank.Sort((a, b) => b.CompareTo(a));   //내림차순 정렬

        UpdateRanking();
    }

    private void UpdateRanking()    //Ranking UI 표시
    {
        int numToshow = Mathf.Min(RankText.Length, scoreLank.Count);

        for(int i = 0; i < numToshow; i++)
        {
            RankText[i].text = $"{i + 1}. {scoreLank[i]}";
        }
        for(int i =numToshow; i< RankText.Length; i++)
        {
            RankText[i].text = "";
        }
    }


}
