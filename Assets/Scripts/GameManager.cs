using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMesh Pro namespace

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI timer_Text; // Use TextMeshProUGUI instead of Text
    private int timer_Count;

    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        StartCoroutine(CountTime());
        timer_Text = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
    }

    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        //if (instance != null)
        //{
         //   Destroy(gameObject);
        //}
        //else
        //{
          //  instance = this;
            //DontDestroyOnLoad(gameObject);
        //}
    }

    // Make ResetValues public to be accessed by other scripts
    public void ResetValues()
    {
        timer_Count = 0;
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        StartCoroutine(RestartGameAfterTime());
    }

    IEnumerator RestartGameAfterTime()
    {
        yield return new WaitForSecondsRealtime(2f);  // Correct usage of WaitForSecondsRealtime
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(1f);
        timer_Count++;

        timer_Text.text = "Time: " + timer_Count; // Update using TextMesh Pro

        StartCoroutine(CountTime());
    }
}
