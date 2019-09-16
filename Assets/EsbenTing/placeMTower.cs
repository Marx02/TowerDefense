using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class placeMTower : MonoBehaviour
{
    // Start is called before the first frame update
    public Button spawnTowers;
    public GameObject tower;
    void Start()
    {
        spawnTowers.onClick.AddListener(ReadyTower);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void ReadyTower(){
        Instantiate(tower);
    }
}
