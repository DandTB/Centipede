using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCentipede: Enemys {


   
    float speed; // скорость головы 


    Vector2 startPosicition;// стартовая позиция головы
    Vector2 direction; // направления движения головы
    Vector2 temp_direction; // предыдущее направление
    Vector3 tempPosition; // для временного хранения позиции


    void Start() {
        HP = 1; // у головы 1 жизнь, как и любой части хвоста
        direction = Vector2.down; //начальное направление - вниз
        temp_direction = direction; // предыдущее так же запишем со страта  - вниз
        tempPosition = transform.position; // получим текущее положение, для использования как предыдущее
        speed = GameLogic.Instance.speedCentipede; // получим скорость движения
    }

    private void Update()
    {
        // развернем голову и начнем двигать
        transform.right = -direction;
        transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;

        // проверям направление, для движения вниз на одинаковое растояние и последующего поворота
        if (direction == Vector2.down)
        {


            if ((tempPosition.y - transform.position.y) >= 1)
            {
                tempPosition = transform.position;
                if (temp_direction == Vector2.down)
                {
                    direction = Vector2.right;
                }
                else if (temp_direction == Vector2.left)
                {
                    direction = Vector2.right;

                }
                else if (temp_direction == Vector2.right)
                {
                    direction = Vector2.left;

                }


            }

        }
        // если выстрел попал в голову, уничтожаем полностью всю гусеницу и добавляем 100 очков
        if (HP < 1)
        {
            Die();
            GameLogic.Instance.Score += 100;
            Destroy(transform.parent.gameObject);
        }

    }

    // меняем направление движения в зависимости от предыдущего направления и точки столкновения
    private void OnCollisionEnter2D (Collision2D col)
    {
        temp_direction = direction;
        if (col.gameObject.tag == "wall")
        {
            if (direction == Vector2.right)
            {

                direction = Vector2.down;
            }
            else if (direction == Vector2.down)
            {
                direction = Vector2.left;
            }
            else if (direction == Vector2.left)
            {
                direction = Vector2.down;
            }
        }
        // если столкнулись с героем то уничтожаем героя
        if (col.gameObject.GetComponent<Hero>() != null) {
            Die();
            col.gameObject.GetComponent<Hero>().Die();
            Destroy(transform.parent.gameObject);
        }
        // если дошли до низа, то конец игры
        if (col.gameObject.name == "bottom") {
            GameLogic.Instance.GameOver();
        }
    }

 
    



}
