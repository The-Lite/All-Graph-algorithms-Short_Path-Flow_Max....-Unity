using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphVerticesColoration : MonoBehaviour
{
    private GraphCreation _graph;

    private int[,] _matrix;
    private int[] _color;
    private List<Color> _colors=new List<Color>(){Color.cyan,Color.green,Color.magenta,Color.yellow,Color.grey};
    
    // Start is called before the first frame update
    void Start()
    {
        _graph = FindObjectOfType<GraphCreation>();
        
        
       
    }

    // Update is called once per frame
    void Update()
    {
       

        
    }

    void IncidnceMatrix(int [,]T)
    {
        
        for (int i = 0; i < _graph.x.Count; i++)
        {
            T[_graph.x[i], _graph.y[i]] = 1;
            T[_graph.y[i], _graph.x[i]] = 1;
        }

        for (int i = 0; i < _graph.nodei.Count; i++)
        {
            for (int j = 0; j < _graph.nodei.Count; j++)
            {
                if (T[i, j] != 1)
                {
                    T[i, j] = 0;
                }
                Debug.Log("T["+i +" , " +j+" ]"+ T[i,j]);
            }
           
        }

    }

    void Coloration(int k)
    {

        for (int c =0 ; c <2; c++)
        {
            if (IsSafe(k, c))
            {
                
                Debug.Log(IsSafe(k,c).ToString());
                _color[k] = c;
                Debug.Log("color  "+ k +" = "+_color[k]);
                if (k + 1 < _graph.nodei.Count)
                {
                    Coloration(k+1);
                    
                }

             
            }
            else
            {
                _color[k] = 0;
            }

        }
        
    }

    bool IsSafe(int k,int c)
    {
        for (int i = 0; i < _graph.nodei.Count; i++)
        {
            if (_matrix[k,i] == 1 && c == _color[i])
            {
                return false;
            }
        }

        return true;
    }
    void SetColoration()
    {
        for (int i = 0; i < _graph.Nodes.Count; i++)
        {
            _graph.Nodes[i].GetComponent<SpriteRenderer>().color = _colors[_color[i]];
        } 
    }


   public void test()
    {
        _matrix=new int[_graph.nodei.Count,_graph.nodei.Count];
        _color = new int [100];
        for (int i = 0; i < 100; i++)
        {
            _color[i] = i;
        }

      
        IncidnceMatrix(_matrix);
       Coloration(0);
       SetColoration();
     
       for (int i = 0; i < _graph.nodei.Count; i++)
       {
           Debug.Log("c = "+_color[i]);
       }


      
    }
}
