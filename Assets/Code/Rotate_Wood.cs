using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Wood : MonoBehaviour
{
    public float angle;
    public float speed;
    float waitForSeceond;
    int manyKnife;
    public GameObject knifeObject;

    void Start()
    {
        StartCoroutine(RandonRotation());
        manyKnife = Random.Range(0, 3); // number of default knifes in wood

        IshaveKnife();
        Debug.Log("Many Knife: " + manyKnife);
    }

    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        angle = transform.rotation.eulerAngles.z;
        angle += speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    IEnumerator RandonRotation()
    {
        int direction = Random.Range(0, 2);

        waitForSeceond = Random.Range(2, 4);

        yield return new WaitForSeconds(waitForSeceond);

        if (direction > 0)
        {
            speed = -Random.Range(50f, 160f);
        }
        else
        {
            speed = Random.Range(50f, 160f);
        }
        StartCoroutine(RandonRotation());
    }
    void IshaveKnife()
    {
        for (int i = 0; i < manyKnife; i++)
        {
            var temp = Instantiate(knifeObject, transform);
            temp.transform.localRotation = Quaternion.Euler(Random.Range(0, 359), 90, 0);
        }
    }
}

