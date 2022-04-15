using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text gameOverText;


    public static UIManager instance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ShowGameOverText()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public void ChangeText(string text)
    {
        gameOverText.text = text;
    }

    public void LoadScene(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }

    public void LoadSceneDelay(int sceneNo)
    {
        StartCoroutine(LoadSceneRoutine(sceneNo));
    }

    IEnumerator LoadSceneRoutine(int sceneNo)
    {
        yield return new WaitForSeconds(3f);
        LoadScene(sceneNo);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetLevel()
    {
        PlayerPrefs.DeleteAll();
        LoadScene(0);
    }
}
