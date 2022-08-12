using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_Size_Random : MonoBehaviour
{
    int randomSize;
    void Start()
    {
        Debug.Log("Random Size Wood: " + randomSize);
        randomSize = Random.Range(0, 3);
        SizeWood();
    }

    void SizeWood()
    {
        switch (randomSize)
        {
            case 0:
                transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                break;
            case 1:
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case 2:
                transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                break;
        }
    }
}
