using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public Color hoverColor;

    private GameObject tower;

    private Renderer rend;
    private Color startColor;
    public float radius = 3f;
    public Plane map;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    

    private void Update()
    {

        

        if (Input.GetMouseButtonDown(0)) {

          
             buildTower(Input.mousePosition);


        }
}
    //render color to show of if you can build
    /*
    private void OnMouseEnter()
    {
        rend.material.color = startColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = hoverColor;
    }
    */


    void buildTower(Vector3 mousePosition)
    {
        RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);
        if (hit.collider.gameObject.tag == ("Map"))
        {
            GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
            tower = GameObject.Instantiate(towerToBuild, hit.point, Quaternion.identity);
        }

        else Debug.Log("Cant build here!");
        
    }

    public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out hit, rayLength);
        return hit;
    }


}
