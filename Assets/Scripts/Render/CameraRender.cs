using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;
public class CameraRender : MonoBehaviour
{
    private Canvas _canvas;

    public GameObject FollowRender;

    public TMP_Text TextFollwer;
    public  static int i =0;
    // Start is called before the first frame update
    void Start()
    {
        TextFollwer.SetText(i.ToString());
        i++;
        _canvas = GetComponent<Canvas>();
        _canvas.worldCamera = Camera.main;
        TextFollwer.transform.position = FollowRender.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _canvas.worldCamera = Camera.main;
        TextFollwer.transform.position = FollowRender.transform.position;
    }
}
