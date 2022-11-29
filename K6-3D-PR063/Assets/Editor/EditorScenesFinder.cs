using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static System.Web.Razor.Parser.SyntaxConstants;

//public class EditorScenesFinder : MonoBehaviour
public class EditorScenesFinder
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    [MenuItem("Tools/Find Scripts")]
    private static void MTwo()
    {
        MonoBehaviour[] armyUnits = Object.FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour v in armyUnits)
        {
            Debug.Log(v.name + "-" + v.gameObject.name);
        }
    }
}
