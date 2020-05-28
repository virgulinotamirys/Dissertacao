using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGengiva : MonoBehaviour
{

    public bool ativo;

    public GameObject gengiva;

    // Use this for initialization
    void Start()
    {
        ativo = false;

        gengiva = GameObject.Find("h1-teeth_shape01");

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Refazer");

        if (gengiva)
        {
            ativo = true;
            Debug.Log("Não pode tocar nessa região");
        }
        else
        {
            ativo = false;
        }
    }
}
