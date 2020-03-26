using UnityEngine;
using Map;
using Player;

using Buildings;

public class MouseInput : MonoBehaviour
{
    GameObject tileMap;
    CreateTileMap createTileMap;
    GameObject buildingHolderObject;
    PlayerHandler playerHandler;
    ResourceManager resManager;

    Vector3 currentTileCoord;
    public Transform selectionCube;

    public Vector3 selectedTile;
    public GameObject testBuildingObject;

    void Start()
    {
        tileMap = GameObject.FindGameObjectWithTag("TileMap");
        createTileMap = tileMap.GetComponent<CreateTileMap>();
        buildingHolderObject = GameObject.FindGameObjectWithTag("BuildingHolder");
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
        resManager = playerHandler.resourceManager;
    }

    void Update()
    {
        CheckMousePosition();
    }

    private void CheckMousePosition()
    {
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
        else
        {
            selectionCube.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        }
    }


    private void SetBuilding()
    {

        Transform trans = testBuildingObject.transform;
        trans.position = new Vector3(selectedTile.x, 0, selectedTile.z);

        GameObject gameO = Instantiate(testBuildingObject, trans.position, Quaternion.identity, buildingHolderObject.transform);
        gameO.name = "Tower: " + selectedTile.x + "|" + selectedTile.z;

    }

    private bool CheckForCosts()
    {
        Resource resGold = resManager.goldResource;
        Resource resWood = resManager.woodResource;
        Resource resMeat = resManager.meatResource;


        // TODO Change for dieffernt building types
        Tower tower = testBuildingObject.GetComponentInChildren<Tower>();

        if ((resGold.count - tower.buildCostGold) >= 0 && (resWood.count - tower.buildCostWood) >= 0 && (resMeat.count - tower.buildCostMeat) >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
