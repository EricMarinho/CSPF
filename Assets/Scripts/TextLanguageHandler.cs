using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLanguageHandler : MonoBehaviour
{
    [SerializeField] private string englishText;
    [SerializeField] private string portugueseText;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();

        if (PlayerPrefs.GetString("Language", "English") == "English")
        {
            text.text = englishText;    
        }
        else
        {
            text.text = portugueseText;
        }
    }

}
