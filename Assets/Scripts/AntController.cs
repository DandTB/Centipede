using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntController : Enemys {

    
    Vector2 tempPosition; // для хранения предыдущей позиции
    bool goCreate; // для создания нового муравья
                   
    void Start () {
        tempPosition = transform.position; // изначально задаем стартовую позицию
    }
	
	// Update is called once per frame
	void Update () {

        // двигаем вниз
        transform.position += Vector3.down*GameLogic.Instance.speedCentipede*Time.deltaTime;

        // если разница в 2 единицы то перезаписываем позиции, и создаем гриб после выхода из тригера
        // создание грибов будет после того, как муравей пройдет какой-то объект
        if (tempPosition.y - transform.position.y > 2) {
            tempPosition = transform.position;
            if (goCreate)
            {
                GameLogic.Instance.CreateMushroom(transform.position);
                goCreate = false;
            }
        }
        // уничтожаем объект при достижении низа
        if (transform.position.y < -30) { //
            Destroy(this.gameObject);
        }

	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        // при попадании выстрела +300 очков и  уничтожаем объект
        if (col.gameObject.GetComponent<ShotMove>() != null) {
            GameLogic.Instance.Score += 300;
            Die();
            Destroy(this.gameObject);
        }
        // при попадании в героя, уничтожаем героя
        if (col.gameObject.GetComponent<Hero>() != null) {
            col.gameObject.GetComponent<Hero>().Die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
           goCreate = true;
        
    }
    // для того чтобы грибы не создавались поверх других
    private void OnTriggerStay2D(Collider2D collision)
    {

        goCreate = false;

    }


}
