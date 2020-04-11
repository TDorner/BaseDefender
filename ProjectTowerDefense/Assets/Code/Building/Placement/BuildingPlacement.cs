namespace Building.Placement
{
    using UnityEngine;
    using Input;
    using Player;
    using Map;

    public class BuildingPlacement : MonoBehaviour
    {
        ResourceManager resManager;
        PlayerHandler playerHandler;
        BuildingSelector buildingSelector;
        MouseInput mouseInput;
        TileMapData tileMapData;

        GameObject buildingHolderObject;

        void Start()
        {
            buildingHolderObject = GameObject.FindGameObjectWithTag("BuildingHolder");
            playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
            buildingSelector = GameObject.FindGameObjectWithTag("BuildingManager").GetComponent<BuildingSelector>();
            mouseInput = GameObject.FindGameObjectWithTag("GameController").GetComponent<MouseInput>();
            resManager = playerHandler.resourceManager;
            tileMapData = GameObject.FindGameObjectWithTag("TileMap").GetComponent<CreateTileMap>().TMData;
        }

        private void SetBuilding()
        {
            Transform trans = buildingSelector.selectedPrefab.transform;
            trans.position = new Vector3(mouseInput.selectedTile.x, 0, mouseInput.selectedTile.z);

            GameObject gameO = Instantiate(buildingSelector.selectedPrefab, trans.position, Quaternion.identity, buildingHolderObject.transform);
            gameO.name = "Building: " + mouseInput.selectedTile.x + "|" + mouseInput.selectedTile.z;
        }

        public bool CheckForCosts()
        {
            Resource resGold = resManager.goldResource;
            Resource resWood = resManager.woodResource;
            Resource resMeat = resManager.meatResource;


            // TODO Change for different building types
            BaseBuilding building = buildingSelector.selectedPrefab.GetComponentInChildren<BaseBuilding>();

            if (resGold.CheckResourceCount(building.buildCostGold) && 
                resWood.CheckResourceCount(building.buildCostWood) && 
                resMeat.CheckResourceCount(building.buildCostMeat))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PlaceBuilding()
        {
            if (CheckForCosts())
            {
                SetBuilding();
                Debug.Log("enough Resources");

            }
            else
            {
                Debug.Log("Not enough Resources");
            }
        }
    }
}