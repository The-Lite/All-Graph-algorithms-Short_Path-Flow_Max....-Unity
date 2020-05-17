using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeRender : MonoBehaviour
{
    public LineRenderer Edge;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = (Vector2)Edge.GetPosition(1)+new  Vector2(0,3);
        this.transform.rotation = Edge.transform.rotation;
    }
}
