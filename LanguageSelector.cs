using System.Linq;
using TMPro;
using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    private TMP_Dropdown langDropdown;
    private string[] langs = LocalisationManager.GetAllLanguages();

    private void Start()
    {
        langDropdown = GetComponent<TMP_Dropdown>();

        langDropdown.ClearOptions();
        langDropdown.AddOptions(langs.ToList());

        LocalisationManager.onLanguageChanged += UpdateDropdownSelectedCaption;
        UpdateDropdownSelectedCaption();
    }

    private void UpdateDropdownSelectedCaption()
    {
        for (int i = 0; i < langs.Length; i++)
        {
            if (langs[i] == LocalisationManager.lang)
            {
                langDropdown.value = i;
                break;
            }
        }
    }

    public void SetLang(int value)
    {
        LocalisationManager.SetLanguage(langs[value]);
    }
}
