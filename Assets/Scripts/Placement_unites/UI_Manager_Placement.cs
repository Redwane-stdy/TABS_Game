using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



// UI_Manager de la scène Placement_unites
public class UI_Manager_Placement : MonoBehaviour
{


    [SerializeField] private Banque banque;
    [SerializeField] private UnitPlacement unitPlacement;
    [SerializeField] private TextMeshProUGUI texte_banque; 
    [SerializeField] private GameObject bouton_commencer_partie;
    [SerializeField] private GameObject bouton_unite_1;
    [SerializeField] private GameObject bouton_unite_2;
    private int unite_selectionnee = -1;
    private GameObject[] liste_boutons;

    private AudioManager_Principal audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ModifierCredits(banque.credits);
        liste_boutons = new GameObject[] { bouton_unite_1, bouton_unite_2 };

        audioManager = FindObjectOfType<AudioManager_Principal>();
    }


    // Bouton menu principal
    public void MenuPrincipal()
    {   
        audioManager.PlayButtonSound();
        SceneManager.LoadScene("Menu_principal");
    }

    // Bouton commencer partie
    public void CommencerPartie()
    {   
        audioManager.PlayButtonSound();

        Unit.game_not_started = false;
        bouton_commencer_partie.gameObject.SetActive(false);
        bouton_unite_1.gameObject.SetActive(false);
        bouton_unite_2.gameObject.SetActive(false);

    }

    // Bouton unité 1
    public void Unite1()
    {   
        audioManager.PlayButtonSound();
        
        unitPlacement.SelectUnit(0);
    }

    // Bouton unité 2
    public void Unite2()
    {   
        audioManager.PlayButtonSound();

        unitPlacement.SelectUnit(1);
    }

    // Texte de la banque
    public void ModifierCredits(int credits)
    {
        texte_banque.text = credits.ToString() + " $";
    }

    // Couelur du bouton sélectionné
    public void SelectionnerUnite(int index)
    {
        if (unite_selectionnee != -1)
        {

            liste_boutons[unite_selectionnee].GetComponent<Image>().color = Color.white;
        }

        unite_selectionnee = index;
        // Change la couleur du bouton
        liste_boutons[unite_selectionnee].GetComponent<Image>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {

    }
}