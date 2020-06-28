//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Sound_manager : MonoBehaviour
//{
    
//    static AudioSource audioSrc;

//    [SerializeField]
//    public AudioClip enemyHitSound_1;

//    public static AudioClip enemyHitSound_2, enemyHitSound_3, enemyDethSound;


//    void Start()
//    {
        
//        enemyHitSound_2 = Resources.Load<AudioClip>("hentai_sound_2");
//        enemyHitSound_3 = Resources.Load<AudioClip>("hentai_sound_3");
//        enemyDethSound = Resources.Load<AudioClip>("papich_solo");

//        audioSrc = GetComponent<AudioSource>();

//    }

   
//    void Update()
//    {
        
//    }
//    public  void PlaySound (string clip)
//    {
//        if (clip == "hit_enemy")
//        {
//            audioSrc.PlayOneShot(enemyHitSound_1);
//        }
//    }

//}
