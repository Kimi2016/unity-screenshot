/*
	Screenshot utility gameobject.

	IMPORTANT! ------------------------------------------	
	-----------------------------------------------------

	Author: 	SWANN
	Email:		sebastianswann@outlook.com

	LICENSE ------------------------------------------

	Copyright (c) 2016-2017 SWANN
	All rights reserved.

	Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

	1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
	2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
	3. The names of the contributors may not be used to endorse or promote products derived from this software without specific prior written permission.

	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using UnityEngine;
using DIY.Framework.Utils;

namespace DIY.Framework
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof (Camera))]
    [AddComponentMenu("Rendering/ScreenShot", 99)]
    public class ScreenShot : MonoBehaviour
    {        
        [SerializeField] private int                        _resolutionMode = (int) ScreenShotResoltutionOption.CURRENT_100; // this field is reskined in ScreenShotEditor
        [SerializeField] private int                        _width = Screen.width;
        [SerializeField] private int                        _height = (int) (Screen.width / 4.21f);
        [SerializeField] private float                      _multiplier = 1.0f;
        [SerializeField] private KeyCode                    _key = KeyCode.X;

        private ScreenShotSetting                           _screenShotSetting;
        private bool                                        _canTakeScreenShot;
        private Camera                                      _camera;

        private void Awake()
        {
            new ScreenShotSetup();
        }

        private void Start()
        {
            this._camera = GetComponent<Camera>();
        }

        private void LateUpdate()
        {
            this._canTakeScreenShot |= Input.GetKeyDown(this._key);
            if (!this._canTakeScreenShot) return;
            
            if (this._resolutionMode != (int) ScreenShotResoltutionOption.CUSTOM)
            {
                this._screenShotSetting = ScreenShotSetting.GetSetting((ScreenShotResoltutionOption)this._resolutionMode);
                if (this._screenShotSetting == null)
                {
                    Debug.Log(string.Format("No setting with {0} found.", this._resolutionMode));
                    return;
                }

                this._width = this._screenShotSetting.Width;
                this._height = this._screenShotSetting.Height;
                this._multiplier = this._screenShotSetting.Multiplier;
            }

            ScreenShotCommon.TakeScreenShot(this._width, this._height, this._multiplier, this._camera);

            this._canTakeScreenShot = false;
        }
    }
}