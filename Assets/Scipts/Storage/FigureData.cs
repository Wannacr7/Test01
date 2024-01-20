using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureData", menuName = "Custom/FigureData", order = 1)]
public class FigureData : ScriptableObject
{
    [System.Serializable]
    public struct FigureInfo
    {
        public int id;
        public Sprite image;
    }

    public List<FigureInfo> figures = new List<FigureInfo>();
}
