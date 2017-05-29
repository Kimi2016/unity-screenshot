/*
	Screenshot utility menu.

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
using System.Collections.Generic;
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
        
        private static Camera[] GetCameras
        {
            get
            {                
                var selectedObjects = Selection.objects;
                if (selectedObjects.Length < 1) return null;

                var cameras = new List<Camera>();
                foreach (var selectedObject in selectedObjects)
                {
                    var selectedGameObject = selectedObject as GameObject;
                    if (selectedGameObject == null) continue;

                    var camera = selectedGameObject.GetComponent<Camera>();
                    if (camera == null) continue;                    
                    if (camera.enabled == false) continue;

                    cameras.Add(camera);
                }

                return cameras.Count < 1? null: cameras.ToArray();
            }
        }

        private static void SetupAndTakeShot(ScreenShotResoltutionOption resolutionoption)
        {
            _screenShotSetting = ScreenShotSetting.GetSetting(resolutionoption);
            if (_screenShotSetting == null) return;

            var cameras = GetCameras;
            if (cameras == null) return;

            foreach (var currCamera in cameras) ScreenShotUtils.TakeScreenShot(_screenShotSetting.Width, _screenShotSetting.Height, _screenShotSetting.Multiplier, currCamera);
        }

        /* --------------------------------------------- DIRECTORY OPTIONS */

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
            SetupAndTakeShot(ScreenShotResoltutionOption.CURRENT_25);
        }

        [MenuItem("ScreenShot/50% Current", false, 11)]
        public static void ScreenShot_50PercentCurrentSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.CURRENT_50);          
        }

        [MenuItem("ScreenShot/100% Current", false, 11)]
        public static void ScreenShot_100PercentCurrentSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.CURRENT_100);
        }

        [MenuItem("ScreenShot/150% Current", false, 11)]
        public static void ScreenShot_150PercentCurrentSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.CURRENT_150);
        }

        [MenuItem("ScreenShot/200% Current", false, 11)]
        public static void ScreenShot_200PercentCurrentSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.CURRENT_200);
        }

        [MenuItem("ScreenShot/400% Current", false, 11)]
        public static void ScreenShot_400PercentCurrentSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.CURRENT_400);
        }

        [MenuItem("ScreenShot/800% Current", false, 11)]
        public static void ScreenShot_800PercentCurrentSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.CURRENT_800);
        }

        /* ------------------------------------------------- FULL SCREEN */

        [MenuItem("ScreenShot/25% Full Screen", false, 22)]
        public static void ScreenShot_25PercentFullScreenSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.FULLSCREEN_25);
        }

        [MenuItem("ScreenShot/50% Full Screen", false, 22)]
        public static void ScreenShot_50PercentFullScreenSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.FULLSCREEN_50);
        }

        [MenuItem("ScreenShot/100% Full Screen", false, 22)]
        public static void ScreenShot_100PercentFullScreenSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.FULLSCREEN_100);
        }

        [MenuItem("ScreenShot/150% Full Screen", false, 22)]
        public static void ScreenShot_150PercentFullScreenSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.FULLSCREEN_150);
        }

        [MenuItem("ScreenShot/200% Full Screen", false, 22)]
        public static void ScreenShot_200PercentFullScreenSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.FULLSCREEN_200);
        }

        [MenuItem("ScreenShot/400% Full Screen", false, 22)]
        public static void ScreenShot_400PercentFullScreenSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.FULLSCREEN_400);
        }

        [MenuItem("ScreenShot/800% Full Screen", false, 22)]
        public static void ScreenShot_800PercentFullScreenSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.FULLSCREEN_800);
        }

        /* ---------------------------------------------- MOVIE RESOLUTIONS */

        [MenuItem("ScreenShot/720p (16:9)", false, 33)]
        public static void ScreenShot_720pSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.P720);
        }

        [MenuItem("ScreenShot/1080p (16:9)", false, 33)]
        public static void ScreenShot_1080pSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.P1080);
        }

        [MenuItem("ScreenShot/3K (16:9)", false, 33)]
        public static void ScreenShot_16_9_3KSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.THREE_K_16to9);
        }

        [MenuItem("ScreenShot/4K (16:9)", false, 33)]
        public static void ScreenShot_16to9_4KSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.FOUR_K_16to9);
        }

        [MenuItem("ScreenShot/5K (16:9)", false, 33)]
        public static void ScreenShot_16to9_5KSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.FIVE_K_16to9);
        }

        [MenuItem("ScreenShot/8K (16:9)", false, 33)]
        public static void ScreenShot_16to9_8KSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.EIGHT_K_16to9);
        }

        [MenuItem("ScreenShot/8K (16:10)", false, 33)]
        public static void ScreenShot_16to10_8KSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.EIGHT_K_16to10);
        }

        [MenuItem("ScreenShot/8K (64:27)", false, 33)]
        public static void ScreenShot_64to27_8KSize()
        {
            SetupAndTakeShot(ScreenShotResoltutionOption.EIGHT_K_64to27);
        }

        /* ---------------------------------------------- VALIDATE ALL RESOLUTIONS */

        [MenuItem("ScreenShot/25% Current", true)]
        [MenuItem("ScreenShot/50% Current", true)]
        [MenuItem("ScreenShot/100% Current", true)]
        [MenuItem("ScreenShot/150% Current", true)]
        [MenuItem("ScreenShot/200% Current", true)]
        [MenuItem("ScreenShot/400% Current", true)]
        [MenuItem("ScreenShot/800% Current", true)]        
        [MenuItem("ScreenShot/25% Full Screen", true)]
        [MenuItem("ScreenShot/50% Full Screen", true)]
        [MenuItem("ScreenShot/100% Full Screen", true)]
        [MenuItem("ScreenShot/150% Full Screen", true)]
        [MenuItem("ScreenShot/200% Full Screen", true)]
        [MenuItem("ScreenShot/400% Full Screen", true)]
        [MenuItem("ScreenShot/800% Full Screen", true)]        
        [MenuItem("ScreenShot/720p (16:9)", true)]
        [MenuItem("ScreenShot/1080p (16:9)", true)]
        [MenuItem("ScreenShot/3K (16:9)", true)]
        [MenuItem("ScreenShot/4K (16:9)", true)]
        [MenuItem("ScreenShot/5K (16:9)", true)]
        [MenuItem("ScreenShot/8K (16:9)", true)]
        [MenuItem("ScreenShot/8K (16:10)", true)]
        [MenuItem("ScreenShot/8K (64:27)", true)]
        public static bool ValidateAllResolutions()
        {
            var cameras = GetCameras;
            return cameras != null;
        }
    }
}