using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

using Gamascorpio.Dialogos;

public class GAME : MonoBehaviour
{
    public TMP_Text capto;
    public Canvas cv;
    [Space(20), SerializeField] public List<SO_Dialogos> Dialogos;

    private void Start()
    {
        cv.enabled = false;

        if (Dialogos == null) throw new Exception("Capullo! Falta un asset de tipo Dialogo!");
        if (Dialogos.Count < 1) throw new Exception("La lista de Dialogos esta vacia!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var rd = Random.Range(0, Dialogos.Count);
            ShowDialogo(Dialogos[rd]);
        }
    }

    private void ShowDialogo(SO_Dialogos item)
    {
        if (item == null || item.Dialogo.Count < 1) return;

        IEnumerator[] routines = new IEnumerator[item.Dialogo.Count];
        for (int i = 0; i < routines.Length; i++)
        {
            routines[i] = ShowFrase(item.Dialogo[i]);
        }

        StartCoroutine(OneAfterTheOther(routines));
    }
    
    private IEnumerator OneAfterTheOther( params IEnumerator[] routines ) 
    {
        foreach ( var item in routines ) 
        {
            while ( item.MoveNext() ) yield return item.Current;
        }

        yield break;
    }
    

    private IEnumerator ShowFrase(Frase myFrase)
    {
        capto.text = myFrase.characterId + " : " + myFrase.texto;
        cv.enabled = true;
        yield return new WaitForSeconds(myFrase.duration);
        cv.enabled = false;
    }

}
