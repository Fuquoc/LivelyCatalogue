using System;
using System.Collections;
using System.Collections.Generic;
using ARGame2;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenesisInventory : MonoBehaviour
{
    public static Action OnCloseInventory;

    [SerializeField] private Transform _content;
    [SerializeField] private List<ARGenesisBall> aRGenesisBall;

    [SerializeField] private TextMeshProUGUI _textFes;
    [SerializeField] private TextMeshProUGUI _textID;
    [SerializeField] private TextMeshProUGUI _genesisName;

    [SerializeField] private Button _buttonClose;
    
    [SerializeField] private InfiniteScroll _infiniteScroll;
    [SerializeField] private GenesisFoodMgr _genesisFoodMgr;

    [SerializeField] private GameObject _inventory3D;
    [SerializeField] private GameObject _modelRotation;

    private GenesisInventoryItem[] _listGenesisItem;

    private void Awake() 
    {
        _listGenesisItem = _content.GetComponentsInChildren<GenesisInventoryItem>();
    }

    private void Start() 
    {
        InitItem();    
    }

    private void InitItem()
    {
        foreach(var item in _listGenesisItem)
        {
            item.Init(this);
        }
    }

    private void OnEnable() 
    {
        _infiniteScroll.OnSelectMiddleItem.AddListener(OnSelectItem);   
        _infiniteScroll.OnUnSelectMiddleItem.AddListener(OnUnSelectItem);   
        _buttonClose.onClick.AddListener(OnClickButtonClose);
    }

    private void OnDisable()
    {
        _infiniteScroll.OnSelectMiddleItem.RemoveListener(OnSelectItem);   
        _infiniteScroll.OnUnSelectMiddleItem.RemoveListener(OnUnSelectItem); 
        _buttonClose.onClick.RemoveListener(OnClickButtonClose);
    }

    private void OnSelectItem(GameObject item)
    {
        if(item == null) 
            return;
        GenesisInventoryItem giitem = item.GetComponent<GenesisInventoryItem>();

        giitem.ScaleUp();

        ShowARGenesis(giitem.eGenesisType);
    }

    private void OnUnSelectItem(GameObject item)
    {
        if(item == null) 
            return;
        GenesisInventoryItem giitem = item.GetComponent<GenesisInventoryItem>();

        giitem.ScaleDown();
    }

    private void ShowARGenesis(EGenesisType eGenesisType)
    {
        foreach(var arBall in aRGenesisBall)
        {
            if(arBall.eGenesisType == eGenesisType)
            {
                arBall.gameObject.SetActive(true);
                UpdateInfo(arBall);
                UpdateFood(arBall);
            }
            else
            {
                arBall.gameObject.SetActive(false);
            }
        }
    }

    public void ScrollToItem(GameObject item)
    {
        _infiniteScroll.ScrollToItem(item);
    }

    private void UpdateInfo(ARGenesisBall aRGenesisBall)
    {
        _textFes.text = $"{aRGenesisBall.fesValue} FES";
        _textID.text = $"ID: {aRGenesisBall.id}";
        _genesisName.text = aRGenesisBall.nameGenesis;
    }

    private void UpdateFood(ARGenesisBall aRGenesisBall)
    {
        _genesisFoodMgr.SelectFoodForCurrentGenesis(aRGenesisBall);
    }
 
    private void OnClickButtonClose()
    {
        gameObject.SetActive(false);
        _inventory3D.SetActive(false);
        _modelRotation.SetActive(false);
        OnCloseInventory?.Invoke();
    }
}
