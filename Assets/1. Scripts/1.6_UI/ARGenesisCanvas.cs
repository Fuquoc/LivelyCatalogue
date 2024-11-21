using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ARGame2
{
    public class ARGenesisCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _infoPanel;
        [SerializeField] private TextMeshProUGUI _textFes;
        [SerializeField] private TextMeshProUGUI _textID;
        [SerializeField] private TextMeshProUGUI _textGenesisName;

        private Transform _cameraTransform;

        private void Awake() 
        {
            _cameraTransform = Camera.main.transform;
        }

        private void Update() 
        {
            FollowCamera();
        }

        private void FollowCamera()
        {
            Vector3 direction = transform.position - _cameraTransform.position;

            // Tránh lỗi do vector direction bằng zero
            if (direction.sqrMagnitude > 0.01f) // Kiểm tra khoảng cách bình phương
            {
                Quaternion lookCamera = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = lookCamera;
            }
        }

        public void UpdateInfo(string fesValue, string name, string id)
        {
            _textFes.text = $"{fesValue} FES";
            _textID.text = $"ID: {id}";
            _textGenesisName.text = name;
        }

        public void ShowInfo(bool isShow)
        {
            _infoPanel.SetActive(isShow);
        }
    }
}