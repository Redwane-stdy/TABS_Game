using UnityEngine;
using UnityEngine.SceneManagement;




// UI_Manager de la scène Menu_principal
public class UI_Manager_Principal : MonoBehaviour
{

    [SerializeField] private AudioClip sceneMusic;

    private AudioManager_Principal audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager_Principal>();
        
        audioManager.PlayMusic(sceneMusic);
        
    }


    // Bouton jouer
    public void Jouer()
    {   
        audioManager.PlayButtonSound();
        SceneManager.LoadScene("Choix_des_regles");
    }


    // Bouton paramètres
    public void Parametres()
    {
        audioManager.PlayButtonSound();
        SceneManager.LoadScene("Menu_parametres");
    }

    // Bouton quitter
    public void Quitter()
    {   
        audioManager.PlayButtonSound();
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
