using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSelector : MonoBehaviour
{

    public GameObject prefab;

    MouseInput mouseInput;

    private void Start()
    {
        mouseInput = GameObject.FindGameObjectWithTag("GameController").GetComponent<MouseInput>();
    }


    public void OnUIClick()
    {
        mouseInput.testBuildingObject = this.prefab;
    }
}
