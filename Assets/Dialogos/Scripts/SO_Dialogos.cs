using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gamascorpio.Dialogos
{
    [Serializable]
    public struct Frase
    {
        [SerializeField] public string texto;
        [SerializeField] public int characterId;
        [SerializeField] public float duration;

        public Frase(string txt, int charID, float dur = 1f)
        {
            texto = txt;
            characterId = charID;
            duration = dur;
        }
    
    }

    [Serializable]
    [CreateAssetMenu(fileName = "Dialogo_XXX", menuName = "Gamascorpio/Dialogos/New Dialogo...")]
    public class SO_Dialogos : ScriptableObject
    {
        [SerializeField] public List<Frase> Dialogo;

        private void ReorderSpeakers()
        {
            /*
            if (Dialogo == null || Dialogo.Count < 1) return;

            foreach (var diag in Dialogo)
            {
            }
            */
        }

        void OnEnable() => ReorderSpeakers();
        void OnDisable() => ReorderSpeakers();
    }
    
    //Clase del evento
    public class Dialoguer : MonoBehaviour
    {
        public event Action<SO_Dialogos> onShowDialogo;

        public void ShowDialog(SO_Dialogos item)
        {
            onShowDialogo?.Invoke(item);
        }
    }

}

