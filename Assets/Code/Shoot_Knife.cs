using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Knife : MonoBehaviour
{
    public float speed;
    public GameObject gameobject;
    Rigidbody rigid;
    bool canMove;
    bool colitionWood;
    public Animator knifeAnimation;

    void Awake()
    {
        base.gameObject.SetActive(false);
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (canMove)
        {
            rigid.velocity = new Vector3(0, speed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

    public void MoveKnife()
    {
        base.gameObject.SetActive(true);
        rigid.isKinematic = false;
        canMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("knife"))
        {
            knifeAnimation.enabled = true;
            StartCoroutine(PauseForASec());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (colitionWood)
        {
            return;
        }
        if (collision.gameObject.CompareTag("Wood"))
        {
            canMove = false;
            gameobject.transform.position = new Vector3(0, 4, transform.position.z);
            rigid.isKinematic = true;
            colitionWood = true;
            //rigid.constraints = RigidbodyConstraints.FreezeAll;
            base.gameObject.transform.SetParent(collision.transform);
            GameManager.instance.counterKnife++;
        }

        if (collision.gameObject.CompareTag("knife"))
        {
            knifeAnimation.enabled = true;
            StartCoroutine(PauseForASec());
        }

    }


    IEnumerator PauseForASec()
    {
        yield return new WaitForSeconds(0.3f);
        GameManager.instance.Defeat();
        GameManager.instance.Victory();
    }
}
