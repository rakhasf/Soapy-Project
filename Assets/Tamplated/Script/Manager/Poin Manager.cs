using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System; 

public class PointManager : MonoBehaviour
{
    public static PointManager Instance;
    public int score = 0;

    [Header("UI References")]
    public List<TextMeshProUGUI> scoreTexts = new List<TextMeshProUGUI>();

   
    public static Action<int> OnScoreThresholdReached;

    private int nextSpeedIncreaseThreshold = 20;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
        UpdateScoreUI();

       
        if (score >= nextSpeedIncreaseThreshold)
        {
           
            OnScoreThresholdReached?.Invoke(score);
        
            nextSpeedIncreaseThreshold += 20;
        }
    }

    public void ResetScore()
    {
        score = 0;
        nextSpeedIncreaseThreshold = 20;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        foreach (TextMeshProUGUI txt in scoreTexts)
        {
            if (txt != null)
            {
                txt.text = "Score: " + score;
            }
        }
    }
}