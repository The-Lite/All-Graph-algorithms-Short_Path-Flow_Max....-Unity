using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveble : MonoBehaviour { 
	bool Selected ;

// Update is called once per frame
void Update ()
 { 
	 if(Selected==true)
			{
			Vector2 curspos=Camera.main.ScreenToWorldPoint(Input.mousePosition);// taking the mouse position
			transform.position=new Vector2(curspos.x,curspos.y);//folowing the mouse position
			
			}
		
			if(Input.GetMouseButtonUp(0))
			{
				Selected = false;
			}
			
	}

void OnMouseOver()
{
	if(Input.GetMouseButtonDown(0))
	{
		Selected=true;
	}
}

}
