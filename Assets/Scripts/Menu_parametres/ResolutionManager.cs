using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionManager : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TextMeshProUGUI resolutionText;


      void Start()
    {
        LoadResolutions();

        SetResolution(Screen.width, Screen.height);

        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
    }

    // Charger toutes les résolutions disponibles dans le Dropdown
    void LoadResolutions()
    {
        resolutionDropdown.ClearOptions();
        
        var options = new System.Collections.Generic.List<TMP_Dropdown.OptionData>();

        foreach (var resolution in Screen.resolutions)
        {
            string resolutionLabel = resolution.width + "x" + resolution.height;
            options.Add(new TMP_Dropdown.OptionData(resolutionLabel));
        }

        resolutionDropdown.AddOptions(options);

        int currentResolutionIndex = GetCurrentResolutionIndex();
        resolutionDropdown.value = currentResolutionIndex;
    }

    int GetCurrentResolutionIndex()
    {
        int index = 0;
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].width == Screen.width && Screen.resolutions[i].height == Screen.height)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    void OnResolutionChanged(int index)
    {
        Resolution selectedResolution = Screen.resolutions[index];
        SetResolution(selectedResolution.width, selectedResolution.height);
    }

    void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, Screen.fullScreen);
        resolutionText.text = $"Résolution: {width}x{height}"; // Afficher la résolution actuelle (à enlever)
    }
}
