using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Graph<TNodeType,TEdgeType> {
    public Graph()
    {
        Nodes = new List<Node<TNodeType>>();
        Edges = new List<Edge<TEdgeType,TNodeType>>();
    }
    
    public List<Node<TNodeType>> Nodes { get; private set; }
    public List<Edge<TEdgeType,TNodeType>>  Edges { get; private set; }
    
    
}
public class Node<TNodeValeu> {
    
    public  Color NodeColor { get; set; }
    public  TNodeValeu Valeu { get; set; } 
    
}

public class Edge<TEdgeValeu,TNodeType> {
    
    public  Color NodeColor { get; set; }
    public  TEdgeValeu Valeu { get; set; } 
    public Node<TNodeType> From { get; set; }
    public Node<TNodeType> To { get; set; }
}
