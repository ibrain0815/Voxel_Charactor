using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcControll : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    bool isDance = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DanceOn();
    }

    void DanceOn()
    {

        if (Input.GetKeyDown(KeyCode.H))
        {
            isDance = !isDance;
        }
        anim.SetBool("isDance", isDance);
    }

}
