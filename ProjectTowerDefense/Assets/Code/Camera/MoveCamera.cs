using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Camera Speed")]
    public float moveSpeed = 1f;

    GameObject mainCamera;

    void Start()
    {
        StartPosition();
    }



    void Update()
    {
        // HORIZONTAL
        float horizontalInput = Input.GetAxis("Horizontal");
        // VERTICAL
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, verticalInput * moveSpeed * Time.deltaTime);
    }

    private void StartPosition()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        GameObject gameObject = GameObject.FindWithTag("TileMap");
        Map.CreateTileMap cTM = gameObject.GetComponent<Map.CreateTileMap>();

        int zOffset = cTM.height / 2;
        int xOffset = cTM.width / 2;

        Vector3 pos = mainCamera.transform.position;
        pos.x += xOffset;
        pos.z += zOffset;

        mainCamera.transform.position = pos;

    }
}
