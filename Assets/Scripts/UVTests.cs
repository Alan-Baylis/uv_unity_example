using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVTests : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Android function is to be called 2");

		// UV.open();
        string result = UV.testPrintStatic();
		// int val = UV.get_ADC_Val();
		// UV.close();

        Debug.Log(string.Format("Result was {0}", result));

        Debug.Log("Androidtion is called");
    }
}