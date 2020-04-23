using UnityEngine;
using Building.Placement;
using Input;

namespace Building
{
    public class BuildingManager : MonoBehaviour
    {
        public bool buildingSelected = false;

        public BaseBuilding building = null;

        public BuildingPlacement buildingPlacement;
        private GameObject buildingHolder;
        private MouseInput mouseInput;

        void Start()
        {
            buildingPlacement = new BuildingPlacement();
            mouseInput = GameObject.FindGameObjectWithTag("GameController").GetComponent<MouseInput>();
            buildingHolder = GameObject.FindGameObjectWithTag("BuildingHolder");
        }

        void Update()
        {

        }

        public void RemoveSelectedBuilding()
        {
            building = null;
            buildingSelected = false;
        }

        public void PlaceBuilding(Vector3 _vec)
        {
            if (building != null)
            {
                if (buildingPlacement.Build(building, _vec))
                {
                    InstantiateBuilding();
                }
                else Debug.Log("Nooope");
            }
        }

        private void InstantiateBuilding()
        {
            Transform trans = building.transform;
            trans.position = new Vector3(mouseInput.selectedTile.x, 0, mouseInput.selectedTile.z);

            GameObject gameO = Instantiate(building.gameObject, trans.position, Quaternion.identity, buildingHolder.transform);
            gameO.name = "Building: " + mouseInput.selectedTile.x + "|" + mouseInput.selectedTile.z;
        }

        public void SetBuilding(GameObject _gO)
        {
            building = _gO.GetComponent<BaseBuilding>();
            buildingSelected = true;
        }
    }
}