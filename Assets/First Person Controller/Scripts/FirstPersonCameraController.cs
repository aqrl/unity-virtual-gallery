using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invector.vCamera { 
    public class FirstPersonCameraController : MonoBehaviour
    {
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

