using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMProLanguageHandler : MonoBehaviour
{
    [SerializeField] private string englishText;
    [SerializeField] private string portugueseText;
    private TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();

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
