using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public static class LocalisationManager
{
    private static string folderPath = "Assets/Localisation";
    public static Action onLanguageChanged;

    public static string GetTranslation(string key)
    {
        string[] localisationFiles = Directory.GetFiles(folderPath, $"*_{lang}.yml", SearchOption.AllDirectories);

        string pattern = $@"^{Regex.Escape(key)}:\s*(.*)$";

        foreach (var filePath in localisationFiles)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                Match match = Regex.Match(content, pattern, RegexOptions.Multiline);
                if (match.Success)
                {
                    string result = match.Groups[1].Value.Trim();
                    return result.Substring(1, result.Length - 2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        return key;
    }

    public static string[] GetAllLanguages()
    {
        if (!Directory.Exists(folderPath))
        {
            Debug.LogWarning($"Folder {folderPath} not found");
            return new string[0];
        }

        string[] files = Directory.GetFiles(folderPath, "*.yml", SearchOption.AllDirectories);
        HashSet<string> languages = new HashSet<string>();

        foreach (string filePath in files)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            int lastUnderscoreIndex = fileName.LastIndexOf('_');
            if (lastUnderscoreIndex >= 0 && lastUnderscoreIndex < fileName.Length - 1)
            {
                string languagePart = fileName.Substring(lastUnderscoreIndex + 1);
                languages.Add(languagePart);
            }
        }

        return new List<string>(languages).ToArray();
    }

    public static void SetLanguage(string newLang)
    {
        lang = newLang;
        onLanguageChanged?.Invoke();
    }

    public static string lang
    {
        get { return PlayerPrefs.GetString("lang"); }
        set { PlayerPrefs.SetString("lang", value); }
    }
}
