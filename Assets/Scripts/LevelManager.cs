using UnityEngine;
using UnityEngine.SceneManagement; // This is required!

public class LevelManager : MonoBehaviour
{
    public GameObject winUI;
    private Pipe[] allPipes;
    private float winTime;
    private bool isGameFinished = false;

    void Start()
    {
        allPipes = Object.FindObjectsByType<Pipe>(FindObjectsSortMode.None);
        if (winUI != null) winUI.SetActive(false);
    }

    void Update()
    {
        if (isGameFinished)
        {
            if (Time.time > winTime + 0.5f)
            {
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene("Start");
                }
            }
        }
    }

    public void CheckVictory()
    {
        foreach (Pipe p in allPipes)
        {
            if (!p.isCorrect) return;
        }
        FinishGame();
    }

    void FinishGame()
    {
        isGameFinished = true;
        winTime = Time.time;
        if (winUI != null) winUI.SetActive(true);
    }
}