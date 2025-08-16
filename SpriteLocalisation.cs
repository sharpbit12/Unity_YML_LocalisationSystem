using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SpriteLocalisation : Localisation
{
    private Image image;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        image = GetComponent<Image>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (image && spriteRenderer)
        {
            Debug.LogError("Image or Sprite Renderer not finded");
        }

        UpdateTranslation();
    }

    public override void UpdateTranslation()
    {
        if(image) image.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(LocalisationManager.GetTranslation(key));
        if(spriteRenderer) spriteRenderer.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(LocalisationManager.GetTranslation(key));
    }   
}
