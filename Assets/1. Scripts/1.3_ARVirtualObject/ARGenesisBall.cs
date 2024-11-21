using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARGame2
{
    public enum EElementType
    {
        Metal,
        Wood,
        Water,
        Fire,
        Earth,
    }

    public enum EGenesisType
    {
        bulby,
        crocub,
        shepra,
        spikuff,
        sylvine,
        verfawn,
    }

    public class ARGenesisBall : MonoBehaviour
    {
        public EGenesisType eGenesisType;
        //tạm thời
        public string number;
        public string nameGenesis;
        public string fesValue;
        public EElementType eElementType;
        public string id;

        [SerializeField] private Transform _model;
        [SerializeField] private ARGenesisCanvas _aRGenesisCanvas;

        private void OnEnable() 
        {
            _model.localRotation = Quaternion.Euler(0,180,0);
        }

        private void OnDisable() 
        {

        }

        private void Awake() 
        {
            id = eElementType.ToString() + number + nameGenesis;    
        }

        private void Start() 
        {
            _aRGenesisCanvas?.UpdateInfo(fesValue, nameGenesis ,id);
        }

        public void ShowInfo(bool isShow)
        {
            _aRGenesisCanvas?.gameObject.SetActive(isShow);
        }
    }
}
