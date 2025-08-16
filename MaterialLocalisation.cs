using UnityEngine;

public class MaterialLocalisation : Localisation
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (!meshRenderer)
        {
            Debug.LogError("Mesh Renderer not finded");
        }

        UpdateTranslation();
    }

    public override void UpdateTranslation()
    {
        meshRenderer.material = UnityEditor.AssetDatabase.LoadAssetAtPath<Material>(LocalisationManager.GetTranslation(key));
    } 
}
