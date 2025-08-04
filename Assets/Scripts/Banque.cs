using UnityEngine; 


public class Banque : MonoBehaviour
{

    [SerializeField]
    private UI_Manager_Placement uiManager;

    public int credits = 200; // Total des crédits disponibles

    public bool CanPlaceUnit(int unitCost)
    {
        return credits >= unitCost;
    }

    public void SpendCredits(int amount)
    {
        credits -= amount;

        uiManager.ModifierCredits(credits);
    }
}