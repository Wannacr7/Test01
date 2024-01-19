using System;
using System.Collections.Generic;


namespace Assets.Scipts.Models
{
    [Serializable]
    public class Block
    {
        public int R { get; set; }
        public int C { get; set; }
        public int Number { get; set; }
    }

    [Serializable]
    class Data
    {
        public List<Block> Blocks { get; set; }

    }

}
