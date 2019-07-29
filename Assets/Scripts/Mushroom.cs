using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : DestroyedObj {

    // задаем спрайты для отображения частей гриба
    public Sprite[] mushroom_sprites;


    // изначльно у каждого гриба 4 жизни
    void Awake () {
        HP = 4;
	}

    // получаем количество грибов в игровой зоне героя
    private void Start()
    {
        if (transform.position.y < -20)
        {
            GameLogic.Instance.countMushromms++;
        }
    }

    // в зависимости от кол-ва жизней отображаем соответствующий спрайт
    void Update () {
        if (HP == 3)
        {
            GetComponent<SpriteRenderer>().sprite = mushroom_sprites[0];
        }
        if (HP == 2)
        {
            GetComponent<SpriteRenderer>().sprite = mushroom_sprites[1];
        }
        if (HP == 1)
        {
            GetComponent<SpriteRenderer>().sprite = mushroom_sprites[2];
        }
        // если жизней нет, то добавляем +1 к очкам
        if (HP < 1)
        {
            GameLogic.Instance.Score += 1;
            GameLogic.Instance.speedCentipede -= 0.1f;// замедляем гусеницу

            Destroy(this.gameObject);// ставим в очередь на уничтожения
            if (transform.position.y < -20)// убираем гриб из игровой зоны героя
            { 
                GameLogic.Instance.countMushromms-=1;
            }
        }
    }
}
