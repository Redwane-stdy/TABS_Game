using UnityEngine;
using UnityEngine.AI;

public class UnitPlacement : MonoBehaviour
{

    [SerializeField]
    private UI_Manager_Placement uiManager;

    public Banque banque; // Référence au gestionnaire de crédits
    public GameObject[] unitPrefabs; // Les unités disponibles à placer
    public Transform placementArea; // La zone de placement
    public LayerMask placementLayer; // Le Layer de la zone de placement

    private GameObject selectedUnit; // L’unité actuellement sélectionnée

    void Update()
    {
        // Sélectionner une unité à placer
        for (int i = 0; i < unitPrefabs.Length; i++)
        {
            // KeyCode.Alpha1 correspond à l’unité à l’index 0, donc on fait i + 1
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SelectUnit(i);
                break;
            }
        }

        // Placer une unité
        if (selectedUnit != null && Input.GetMouseButtonDown(0)) // Clic gauche
        {
            PlaceUnit();
        }
    }

    public void SelectUnit(int index)
    {
        if (index >= 0 && index < unitPrefabs.Length)
        {
            selectedUnit = unitPrefabs[index];
            Debug.Log($"Selected unit: {selectedUnit.name}");

            // Mettre à jour l'UI
            uiManager.SelectionnerUnite(index);
            
        }
    }

    void PlaceUnit()
    {
        // Vérifier le coût de l'unité sélectionnée
        Unit unitComponent = selectedUnit.GetComponent<Unit>();
        if (unitComponent == null)
        {
            Debug.LogError("Selected unit does not have a Unit component.");
            return;
        }

        int unitCost = unitComponent.cost; // Récupérer le coût de l'unité
        if (!banque.CanPlaceUnit(unitCost))
        {
            Debug.Log("Not enough credits to place this unit.");
            return;
        }

        // Obtenir la position de la souris
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, placementLayer))
        {
            // Vérifier si la position est dans la zone de placement
            if (hit.collider != null && hit.collider.CompareTag("PlacementZone"))
            {
                // Instancier l’unité sur le NavMesh
                GameObject placedUnit = Instantiate(selectedUnit, hit.point, Quaternion.identity);
                placedUnit.tag = "equipe";
                placedUnit.GetComponent<NavMeshAgent>().Warp(hit.point); // Ajuste l'unité au NavMesh

                // Déduire le coût
                banque.SpendCredits(unitCost);

                Debug.Log($"Placed {placedUnit.name} at {hit.point}. Remaining credits: {banque.credits}");
            }
            else
            {
                Debug.Log("You can only place units in the designated area.");
            }
        }
    }
}