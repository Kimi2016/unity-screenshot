/*
	Screenshot utility container.

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

using System.Collections.Generic;

namespace DIY.Framework.Utils
{
    public class ScreenShotSetting
    {
        private static readonly Dictionary<ScreenShotResoltutionOption, ScreenShotSetting>  SETTINGS = new Dictionary<ScreenShotResoltutionOption, ScreenShotSetting>();
        private static readonly List<string>                                                DESCRIPTIONS = new List<string>() { "Custom" };

        private readonly int         _width;
        private readonly int        _height;
        private readonly float      _multiplier;        

        public int                  Width { get { return this._width; } }
        public int                  Height { get { return this._height; } }
        public float                Multiplier { get { return this._multiplier; } }        
        public static List<string>  Descriptions { get { return DESCRIPTIONS; } }

        public static int           Count { get { return SETTINGS.Count; } }

        public ScreenShotSetting(ScreenShotResoltutionOption resolutionoption, int width, int height, float multiplier, string description)
        {
            this._width = width;
            this._height = height;
            this._multiplier = multiplier;
                        
            DESCRIPTIONS.Add(description);            
            SETTINGS[resolutionoption] = this;
        }

        public static ScreenShotSetting GetSetting(ScreenShotResoltutionOption resolutionoption)
        { return SETTINGS.ContainsKey(resolutionoption) ? SETTINGS[resolutionoption] : null; }

        public static bool Contains(ScreenShotResoltutionOption resolutionoption)
        { return SETTINGS.ContainsKey(resolutionoption); }
    }
}