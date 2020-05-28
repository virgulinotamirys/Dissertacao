using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzUV : MonoBehaviour {

    public bool ativo;
    public bool terminou;

    DateTime primeiroHorario;
    DateTime segundoHorario;
    RaycastHit hit;

    // Use this for initialization
    void Start () {
        ativo = false;
        terminou = false;
     
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!terminou)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2))
            {
                if (ativo)
                {
                    segundoHorario = DateTime.Now;
                    var diferenca = (segundoHorario - primeiroHorario).TotalMilliseconds;

                    if (diferenca >= 5000)
                    {
                        Debug.Log("Terminou");
                        terminou = true;
                    }
                }
                else
                {
                    if (String.Equals(hit.collider.gameObject.name, "Box001"))
                    {
                        ativo = true;
                        primeiroHorario = DateTime.Now;
                    }
                    else
                    {
                        ativo = false;
                    }
                }
            }
            else
            {
                ativo = false;
            }
        }
	}
}
