using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class StageContoller : MonoBehaviour
{
    [SerializeField]
    private GameObject textTitle;
    [SerializeField]
    private GameObject textTapToPlay;
    [SerializeField]
    private GameObject ContinueButton;
    [SerializeField]
    private TextMeshProUGUI textCurrentScore;
    [SerializeField]
    private GameObject textScore;
    private int currentScore = 0;
    [SerializeField]
    private TextMeshProUGUI Bestscore;
    private int bestscore;
    public bool IsGameOver {private set; get; } = false;
    private IEnumerator Start()
    {
        bestscore = PlayerPrefs.GetInt("BestScore");
        Bestscore.text = $"<size=50>BEST</size>\n<size=100>{bestscore}</size>";
        while(true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
                yield break;
            }
            yield return null;
        }
    }
    public void IncreaseScore(int Score)
    {
        currentScore += Score;
        textCurrentScore.text = currentScore.ToString();
        if(bestscore < currentScore)
        {
            bestscore = currentScore;
            Bestscore.text = $"<size=50>BEST</size>\n<size=100>{bestscore}</size>";
        }
    }
    private void GameStart()
    {
        textTitle.SetActive(false);
        textTapToPlay.SetActive(false);
    }
    public void GameOver()
    {
        if(currentScore == bestscore)
            PlayerPrefs.SetInt("BestScore",currentScore);
        IsGameOver = true;
        ContinueButton.SetActive(true);
        textScore.SetActive(true);
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Start is called before the first frame update
   
}
