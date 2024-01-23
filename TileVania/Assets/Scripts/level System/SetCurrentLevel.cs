using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurrentLevel : MonoBehaviour
{
    [SerializeField]
    private string _Idlevel;
    private void Start()
    {
        SaveProgress.SetCurrentLevelId(_Idlevel);
    }
}
