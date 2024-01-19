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

    public FigureInfo[] figures = new FigureInfo[10];
}
