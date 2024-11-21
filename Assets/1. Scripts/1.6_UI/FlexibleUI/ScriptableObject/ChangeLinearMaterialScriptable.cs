using System.Collections.Generic;
using ARGame2;
using UnityEngine;

[CreateAssetMenu(fileName = "ChangeLinearMaterialScriptable", menuName = "ScriptableObjects/ChangeLinearMaterialScriptable", order = 1)]
public class ChangeLinearMaterialScriptable : ScriptableObject
{
    public List<LinearColorConfig> spriteConfigs;

    public Sprite GetSprite(EElementType eElementType)
    {
        foreach(var cf in spriteConfigs)
        {
            if(cf.eElementType == eElementType)
            {
                // return cf.sprite;
            }
        }

        return null;
    }
}

[System.Serializable]
public class LinearColorConfig
{
    public Color colorTop;
    public Sprite colorBot;
    public EElementType eElementType;
}