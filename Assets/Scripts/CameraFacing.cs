﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.CORE
{
    public class CameraFacing : MonoBehaviour
    {
         void Update()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}
