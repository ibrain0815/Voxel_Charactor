using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconDir : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isMapOpen)
        {
            transform.eulerAngles = new Vector3(90f,0,0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(90f, 0, 0);
        }
    }
}
