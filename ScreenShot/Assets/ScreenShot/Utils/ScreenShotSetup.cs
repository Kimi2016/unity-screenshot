/*
	Screenshot utiity setup.

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

namespace DIY.Framework.Utils
{
    public class ScreenShotSetup
    {
        public ScreenShotSetup()
        {
            /* --------------------------------------------- CURRENT RESOLUTION */

            AddSetting(ScreenShotResoltutionOption.CURRENT_25, Screen.width, Screen.height, 0.25f, "25% Current");
            AddSetting(ScreenShotResoltutionOption.CURRENT_50, Screen.width, Screen.height, 0.5f, "50% Current");
            AddSetting(ScreenShotResoltutionOption.CURRENT_100, Screen.width, Screen.height, 1.0f, "100% Current");
            AddSetting(ScreenShotResoltutionOption.CURRENT_150, Screen.width, Screen.height, 1.5f, "150% Current");
            AddSetting(ScreenShotResoltutionOption.CURRENT_200, Screen.width, Screen.height, 2.0f, "200% Current");
            AddSetting(ScreenShotResoltutionOption.CURRENT_400, Screen.width, Screen.height, 4.0f, "400% Current");
            AddSetting(ScreenShotResoltutionOption.CURRENT_800, Screen.width, Screen.height, 8.0f, "800% Current");

            /* ------------------------------------------------- FULL SCREEN */

            AddSetting(ScreenShotResoltutionOption.FULLSCREEN_25, Screen.currentResolution.width, Screen.currentResolution.height, 0.25f, "25% Full Screen");
            AddSetting(ScreenShotResoltutionOption.FULLSCREEN_50, Screen.currentResolution.width, Screen.currentResolution.height, 0.5f, "50% Full Screen");
            AddSetting(ScreenShotResoltutionOption.FULLSCREEN_100, Screen.currentResolution.width, Screen.currentResolution.height, 1.0f, "100% Full Screen");
            AddSetting(ScreenShotResoltutionOption.FULLSCREEN_150, Screen.currentResolution.width, Screen.currentResolution.height, 1.5f, "150% Full Screen");
            AddSetting(ScreenShotResoltutionOption.FULLSCREEN_200, Screen.currentResolution.width, Screen.currentResolution.height, 2.0f, "200% Full Screen");
            AddSetting(ScreenShotResoltutionOption.FULLSCREEN_400, Screen.currentResolution.width, Screen.currentResolution.height, 4.0f, "400% Full Screen");
            AddSetting(ScreenShotResoltutionOption.FULLSCREEN_800, Screen.currentResolution.width, Screen.currentResolution.height, 8.0f, "800% Full Screen");

            /* ---------------------------------------------- MOVIE RESOLUTIONS */

            AddSetting(ScreenShotResoltutionOption.P720, 1280, 720, 1.0f, "720p (16:9)");
            AddSetting(ScreenShotResoltutionOption.P1080, 1920, 1080, 1.0f, "1080p (16:9)");
            AddSetting(ScreenShotResoltutionOption.THREE_K_16to9, 3072, 1728, 1.0f, "3K (16:9)");
            AddSetting(ScreenShotResoltutionOption.FOUR_K_16to9, 3840, 2160, 1.0f, "4K (16:9)");
            AddSetting(ScreenShotResoltutionOption.FIVE_K_16to9, 5120, 2880, 1.0f, "5K (16:9)");
            AddSetting(ScreenShotResoltutionOption.EIGHT_K_16to9, 7680, 4320, 1.0f, "8K (16:9)");
            AddSetting(ScreenShotResoltutionOption.EIGHT_K_16to10, 8192, 5120, 1.0f, "8K (16:10)");
        }

        private static void AddSetting(ScreenShotResoltutionOption resolutionoption, int width, int height, float multiplier, string description)
        {
            if (ScreenShotSetting.Contains(resolutionoption)) return;

            new ScreenShotSetting(resolutionoption, width, height, multiplier, description);
        }
    }
}