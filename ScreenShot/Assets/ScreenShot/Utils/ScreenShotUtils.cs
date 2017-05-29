/*
	Screenshot utility.

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
using UnityEngine;

namespace DIY.Framework.Utils
{
    public class ScreenShotUtils
    {
        public static string GetDirectoryPath
        { get { return Path.GetFullPath(string.Format("{0}/../ScreenShots/", Application.dataPath)); } }

        public static string[] GetFiles
        {
            get
            {
                var directory = GetDirectoryPath;
                if (!Directory.Exists(directory)) return null;

                var files = Directory.GetFileSystemEntries(directory);
                return files.Length < 1 ? null : files;
            }
        }

        private static string GetFilePath(int width, int height, Camera camera)
        {
            return string.Format("{0}{1}_{2}x{3}_{4}.png", GetDirectoryPath, camera.gameObject.name, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        }

        public static void DeleteDirectory()
        {
            var directory = GetDirectoryPath;
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            Directory.Delete(directory, true);
            Debug.Log(string.Format("Deleted screenshot directory: {0}", directory));
        }

        public static void CleanDirectory()
        {
            var files = GetFiles;
            if (files == null) return;

            foreach (var file in files) File.Delete(file);
            Debug.Log(string.Format("Cleaned: {0}", GetDirectoryPath));
        }

        public static void TakeScreenShot(int width, int height, float multiplier, Camera camera)
        {
            // set resolution
            var screenShotWidth = (int) (width * multiplier);
            var screenShotHeight = (int) (height * multiplier);

            // render camera with specified resolution
            var renderTexture = new RenderTexture(screenShotWidth, screenShotHeight, 24);
            camera.targetTexture = renderTexture;
            camera.Render();
            RenderTexture.active = renderTexture;

            // store in image
            var screenShot = new Texture2D(screenShotWidth, screenShotHeight, TextureFormat.RGB24, false);
            screenShot.ReadPixels(new Rect(0, 0, screenShotWidth, screenShotHeight), 0, 0);

            // clean up
            camera.targetTexture = null;
            RenderTexture.active = null;

#if UNITY_EDITOR
            Object.DestroyImmediate(renderTexture);
#else
            Object.Destroy(renderTexture);
#endif

            // create path
            if (!Directory.Exists(GetDirectoryPath)) Directory.CreateDirectory(GetDirectoryPath);
            var filename = GetFilePath(screenShotWidth, screenShotHeight, camera);            

            // flush data
            var bytes = screenShot.EncodeToPNG();
            File.WriteAllBytes(filename, bytes);

            Debug.Log(string.Format("ScreenShot stored in: {0}", filename));
        }
    }
}