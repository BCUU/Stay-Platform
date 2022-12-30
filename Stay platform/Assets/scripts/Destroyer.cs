using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    int isFnished;
    public int white_ball, red_ball, blue_Ball;
    public Animator w_Animator;
    public Animator r_Animator;
    public Animator b_Animator;

 
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            white_ball++;
            PlayerPrefs.SetInt(nameof(white_ball), white_ball);
            w_Animator.SetTrigger("white");
            Destroy(other.gameObject);
            //m_Animator.SetBool("white", false);
        }
        if (other.gameObject.CompareTag("StrongEnemy"))
        {
            red_ball++;
            PlayerPrefs.SetInt(nameof(red_ball), red_ball);
            r_Animator.SetTrigger("red");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("FastEnemy"))
        {
            blue_Ball++;
            PlayerPrefs.SetInt(nameof(blue_Ball), blue_Ball);
            b_Animator.SetTrigger("blue");
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(nameof(isFnished), 1);
            other.gameObject.SetActive(false);
        }
    }
    private void Start()
    {

        PlayerPrefs.SetInt(nameof(white_ball), 0);
        PlayerPrefs.SetInt(nameof(red_ball), 0);
        PlayerPrefs.SetInt(nameof(blue_Ball), 0);
        //m_Animator =m_Animator gameObject.GetComponent<Animator>();
    }
}
