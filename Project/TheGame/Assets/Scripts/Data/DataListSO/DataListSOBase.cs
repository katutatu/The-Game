using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataListSOBase<T> : ScriptableObject where T : DataBase
{
    public T[] DataList;


    public T Find(string id)
    {
        return DataList.FirstOrDefault(it => it.id == id);
    }
}
