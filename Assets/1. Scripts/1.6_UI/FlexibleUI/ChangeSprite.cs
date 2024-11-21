using ARGame2;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private ChangeSpriteScriptable changeSpriteScriptable;
    [SerializeField] private EElementType eElementType;
    private Image image;

    private void Awake() 
    {
        image = GetComponent<Image>();    
    }

    private void Start() 
    {
        UpdateSprite(eElementType);
    }

    public void UpdateSprite(EElementType eElementType)
    {
        image.sprite = changeSpriteScriptable.GetSprite(eElementType);
    }
}
