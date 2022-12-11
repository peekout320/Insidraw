using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayTest : MonoBehaviour
{
    [SerializeField]
    int[] array;

    public int[] GetArray()
    {
        return array;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            array = makeArray();
        testArray();
    }

    public int[] makeArray()
    {
        int[] arrayValues;

        arrayValues = new int[] { 0, 1, 2 };

        return arrayValues;
    }

    public void testArray()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            array = new int[] { 0, 1, 2 };
        }
    }

    public void PrintArray(int[] array)
    {
        Debug.Log(array);
    }

}
