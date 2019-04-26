using UnityEngine;

public class UV
{

    private static string[] sendDataToJar(string func, string[] dataToSend)
    {
        // Create object array that will be passed to the CallStatic method
        object[] objParams = new object[1];
        string[] innerData = new string[dataToSend.Length];

        // By assigning item 1 in the object[], you are preventing the compiler from parsing them into the function call, so the Unity code sees the string[] and creates the Java signature properly
        objParams[0] = innerData;

        // Just for grins, let's also receive a string[] back from java (String[] in java, string[] in C#) and do a manual conversion on it treating it like an Object
        AndroidJavaClass classInst = new AndroidJavaClass("com.duli_industries.uv_utilities.UV");
        AndroidJavaObject returnedObjectArray = classInst.CallStatic<AndroidJavaObject>(func, objParams);
        string[] resultsArray = null;

        if (returnedObjectArray != null && returnedObjectArray.GetRawObject().ToInt32() != 0)
        {
            resultsArray = AndroidJNIHelper.ConvertFromJNIArray<string[]>(returnedObjectArray.GetRawObject());
            // Debug.Log(string.Format("Got returned {0}", returnedStrings));
        }

        return resultsArray;
    }

    public static string testPrintStatic()
    {
        return sendDataToJar("testPrintStatic", new string[] { "null" })[0];
    }

    public static void open()
    {
        sendDataToJar("open", new string[] { "null" });
    }

    public static void close()
    {
        sendDataToJar("close", new string[] { "null" });
    }

    public static int get_ADC_Val()
    {
        return int.Parse(sendDataToJar("get_ADC_Val", new string[] { "null" })[0]);
    }
}
