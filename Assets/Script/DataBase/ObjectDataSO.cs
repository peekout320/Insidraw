using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectDataSO", menuName = " Create ObjectDataSO")]
public class ObjectDataSO : ScriptableObject
{
    public List<ObjectData> objrctDataList = new List<ObjectData>();
}
