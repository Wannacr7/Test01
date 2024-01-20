using System;
using System.Collections.Generic;


[Serializable]
public class Block
{
    public int R { get; set; }
    public int C { get; set; }
    public int Number { get; set; }
}

[Serializable]
public class Data
{
    public List<Block> Blocks { get; set; }
}

[Serializable]
public class Results
{
    public int total_clicks;
    public float total_time;
    public int pairs;
    public float score;
}
