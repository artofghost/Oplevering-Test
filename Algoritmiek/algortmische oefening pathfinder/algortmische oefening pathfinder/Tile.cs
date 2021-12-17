using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algortmische_oefening_pathfinder
{
    class Tile
    {
        //dit zijn alle variable die ik nodig heb voor de tile/ vakje
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public int Distance { get; set; }
        public int CostDistance => Cost + Distance;
        public Tile Parent { get; set; }

        //De afstand is in principe de afstand rechtstreeks van het begin punt naar het eind punt. 
        //dus via de x en y as om te kijken hoe ver iets is zonder de muren mee te bereken. 
        public void SetDistance(int targetX, int targetY)
        {
            this.Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
        }
    }
}
