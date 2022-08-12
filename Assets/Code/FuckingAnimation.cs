using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuckingAnimation : MonoBehaviour
{
    public Animation knifeAnimation;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("knife"))
        {
            GameManager.instance.Defeat();
            knifeAnimation.Play();
        }
    }
}
