﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeTail : MonoBehaviour
{

    public GameObject pfbhead;
    public GameObject pfbTail;
    public float sizeSprite;
    public int countTail;


    GameLogic gameLogic;
    GameObject head;
   List<GameObject> ListCentipedePatrs;
    List<Vector2> positions = new List<Vector2>();

    private void Awake()
    {
        head = Instantiate(pfbhead, transform.position, Quaternion.identity, transform);

      
        ListCentipedePatrs = new List<GameObject>();
        positions.Add(head.transform.position);
        //ListCentipedePatrs.Add(head);


        //head.transform.right = transform.right;
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < countTail; i++)
        {
            AddTail();

        }

    }

    // Update is called once per frame
    void Update()
    {
        countTail = ListCentipedePatrs.Count;
        Vector2 napr = (Vector2)head.transform.position - positions[0];
        float distance = napr.magnitude;

        if (distance > sizeSprite)
        {

            Vector2 direction = ((Vector2)head.transform.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * sizeSprite);
            positions.RemoveAt(positions.Count - 1);
            distance -= sizeSprite;
        }

        for (int i = 0; i < ListCentipedePatrs.Count; i++)
        {
            if (ListCentipedePatrs[i] != null)
            {
                ListCentipedePatrs[i].transform.position = Vector2.Lerp(positions[i + 1], positions[i], distance / sizeSprite);
            }
        }

        
        print("size tail" + ListCentipedePatrs.Count);
    }
    void AddTail()
    {
        GameObject tail = Instantiate(pfbTail, positions[positions.Count - 1], Quaternion.identity, transform);
        ListCentipedePatrs.Add(tail);
        positions.Add(tail.transform.position);
        tail.GetComponent<TailPart>().Number = ListCentipedePatrs.Count - 1;
        

    }
    public void RemoveTail(int index) {
        print("Remove element");

        for (int i = index; i < ListCentipedePatrs.Count; i++)
        {
            Destroy(ListCentipedePatrs[i]);
            ListCentipedePatrs.RemoveAt(i);
            positions.RemoveAt(i+1);
        }
        //ListCentipedePatrs.RemoveRange(index,countTail-index-1);
        //positions.RemoveRange(index,countTail-index);
    }

  
}