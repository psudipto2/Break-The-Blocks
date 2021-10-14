using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float ScreenUnit = 16f;
    [SerializeField] float minX;
    [SerializeField] float maxX; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Paddlepos = new Vector2(transform.position.x, transform.position.y);
        Paddlepos.x = Mathf.Clamp(XPos(),minX,maxX);
        transform.position = Paddlepos;
    }
    private float XPos()
    {
        if (FindObjectOfType<GameState>().AutoPlay())
        {
            return FindObjectOfType<ball>().transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenUnit;
        }
    }
}
