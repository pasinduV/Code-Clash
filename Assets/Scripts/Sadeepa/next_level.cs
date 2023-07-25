using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class next_level : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject WinPanel;

    public GameObject inputUIs;

    public GameObject topUI;

    string stars;

    public Text starsText;

    public float delay = 0.5f; // Delay in seconds

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            yield return new WaitForSeconds(delay);
            stars = GameObject.FindObjectOfType<starCounter>().winStar();
            GameObject.FindObjectOfType<leaderboardManager>().showInUI();
            starsText.text = stars.ToString();
            //Debug.Log(stars);
            WinPanel.SetActive(true);
            inputUIs.SetActive(false);
            topUI.SetActive(false);
            
            //yield return new WaitForSeconds(delay);

            //levelSound.instance.MusicSource.Play();
            UnlockNewLevel();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}