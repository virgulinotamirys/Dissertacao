using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Equipamentos : MonoBehaviour {

    List<string> names = new List<string> {"Instrumento Hollemback", "Instrumento de Broca", "Aplicador de Massa Dental", "Ferramenta de Finalização Luz UV"};
    public Dropdown dropdown;
    public GameObject instPick;
    public GameObject instCurette;
    public GameObject drill;
    //public GameObject filler;
    public GameObject uv;
    HapticPlugin hapticPlugin;

    //public GameObject bt = null;


    void Start()
    {
        //hapticPlugin = gameObject.GetComponent<HapticPlugin>();
        hapticPlugin = GameObject.Find("HapticDevice").GetComponent<HapticPlugin>();
        instCurette = GameObject.Find("17221_Curette");
        drill = GameObject.Find("DrillAcima");
        //filler = GameObject.Find("Aparelhodental2");
        instPick = GameObject.Find("16972_dentist_pick");
        uv = GameObject.Find("Aparelhodental1");

        PopulateList();
        instCurette.SetActive(true);
        drill.SetActive(false);
        instPick.SetActive(false);
        uv.SetActive(false);

  
    }
       
    void PopulateList()
    {
        dropdown.AddOptions(names);
    }
    
    public void Dropdown_Index(int index)
    {

        if (index == 0)
        {
            instCurette.SetActive(true);
            drill.SetActive(false);
            instPick.SetActive(false);
            uv.SetActive(false);
            hapticPlugin.hapticManipulator = instCurette;
        }
        else if(index == 1)
        {
            drill.SetActive(true);
            instCurette.SetActive(false);
            instPick.SetActive(false);
            uv.SetActive(false);
            hapticPlugin.hapticManipulator = drill;
        }
        else if(index == 2)
        {
            instPick.SetActive(true);
            instCurette.SetActive(false);
            drill.SetActive(false);
            uv.SetActive(false);
            hapticPlugin.hapticManipulator = instPick;
        }else
        {
            uv.SetActive(true);
            instCurette.SetActive(false);
            drill.SetActive(false);
            instPick.SetActive(false);
            hapticPlugin.hapticManipulator = uv;
        }
        

    }


    /*public void testButtonRed()
    {
        if (bt != null)
            bt.GetComponent<Image>().color = Color.red;
    }*/

    /*public void Dropdown_Index(int index)
    {
        if (index == 0 && instPick.activeSelf)
        {
            instPick.SetActive(true);
            instCurette.SetActive(false);
            hapticPlugin.hapticManipulator = instPick;
        }
        else if (index == 1 && instCurette.activeSelf)
        {
            instCurette.SetActive(true);
            instPick.SetActive(false);
            hapticPlugin.hapticManipulator = instCurette;
        }
    }*/

}
