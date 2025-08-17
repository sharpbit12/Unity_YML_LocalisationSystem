using UnityEngine;

public abstract class Localisation : MonoBehaviour
{
    [SerializeField] private string _key;

    public string key
    {
        get { return _key; }
    }

    private void Awake()
    {
        LocalisationManager.onLanguageChanged += UpdateTranslation;
    }

    private void OnDestroy()
    {
        LocalisationManager.onLanguageChanged -= UpdateTranslation;
    }

    private void Start()
    {
        UpdateTranslation();
    }

    public virtual void UpdateTranslation() { }
}

