using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Gamascorpio.Dialogos
{
    public class generador_Dialogos : MonoBehaviour
    {
        [MenuItem("Gamascorpio/Dialogos/Create SO_Dialogo from JSON...")]
        public static void CreateDialogoAsset()
        {
            string path = EditorUtility.OpenFilePanelWithFilters("Select JSON file...", Application.dataPath,
                new string[] {"json", "json"});
            
            if (path.Length == 0) return;

            var file = File.ReadAllText(path);
            var jsonAsset = ScriptableObject.CreateInstance<SO_Dialogos>();
            JsonUtility.FromJsonOverwrite(file, jsonAsset);
            
            string pathAsset = EditorUtility.SaveFilePanelInProject("Save asset as...", "Dialogo_XXX", "asset", "asset file");
            
            if (string.IsNullOrEmpty(pathAsset)) return;
            
            AssetDatabase.CreateAsset(jsonAsset, pathAsset);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            Debug.Log("Asset creado con exito.");
        }
        
        [MenuItem("Gamascorpio/Dialogos/DEBUG SO_Dialogo to JSON...")]
        public static void DebugDialogoAsset()
        {
            string path = EditorUtility.OpenFilePanelWithFilters("Select Asset", Application.dataPath,
                new string[] {"asset", "asset"});
            
            if (path.Length == 0) return;

            path = FileUtil.GetProjectRelativePath(path);
            
            var file = AssetDatabase.LoadAssetAtPath(path, typeof(SO_Dialogos)) as SO_Dialogos;
            var jsonero = JsonUtility.ToJson(file,true);
            
            Debug.Log(jsonero);

        }
    }  
}

