using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailPart : Enemys{

    // получаем экземпляр скрипта гусеницы
    CentipedeTail CentipedeTail;

    // порядковый номер элемента хвоста для удаления
    public int Number { get; set; }

    // жизнь 1.
    private void Start()
    {
        HP = 1;
        CentipedeTail = GetComponentInParent<CentipedeTail>();
     
      
    }

    // если в часть хвоста попали, то уничтожаем все остальные (следующие) части хвоста и создаем новую мини-гусеницу
    void Update () {
        if (HP < 1)
        {
            Die();
            GameLogic.Instance.Score += 10;// +10 очков

            Destroy(this.gameObject);
          
           

            if (Number + 1 != CentipedeTail.countTail)
            {

               GameLogic.Instance.CreateCentipede(CentipedeTail.countTail - Number, CentipedeTail.positions);
            }

            CentipedeTail.RemoveTail(Number);


        }
	}

   
}
