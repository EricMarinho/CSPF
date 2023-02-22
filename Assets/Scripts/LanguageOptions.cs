using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageOptions : MonoBehaviour
{

    [SerializeField] private Dropdown languageDropdown;
    private string[] languages = new string[] { "English", "Portuguese" };
    private bool isLoading = true;

    void Start()
    {
        if (PlayerPrefs.GetInt("LanguageIndex", 0) == languageDropdown.value)
        {
            isLoading = false;
        }
        languageDropdown.value = PlayerPrefs.GetInt("LanguageIndex", 0);
        languageDropdown.RefreshShownValue();
    }

    public void setLanguage(int languageIndex)
    {
        PlayerPrefs.SetString("Language", languages[languageIndex]);
        PlayerPrefs.SetInt("LanguageIndex", languageIndex);
        if (isLoading)
        {
            isLoading = false;
            return;
        }
        MenuController.instance.SelecaoOptions();
    }

}
