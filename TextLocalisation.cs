using TMPro;

public class TextLocalisation : Localisation
{
    private TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();

        if (!text)
        {
            UnityEngine.Debug.LogError("Text not finded");
        }

        UpdateTranslation();
    }

    public override void UpdateTranslation()
    {
        text.text = LocalisationManager.GetTranslation(key);
    }   
}
