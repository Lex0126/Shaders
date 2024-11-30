using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]

public class ScriptNOC : MonoBehaviour
{
    [SerializeField] private Color defaultLightColour;
    [SerializeField] private Color boostedLightColour;
    [SerializeField] private Color LightColour;

    private bool isNightVisionEnabled;
    private bool isLightVisionEnabled;

    private PostProcessVolume volume;

    private void Start()
    {
        RenderSettings.ambientLight = defaultLightColour;

        volume = gameObject.GetComponent<PostProcessVolume>();
        volume.weight = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNightVision();
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            TogglecleanVision();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Togglelightvision();
        }
        
    }

    private void ToggleNightVision()
    {
        if (isLightVisionEnabled) return; 

        isNightVisionEnabled = !isNightVisionEnabled;

        if (isNightVisionEnabled)
        {
            RenderSettings.ambientLight = boostedLightColour;
            volume.weight = 1;
        }
        else
        {
            RenderSettings.ambientLight = defaultLightColour;
            volume.weight = 0;
        }
    }

    private void TogglecleanVision()
    {
        if (isNightVisionEnabled) return; 

        isLightVisionEnabled = !isLightVisionEnabled;

        if (isLightVisionEnabled)
        {
            RenderSettings.ambientLight = LightColour;
            volume.weight = 0.5f; 
        }
        else
        {
            RenderSettings.ambientLight = defaultLightColour;
            volume.weight = 0;
        }
    }
        private void Togglelightvision()
    {
        if (isNightVisionEnabled) return; 

        isLightVisionEnabled = !isLightVisionEnabled;

        if (isLightVisionEnabled)
        {
            RenderSettings.ambientLight = LightColour;
            volume.weight = 2f; 
        }
        else
        {
            RenderSettings.ambientLight = defaultLightColour;
            volume.weight = 0;
        }
    }
}

