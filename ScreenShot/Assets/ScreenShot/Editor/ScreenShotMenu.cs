/*
	Screenshot utiity menu.

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

using System.IO;
using UnityEditor;
using UnityEngine;

using DIY.Framework.Utils;

namespace DIY.Framework.Menu
{
    public static class ScreenShotMenu
    {
        private static ScreenShotSetting _screenShotSetting;

        static ScreenShotMenu()
        {
            new ScreenShotSetup();            
        }

        private static Camera GetCamera
        {
            get
            {
                var sel = Selection.objects;
                if (sel.Length > 1 || sel.Length < 1)
                {
                    Debug.Log("Selection must contain one (only) object.");
                    return null;
                }

                var selectedGameObject = sel[0] as GameObject;
                if (selectedGameObject == null) return null;

                var camera = selectedGameObject.GetComponent<Camera>();
                if (camera == null)
                {
                    Debug.Log("Selected object doesn't contain <Camera> component.");
                    return null;
                }

                return camera;
            }
        }

        private static void SetupResolutionSetting(ScreenShotResoltutionOption resolutionoption, Camera camera)
        {
            _screenShotSetting = ScreenShotSetting.GetSetting(resolutionoption);
            if (_screenShotSetting != null) ScreenShotUtils.TakeScreenShot(_screenShotSetting.Width, _screenShotSetting.Height, _screenShotSetting.Multiplier, camera);
        }

        [MenuItem("ScreenShot/Show Directory", false, 00)]
        public static void ShowDirectory()
        {
            switch (UnityEngine.SystemInfo.operatingSystemFamily)
            {
                case OperatingSystemFamily.Windows:
                    System.Diagnostics.Process.Start("explorer.exe", (true ? "/root," : "/select,") + ScreenShotUtils.GetDirectoryPath);
                    break;
                case OperatingSystemFamily.MacOSX:
                    Debug.Log("Not implemented. I don't use MAC :)");
                    break;
            }
        }

        [MenuItem("ScreenShot/Show Directory", true)]
        public static bool ValidateShowDirectory()
        {
            return Directory.Exists(ScreenShotUtils.GetDirectoryPath);
        }

        [MenuItem("ScreenShot/Clean Directory", false, 44)]
        public static void CleanDirectory()
        {
            ScreenShotUtils.CleanDirectory();
        }

        [MenuItem("ScreenShot/Clean Directory", true)]
        public static bool ValidateCleanDirectory()
        {
            var directory = ScreenShotUtils.GetDirectoryPath;
            if (!Directory.Exists(directory)) return false;

            return Directory.GetFiles(directory).Length > 0;
        }

        [MenuItem("ScreenShot/Delete Directory", false, 44)]
        public static void DeleteDirectory()
        {
            ScreenShotUtils.DeleteDirectory();
        }

        [MenuItem("ScreenShot/Delete Directory", true)]
        public static bool ValidateDeleteDirectory()
        {
            return Directory.Exists(ScreenShotUtils.GetDirectoryPath);
        }

        /* --------------------------------------------- CURRENT RESOLUTION */

        [MenuItem("ScreenShot/25% Current", false, 11)]
        public static void ScreenShot_25PercentCurrentSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.CURRENT_25, camera);
        }

        [MenuItem("ScreenShot/50% Current", false, 11)]
        public static void ScreenShot_50PercentCurrentSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.CURRENT_50, camera);          
        }

        [MenuItem("ScreenShot/100% Current", false, 11)]
        public static void ScreenShot_100PercentCurrentSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.CURRENT_100, camera);
        }

        [MenuItem("ScreenShot/150% Current", false, 11)]
        public static void ScreenShot_150PercentCurrentSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.CURRENT_150, camera);
        }

        [MenuItem("ScreenShot/200% Current", false, 11)]
        public static void ScreenShot_200PercentCurrentSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.CURRENT_200, camera);
        }

        [MenuItem("ScreenShot/400% Current", false, 11)]
        public static void ScreenShot_400PercentCurrentSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.CURRENT_400, camera);
        }

        [MenuItem("ScreenShot/800% Current", false, 11)]
        public static void ScreenShot_800PercentCurrentSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.CURRENT_800, camera);
        }

        /* ------------------------------------------------- FULL SCREEN */

        [MenuItem("ScreenShot/25% Full Screen", false, 22)]
        public static void ScreenShot_25PercentFullScreenSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.FULLSCREEN_25, camera);
        }

        [MenuItem("ScreenShot/50% Full Screen", false, 22)]
        public static void ScreenShot_50PercentFullScreenSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.FULLSCREEN_50, camera);
        }

        [MenuItem("ScreenShot/100% Full Screen", false, 22)]
        public static void ScreenShot_100PercentFullScreenSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.FULLSCREEN_100, camera);
        }

        [MenuItem("ScreenShot/150% Full Screen", false, 22)]
        public static void ScreenShot_150PercentFullScreenSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.FULLSCREEN_150, camera);
        }

        [MenuItem("ScreenShot/200% Full Screen", false, 22)]
        public static void ScreenShot_200PercentFullScreenSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.FULLSCREEN_200, camera);
        }

        [MenuItem("ScreenShot/400% Full Screen", false, 22)]
        public static void ScreenShot_400PercentFullScreenSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.FULLSCREEN_400, camera);
        }

        [MenuItem("ScreenShot/800% Full Screen", false, 22)]
        public static void ScreenShot_800PercentFullScreenSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.FULLSCREEN_800, camera);
        }

        /* ---------------------------------------------- MOVIE RESOLUTIONS */

        [MenuItem("ScreenShot/720p (16:9)", false, 33)]
        public static void ScreenShot_720pSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.P720, camera);
        }

        [MenuItem("ScreenShot/1080p (16:9)", false, 33)]
        public static void ScreenShot_1080pSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.P1080, camera);
        }

        [MenuItem("ScreenShot/3K (16:9)", false, 33)]
        public static void ScreenShot_16_9_3KSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.THREE_K_16to9, camera);
        }

        [MenuItem("ScreenShot/4K (16:9)", false, 33)]
        public static void ScreenShot_16to9_4KSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.FOUR_K_16to9, camera);
        }

        [MenuItem("ScreenShot/5K (16:9)", false, 33)]
        public static void ScreenShot_16to9_5KSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.FIVE_K_16to9, camera);
        }

        [MenuItem("ScreenShot/8K (16:9)", false, 33)]
        public static void ScreenShot_16to9_8KSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.EIGHT_K_16to9, camera);
        }

        [MenuItem("ScreenShot/8K (16:10)", false, 33)]
        public static void ScreenShot_16to10_8KSize()
        {
            var camera = GetCamera;
            if (camera == null) return;

            SetupResolutionSetting(ScreenShotResoltutionOption.EIGHT_K_16to10, camera);
        }
    }
}