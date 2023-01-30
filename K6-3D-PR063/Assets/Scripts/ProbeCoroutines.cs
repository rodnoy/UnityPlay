using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeCoroutines : MonoBehaviour
{
    Coroutine myCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        // 1. we can simply launch like that
        //StartCoroutine(Counter(100));



        // 2.A. stop coroutine with ref
        if (myCoroutine != null){
            StopCoroutine(myCoroutine);
        }
        // 2.B. stop all coroutines launched by this script
        //StopAllCoroutines();
        // 2. or with ref
        myCoroutine = StartCoroutine(Counter(10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Counter(int countLimit)
    {
        //Debug.Log($"<color=red></color>");
        //yield break;


        int i = 0;
        while (i < countLimit) { 
            i++;
            Debug.Log($"<color=red>{i}</color>");
            yield return new WaitForSeconds(1);
        }
        Debug.Log("I'm done counting!");
    }
}
