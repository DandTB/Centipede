using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

   
    static AudioClip intro;
    static AudioClip centipede;
    static AudioClip shot;
    static AudioClip DieHero;
    static AudioClip DestroyTail;


    bool played;
    float myTimer;
    static AudioSource audio_Source;
	
	void Start () {
        // загружаем звуки из ресурсов
        intro = Resources.Load<AudioClip>("Sound/Intro");
        centipede = Resources.Load<AudioClip>("Sound/Centipede");
        shot = Resources.Load<AudioClip>("Sound/Shot");
        DieHero = Resources.Load<AudioClip>("Sound/DieHero");
        DestroyTail = Resources.Load<AudioClip>("Sound/DestroyTail");
       
        audio_Source = GetComponent<AudioSource>();

        PlaySound("intro");
	}
	
	// Update is called once per frame
	void Update () {
        // если есть гусеница на сцене, то играем определенный клип
        if (GameObject.FindObjectOfType<CentipedeTail>() != null && !played) {
            
            PlaySound("centipede");
            played = true;
 
        }
        myTimer += Time.deltaTime;
        if (myTimer > 2)
        {
            played = false;
            myTimer = 0;
        }

    }
    // метод для воспроизведения определенного звука
    public static void PlaySound(string clip)
    {
        switch (clip) {
            case "centipede":
                audio_Source.PlayOneShot(centipede);
                break;
            case "shot":
                audio_Source.PlayOneShot(shot);
                break;
            case "intro":
                audio_Source.PlayOneShot(intro);
                break;
            case "dieHero":
                audio_Source.PlayOneShot(DieHero);
                break;
            case "destroyTail":
                audio_Source.PlayOneShot(DestroyTail);
                break;
            
        }
    }
}
