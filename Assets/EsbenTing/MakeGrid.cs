using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MakeGrid : MonoBehaviour
{
    private float x;
    private float z;
    private int gridCount = 30;
    // Start is called before the first frame update
    void Start()
    {
        x = this.GetComponent<Renderer>().bounds.size.x;
        z = this.GetComponent<Renderer>().bounds.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 ToPlaneGrid(Vector3 oV){
        int tempX =(int) (oV.x/(x/gridCount));
        oV.x = tempX*(x/gridCount);
        int tempZ = (int) (oV.z/(z/gridCount));
        oV.z = tempZ*(z/gridCount);
        return oV;
    }
}
