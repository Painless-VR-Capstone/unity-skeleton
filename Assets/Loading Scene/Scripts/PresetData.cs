using UnityEngine;
using System.Collections.Generic;
using System;

namespace PainlessVR
{
    public static class PresetData
    {
        public static Dictionary<string, string> variables;


        public static Color ParseColor(string rawColor)
        {
            string[] rGB = rawColor.Split(';');
            return new Color(Single.Parse(rGB[0]), Single.Parse(rGB[1]), Single.Parse(rGB[2]));
        }
    }
}
