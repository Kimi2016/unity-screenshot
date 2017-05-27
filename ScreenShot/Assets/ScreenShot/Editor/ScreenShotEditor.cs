/*
	Screenshot utiity gameobject inspector.

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

using UnityEditor;
using UnityEngine;
using DIY.Framework.Utils;

namespace DIY.Framework
{
    [CustomEditor(typeof(ScreenShot))]
    public class ScreenShotEditor : Editor
    {
        private SerializedProperty          _resolutionModeProperty;
        private SerializedProperty          _widthProperty;
        private SerializedProperty          _heightProperty;
        private SerializedProperty          _multiplierProperty;
        private SerializedProperty          _keyProperty;

        private ScreenShotResoltutionOption _selected;

        private void OnEnable()
        {
            new ScreenShotSetup();

            this._resolutionModeProperty    = this.serializedObject.FindProperty("_resolutionMode");
            this._widthProperty             = this.serializedObject.FindProperty("_width");
            this._heightProperty            = this.serializedObject.FindProperty("_height");
            this._multiplierProperty        = this.serializedObject.FindProperty("_multiplier");
            this._keyProperty               = this.serializedObject.FindProperty("_key");

            this._selected = (ScreenShotResoltutionOption)this._resolutionModeProperty.intValue;
        }

        public override void OnInspectorGUI()
        {            
            // reskin ScreenShot::_resolutionMode to make it more readable
            this._selected = (ScreenShotResoltutionOption) EditorGUILayout.Popup("Resolution", (int)this._selected, ScreenShotSetting.Descriptions.ToArray());

            // update rest of the UI
            serializedObject.Update();
            this._resolutionModeProperty.intValue = (int)this._selected;
                        
            if (this._selected == ScreenShotResoltutionOption.CUSTOM)
            {
                EditorGUI.indentLevel++;                
                EditorGUILayout.PropertyField(this._widthProperty, new GUIContent("Width", "Specify screenshot width."));
                EditorGUILayout.PropertyField(this._heightProperty, new GUIContent("Height", "Specify screenshot height."));                
                EditorGUILayout.PropertyField(this._multiplierProperty, new GUIContent("Multiplier", "Multiply screenshot width/height by specified value."));                
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.PropertyField(this._keyProperty, new GUIContent("Key", "Key used to take screenshot."));
            serializedObject.ApplyModifiedProperties();
        }
    }
}