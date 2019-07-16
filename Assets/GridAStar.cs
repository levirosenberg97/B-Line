using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2 position;
}

public class GridAStar : MonoBehaviour {

    public float gridSizeX;
    public float gridSizeY;

    private Node[,] nodes;

	// Use this for initialization
	void Start () {
		for(int x = 0; x < Mathf.RoundToInt(gridSizeX); x++)
        {
            for(int y = 0; y < Mathf.RoundToInt(gridSizeY); y++)
            {
                nodes[x, y].position = transform.position + new Vector3(x, y);
                Instantiate(new GameObject("Node Point " + x + " " + y), nodes[x,y].position,Quaternion.identity);
            }
        } 
	}

}
