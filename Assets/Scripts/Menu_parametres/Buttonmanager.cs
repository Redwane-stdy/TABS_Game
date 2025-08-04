using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonmanager : MonoBehaviour
{   


    private AudioManager_Principal audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager_Principal>();
    }

    public void MenuPrincipal()
    {   
        audioManager.PlayButtonSound();
        SceneManager.LoadScene("Menu_principal");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
