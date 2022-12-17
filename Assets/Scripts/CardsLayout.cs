using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CardsLayout : MonoBehaviour
{
    public List<GameObject> Cards = new List<GameObject>();
   
    public Vector2[] Set1Coords = new Vector2[1];
    public int[] Set1Angles = new int[1];
    public Vector2[] Set2Coords = new Vector2[2];
    public int[] Set2Angles = new int[2];
    public Vector2[] Set3Coords = new Vector2[3];
    public int[] Set3Angles = new int[3];
    public Vector2[] Set4Coords = new Vector2[4];
    public int[] Set4Angles = new int[4];
    public Vector2[] Set5Coords = new Vector2[5];
    public int[] Set5Angles = new int[5];
    public Vector2[] Set6Coords = new Vector2[6];
    public int[] Set6Angles = new int[6];

    public float Yoffset = 0;
    public float Xoffset = 0;



    public void Rebuild()
    {
        for(int i = 0; i < Cards.Count; i++)
        {
            if(!Cards[i].activeSelf)
            {
                Cards.RemoveAt(i);
                i--;
            }  
           
        }

        switch(Cards.Count)
        {
            case 1: Move(Set1Coords, Set1Angles); break;
            case 2: Move(Set2Coords, Set2Angles); break;
            case 3: Move(Set3Coords, Set3Angles); break;
            case 4: Move(Set4Coords, Set4Angles); break;
            case 5: Move(Set5Coords, Set5Angles); break;
            case 6: Move(Set6Coords, Set6Angles); break;
        }
    }

    private void Move(Vector2[] coords, int[] angels)
    {
        for(int i = 0; i < Cards.Count; i++)
        {
            Cards[i].transform.DOMove(new Vector3(coords[i].x + Xoffset, coords[i].y + Yoffset, 0), 1);
            Cards[i].transform.DOLocalRotate(new Vector3 (0,0,angels[i]), 1);
        }
    }
    
}
