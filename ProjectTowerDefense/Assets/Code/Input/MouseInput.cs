namespace Input
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using Map;
    using Building;
    public class MouseInput : MonoBehaviour
    {
        GameObject tileMap;
        CreateTileMap createTileMap;
        BuildingManager buildingManager;

        Vector3 currentTileCoord;
        public Transform selectionCube;

        public Vector3 selectedTile;

        void Start()
        {
            tileMap = GameObject.FindGameObjectWithTag("TileMap");
            createTileMap = tileMap.GetComponent<CreateTileMap>();
            buildingManager = GameObject.FindGameObjectWithTag("BuildingManager").GetComponent<BuildingManager>();
        }

        void Update()
        {
            CheckMousePosition();

            if (Input.GetMouseButtonDown(1))
            {
                buildingManager.RemoveSelectedBuilding();
            }
        }

        private void CheckMousePosition()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            // HIT MAP
            if (tileMap.GetComponent<Collider>().Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                selectionCube.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;

                int x = Mathf.FloorToInt(hitInfo.point.x / createTileMap.tileSize);
                int z = Mathf.FloorToInt(hitInfo.point.z / createTileMap.tileSize);
                currentTileCoord.x = x;
                currentTileCoord.z = z;

                selectionCube.transform.position = currentTileCoord;

                if (Input.GetMouseButtonDown(0))
                {
                    selectedTile.x = x;
                    selectedTile.z = z;
                    Debug.Log("Tile: " + x + ", " + z);
                    buildingManager.PlaceBuilding(selectedTile);

                }
                else
                {
                    selectionCube.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
                }
            }
        }

    }
}