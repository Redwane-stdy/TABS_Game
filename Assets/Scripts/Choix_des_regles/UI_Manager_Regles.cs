using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager_Regles : MonoBehaviour
{

    private AudioManager_Principal audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager_Principal>();
    }

    // Bouton retour
    public void Retour()
    {   
        audioManager.PlayButtonSound();
        SceneManager.LoadScene("Menu_principal");
    }

    // Bouton continuer
    public void Continuer()
    {   
        audioManager.PlayButtonSound();
        SceneManager.LoadScene("Placement_unites");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
