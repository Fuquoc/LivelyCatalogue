using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace ARGame2
{
    public class M_ARObjectTrackingMgr : MonoBehaviour
    {
        [SerializeField] private ARTrackedImageManager aRTrackedImageManager;

        [SerializeField] private GameObject _demoGameobject;

        private TrackedVirtualObject cube;

        private void OnEnable() 
        {
            aRTrackedImageManager.trackedImagesChanged += OnImageChange;       
        }

        private void OnImageChange(ARTrackedImagesChangedEventArgs args)
        {
            foreach(var image in args.added)
            {
                Debug.Log("CREATE");
                var newPrefab = Instantiate(_demoGameobject, Vector3.zero, Quaternion.identity);
                cube = new TrackedVirtualObject();
                cube.Add(image, newPrefab);
            }   

            foreach(var image in args.updated)
            {
                cube.TryToUpdate(image);
            }

            foreach(var image in args.updated)
            {

            }
        }
    }
}

