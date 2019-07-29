using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour {


    List<GameObject> life = new List<GameObject>();
    Hero hero;

    // Use this for initialization
    void Start() {

        hero = GameObject.FindObjectOfType<Hero>();

        for (int i = 0; i < hero.HP; i++)
        {
            life.Add(GameObject.Find("life_" + (i + 1)));
        }
        print(life.Count);
    }

    // Update is called once per frame
    void Update() {
        if (hero.HP > 0)
        {
            while (life.Count != hero.HP)
            {
                life.RemoveAt(0);
                life[0].SetActive(false);
            }
        }
        
	}
}
