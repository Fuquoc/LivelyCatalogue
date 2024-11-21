using System.Collections;
using System.Collections.Generic;
using ARGame2;
using UnityEngine;

public class GenesisFoodItem : MonoBehaviour
{
    public EElementType eElementType;

    private GenesisFoodItem _genesisFoodMgr;

    public void Init(GenesisFoodItem mgr)
    {
        _genesisFoodMgr = mgr;
    }

    private void Awake() 
    {

    }

    public void ScaleUp()
    {
        transform.localScale = Vector3.one * 2f;
    }

    public void ScaleDown()
    {
        transform.localScale = Vector3.one;
    }
}
