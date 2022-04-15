using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{

    public string worldNumber;



    void Start()
    {
        PlayerPrefs.SetInt("1", 1);
        if (PlayerPrefs.GetInt(worldNumber,0) == 1)
        {
            transform.GetComponent<Button>().interactable = true;
        }
        else
        {
            transform.GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
