using System.Collections;
using System.Collections.Generic;
using ARGame2;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLinearTextMeshPro : MonoBehaviour
{
    [SerializeField] private ChangeTMPScriptable changeTMPScriptable;
    [SerializeField] private EElementType eElementType;
    private TextMeshProUGUI textMeshProUGUI;

    private void Awake() 
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();    
    }

    private void Start() 
    {
        UpdateSprite(eElementType);
    }

    public void UpdateSprite(EElementType eElementType)
    {
        TMPConfig tMPConfig = changeTMPScriptable.GetTMPConfig(eElementType);
        VertexGradient gradient = new VertexGradient(
                tMPConfig.topLeft,
                tMPConfig.topRight,
                tMPConfig.bottomLeft,
                tMPConfig.bottomRight
            );

        textMeshProUGUI.colorGradient = gradient;
    }
}
