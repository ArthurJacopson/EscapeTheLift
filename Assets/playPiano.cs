using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class playPiano : MonoBehaviour
{
    private Animator anim;
    private float timer = 2f;
    public AudioSource c1AudioSource;
    public AudioSource e1AudioSource;
    public AudioSource g1AudioSource;
    public AudioSource GAudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        stopTimer();
        anim =GetComponent<Animator>();
        // startPlay();
    }

    // Update is called once per frame
    void Update()
    {
       
            // anim.SetTrigger("e1");
            
            // stopTimer();
            // // anim.ResetTrigger("e1");
            // anim.SetTrigger("c1");
            // stopTimer();
            // // anim.ResetTrigger("c1");
        
    }

    public void startPlay(){
        anim.SetTrigger("e1");
        stopTimer();
       


    }
    void stopTimer(){
         timer -= Time.deltaTime;

        // 检查计时器是否到达0
        if (timer <= 0f)
        {
            

            // 重置计时器以便再次等待
            timer = 2f;
        }
    }

    void c1(){
        c1AudioSource.Play();
    }

    void e1(){
        e1AudioSource.Play();
    }
    void g1(){
        g1AudioSource.Play();
    }
    void G(){
        GAudioSource.Play();
    }

}
