using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour {

    // группа объектов - количество жизней
    List<GameObject> life = new List<GameObject>();
    Hero hero;

    // Use this for initialization
    void Start() {
        // получаем доступ к скрипту героя через объект героя
        hero = GameObject.FindObjectOfType<Hero>();

        // добавляем дочерние объекты в список
        for (int i = 0; i < hero.HP; i++)
        {
            life.Add(GameObject.Find("life_" + (i + 1)));
        }
       
    }

    // в Update проверяем, если есть разница между жихнями героя и кол-вом на UI панели, то выравниевам кол-во. 
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
