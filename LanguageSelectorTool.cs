using UnityEngine;
using UnityEditor;

public class LanguageSelectorTool : EditorWindow
{
    private string[] languageNames;

    [MenuItem("Tools/Language Selector Tool")]
    public static void ShowWindow()
    {
        GetWindow<LanguageSelectorTool>("Language Selector Tool");
    }

    private void OnGUI()
    {
        languageNames = LocalisationManager.GetAllLanguages();

        if (languageNames != null && languageNames.Length > 0)
        {
            GUILayout.Label($"Current language: {LocalisationManager.lang}", EditorStyles.boldLabel);
            GUILayout.Space(10);

            for (int i = 0; i < languageNames.Length; i++)
            {
                if (GUILayout.Button(languageNames[i]))
                {
                    LocalisationManager.SetLanguage(languageNames[i]);
                }
            }
        }
        else
        {
            GUILayout.Label("Languages not found");
        }
    }
}