using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AudioManager_Parametres : MonoBehaviour
{
    [SerializeField] private Slider general_volumeSlider;
    [SerializeField] private Slider effets_volumeSlider;
    [SerializeField] private Slider musique_volumeSlider;
    
    [SerializeField] private TextMeshProUGUI general_volumeText;
    [SerializeField] private TextMeshProUGUI effets_volumeText;
    [SerializeField] private TextMeshProUGUI musique_volumeText;

    [SerializeField] private AudioSource effets_audioSource;
    [SerializeField] private AudioSource musique_audioSource;

    private static float general_volume;

    void Start()
    {   

        // Récupérer l'autre AudioManager (celui de la scène Menu_principal)
        AudioManager_Principal audioManager = FindObjectOfType<AudioManager_Principal>();
        effets_audioSource = audioManager.effets_audioSource;
        musique_audioSource = audioManager.musique_audioSource;
        general_volume = audioManager.general_volume;
        float effets_volume = effets_audioSource.volume / general_volume;
        float musique_volume = musique_audioSource.volume / general_volume;


        Debug.Log("general_volume = " + general_volume);
        Debug.Log("effets_volume = " + effets_volume);
        Debug.Log("musique_volume = " + musique_volume);

        // Initialiser les sliders
        general_volumeSlider.value = general_volume;
        effets_volumeSlider.value = effets_volume;
        musique_volumeSlider.value = musique_volume;

        general_volumeText.text = (int)(general_volumeSlider.value * 100) + "";
        effets_volumeText.text = (int)(effets_volumeSlider.value * 100) + "";
        musique_volumeText.text = (int)(musique_volumeSlider.value * 100) + "";

        // Ajouter les listeners
        general_volumeSlider.onValueChanged.AddListener(general_setVolume);
        effets_volumeSlider.onValueChanged.AddListener(effets_setVolume);
        musique_volumeSlider.onValueChanged.AddListener(musique_setVolume);
    }


    public void general_setVolume(float value)
    {
        general_volume = value;
        effets_audioSource.volume = effets_volumeSlider.value * general_volume;
        musique_audioSource.volume = musique_volumeSlider.value * general_volume;
        general_volumeText.text = (int)(value * 100) + "";
        Debug.Log("general_volume = " + general_volume);
    }

    public void effets_setVolume(float value)
    {
        effets_audioSource.volume = value * general_volume;
        effets_volumeText.text = (int)(value * 100) + "";
        Debug.Log("effets_volume = " + effets_audioSource.volume);
    }

    public void musique_setVolume(float value)
    {
        musique_audioSource.volume = value * general_volume;
        musique_volumeText.text = (int)(value * 100) + "";
        Debug.Log("musique_volume = " + musique_audioSource.volume);
    }

    

    // Update is called once per frame
    void Update()
    {

        
    }
}
