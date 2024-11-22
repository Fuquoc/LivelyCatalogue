using System.Collections;
using System.Collections.Generic;
using ARGame2;
using UnityEngine;
using UnityEngine.UI;

public class GenesisFoodMgr : MonoBehaviour
{
    private GenesisFoodItem[] _genesisFoodItem;

    [SerializeField] private Transform _content;
    [SerializeField] private InfiniteScroll _infiniteScroll;

    private void Awake() 
    {
        _genesisFoodItem = _content.GetComponentsInChildren<GenesisFoodItem>();
    }

    private void OnEnable() 
    {
        _infiniteScroll.OnSelectMiddleItem.AddListener(OnSelectFoodItem);   
        _infiniteScroll.OnUnSelectMiddleItem.AddListener(OnUnSelectItem);   
    }

    private void OnDisable()
    {
        _infiniteScroll.OnSelectMiddleItem.RemoveListener(OnSelectFoodItem);   
        _infiniteScroll.OnUnSelectMiddleItem.RemoveListener(OnUnSelectItem);   
    }

    public void SelectFoodForCurrentGenesis(ARGenesisBall aRGenesisBall)
    {
        foreach(var food in _genesisFoodItem)
        {
            if(food.eElementType == aRGenesisBall.eElementType)
            {
                ScrollToItem(food.gameObject);
            }
        }
    }

    public void ScrollToItem(GameObject item)
    {
        _infiniteScroll.ScrollToItem(item);
    }

    private void OnSelectFoodItem(GameObject item)
    {
        if(item == null) 
            return;
        GenesisFoodItem gFoodItem = item.GetComponent<GenesisFoodItem>();

        gFoodItem.ScaleUp();
    }

    private void OnUnSelectItem(GameObject item)
    {
        if(item == null) 
            return;
        GenesisFoodItem gFoodItem = item.GetComponent<GenesisFoodItem>();

        gFoodItem.ScaleDown();
    }
}
