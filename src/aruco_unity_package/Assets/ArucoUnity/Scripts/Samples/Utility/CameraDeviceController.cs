﻿using UnityEngine;

namespace ArucoUnity
{
  /// \addtogroup aruco_unity_package
  /// \{

  namespace Samples
  {
    namespace Utility
    {
      // TODO: doc
      /// <summary>
      /// Based on: http://answers.unity3d.com/answers/1155328/view.html
      /// </summary>
      public class CameraDeviceController : MonoBehaviour
      {
        // Configuration
        [SerializeField]
        private int cameraId;

        // Properties
        public CameraDevice ActiveCameraDevice { get; private set; }

        // Events
        public delegate void CameraDeviceControllerAction(CameraDevice previousCameraDevice);
        public event CameraDeviceControllerAction OnActiveCameraDeviceChanged;

        void Start()
        {
          ActiveCameraDevice = gameObject.AddComponent<CameraDevice>();
          SwitchCamera(cameraId);
        }

        // Switch between cameras devices
        public void SwitchCamera(int? cameraIndex = null)
        {
          // Check for camera devices
          WebCamDevice[] webcamDevices = WebCamTexture.devices;
          if (webcamDevices.Length == 0)
          {
            Debug.LogError(gameObject.name + ": No devices cameras found.");
          }

          // Stop the previous camera device
          CameraDevice previousCameraDevice = ActiveCameraDevice;
          if (previousCameraDevice != null)
          {
            previousCameraDevice.StopCamera();
          }

          // Switch to the next camera device
          cameraId = (cameraIndex != null) ? (int)cameraIndex : cameraId + 1;
          cameraId %= WebCamTexture.devices.Length;

          ActiveCameraDevice.ResetCamera(webcamDevices[cameraId]);
          ActiveCameraDevice.StartCamera();

          // Update the state
          if (OnActiveCameraDeviceChanged != null)
          {
            OnActiveCameraDeviceChanged(previousCameraDevice);
          }
        }
      }
    }
  }

  /// \} aruco_unity_package
}