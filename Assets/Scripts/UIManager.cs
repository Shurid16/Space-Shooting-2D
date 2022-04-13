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

    public void LoadScene(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
