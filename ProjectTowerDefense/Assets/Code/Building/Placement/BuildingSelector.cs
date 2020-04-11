namespace Building.Placement
{
    using UnityEngine;

    public class BuildingSelector : MonoBehaviour
    {
        public GameObject selectedPrefab = null;



        public void RemoveSelectedPrefab()
        {
            selectedPrefab = null;
        } 
    }
}