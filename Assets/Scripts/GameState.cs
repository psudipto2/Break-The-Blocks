using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameState : MonoBehaviour
{
    [Range(0.1f,2f)][SerializeField]float GameSpeed;
    [SerializeField] int currentScore=0;
    int ScorePerBlockDestroyed = 57;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] bool autoPlay;
   /* private void Awake()
    {
        int GameStateCount = FindObjectsOfType<GameState>().Length;
        if (GameStateCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = GameSpeed;
        ScoreText.text = currentScore.ToString();
    }
    public void AddScore()
    {
        currentScore = currentScore + ScorePerBlockDestroyed;
    }
    public bool AutoPlay()
    {
        return autoPlay;
    }
}
