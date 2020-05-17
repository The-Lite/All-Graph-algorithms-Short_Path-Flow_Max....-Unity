using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using Random = UnityEngine.Random;
using  CodeMonkey.Utils;
using  TMPro;
using UnityEngine.UI;

public class GraphCreation : MonoBehaviour
{
    int k=0, c=0;
    int  a=0;
    // Start is called before the first frame update
     private  Graph<Transform,float>_graph;
     public List<Node<Transform>> nodei;
     public List<Edge<float,Transform>> edgei;
     public TMP_InputField _NodeNumber;
      int NodeNumber;
     public GameObject circle, line;
     public List<GameObject> Nodes=new List<GameObject>();
     public List<GameObject> Edges=new List<GameObject>();
     public GameObject T;
     public List<int> x, y;
     private bool creat = false;
     [SerializeField]
     public TMP_InputField X, Y;
     public TMP_Text text;
     private int EdgeNumber=1;

     public GameObject setEgdes;
     public int[,] weight;
     public TMP_InputField NumberOfEdges;
     public TMP_InputField WeightField;

     private int maxEdgeNumber=0;
    // Start is called before the first frame update
    void Start()
    {
        _graph=new Graph<Transform, float>();
        x=new List<int>();
        y=new List<int>();
        _NodeNumber.SetTextWithoutNotify("0");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            for(int i =0;i<nodei.Count;i++)
            {
                for (int j = 0; j < nodei.Count; j++)
                {
                  
                        Debug.Log(" row "+ i + "coloun" + j);
                        Debug.Log(weight[i,j]);

                   
                }
               
            }
        }
        NodeNumber = Int16.Parse(_NodeNumber.text.ToString());
        if (creat == true)
        {
            for (int i = 0; i < x.Count; i++)
            {
                float Distance = Vector2.Distance(Nodes[x[i]].transform.position , Nodes[y[i]].transform.position);
                float h = Mathf.Lerp(0, Distance, 10);
                Vector2 dir =h* Vector3.Normalize(( Nodes[y[i]].transform.position-Nodes[x[i]].transform.position))+Nodes[x[i]].transform.position;
                Edges[i].GetComponent<LineRenderer>().SetPosition(0,Nodes[x[i]].transform.position);
                Edges[i].GetComponent<LineRenderer>().SetPosition(1,dir);
                Edges[i].GetComponent<LineRenderer>().SetWidth(0.1f,0.1f);
            }
            
        }

        for (int i = 0; i < Edges.Count; i++)
        {
            if (i + 1 == Edges.Count)
            {
                break;
                
            }
            if (Edges[i].GetComponent<LineRenderer>().GetPosition(1)==(Edges[i+1].GetComponent<LineRenderer>().GetPosition(0)))
            {
                Vector2 l = new Vector2(0, 0.25f) + (Vector2) Edges[i].GetComponent<LineRenderer>().GetPosition(1);
                Vector2 h = new Vector2(0, 0.25f) + (Vector2) Edges[i].GetComponent<LineRenderer>().GetPosition(0);
                Edges[i].GetComponent<LineRenderer>().SetPosition(1,l);
                Edges[i].GetComponent<LineRenderer>().SetPosition(0,h);
                Vector2 t = new Vector2(0, -0.25f) + (Vector2) Edges[i+1].GetComponent<LineRenderer>().GetPosition(0);
                Vector2 s = new Vector2(0, -0.25f) + (Vector2) Edges[i+1].GetComponent<LineRenderer>().GetPosition(1);
                Edges[i+1].GetComponent<LineRenderer>().SetPosition(0,t);
                Edges[i+1].GetComponent<LineRenderer>().SetPosition(1,s);
            }

           
        }
    }
    
    
    
    
    public void AddNode()
    {
        nodei=new List<Node<Transform>>();
        for (int i = 0; i < NodeNumber; i++)
        {
            nodei.Add(new Node<Transform>());
           
        }
       
        
   
    }

    
    
    public void Creat()
    {
        creat = true;
        for (int i = 0; i < NodeNumber; i++)
        {
            Nodes.Add(Instantiate(circle, nodei[i].Valeu, T));
            Nodes[i].GetComponent<SpriteRenderer>().color = Color.white;
            Nodes[i].GetComponent<Transform>().position=new Vector2(Random.value*-i*5,Random.value*i);
          
        }
        
        for (int i = 0; i < x.Count; i++)
        {
            Edges.Add(Instantiate(line,nodei[x[i]].Valeu));
            Vector2 dir = (Nodes[x[i]].transform.position - Nodes[y[i]].transform.position).normalized;
            Edges[i].GetComponent<LineRenderer>().SetPosition(0,Nodes[x[i]].transform.position);
            Edges[i].GetComponent<LineRenderer>().SetPosition(1,dir);
            Edges[i].GetComponent<LineRenderer>().SetWidth(0.1f,0.1f);
        }

        
    }

    public  void AddEgde()
    {
       
        if (a <= maxEdgeNumber - 1)
        {
            text.SetText("U"+EdgeNumber);
            x.Add(Int16.Parse(X.text.ToString()));
            y.Add(Int16.Parse(Y.text.ToString()));
       
            X.SetTextWithoutNotify(""); 
            Y .SetTextWithoutNotify("");
            createWeight(k ,c ,a);
            EdgeNumber++;
            k=k+1;
            c=c+1;
            a++;
           
        }
      
    }

   public void SetEdges()
    {
        setEgdes.SetActive(true);
        maxEdgeNumber = Int16.Parse(NumberOfEdges.text);
        weight= new int[nodei.Count,nodei.Count];
        text.SetText("U"+0);
        
    }

   public void EXIT()
   {
       edgei=new List<Edge<float, Transform>>();
       
       for (int i = 0; i < x.Count; i++)
       {    
           edgei.Add(new Edge<float, Transform>(){Valeu = 2,From = nodei[x[i]],To = nodei[y[i]]});
         
       }

       EdgeNumber = 1;
       setEgdes.SetActive(false);
   }


   void createWeight( int k , int c , int a )
   {
      
       if (WeightField.interactable)
       {
           Debug.Log("It's working " );
           Debug.Log(y[k] +" " + x[c] );
              weight[x[k], y[c]] =Int16.Parse(WeightField.text) ;
               Debug.Log(weight[x[k], y[c]]);
               
               
          
           
       }
       
   }
}


