using System;
using System.Collections.Generic;
using System.Linq;

namespace algortmische_oefening_pathfinder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> map = new List<string>
            {
                ////optie A
                "|A          |",
                "|--| |------|",
                "|           |",
                "|---|  |----|",
                "|           |",
                "|   |-------|",
                "|           |",
                "|           |",
                "|--| |------|",
                "|--| |------|",
                "|           |",
                "|-------| |-|",
                "|           |",
                "|---|     | B"
                 //optie B
                //"|A          |",
                //"|------| |--|",
                //"|           |",
                //"|---|-----| |",
                //"|           |",
                //"|   |--| |--|",
                //"|  |        |",
                //"|       |   |",
                //"|--| |------|",
                //"|--| |------|",
                //"|           |",
                //"|-| |-------|",
                //"|           |",
                //"|---|     | B"
            };
            // hier kijk ik in de lijst waar het begin punt is door te zoeken naar A
            var start = new Tile();
            start.Y = map.FindIndex(x => x.Contains("A"));
            start.X = map[start.Y].IndexOf("A");

            //hier kijk ik waar het einde is van het doolhof door te zoeken naar B
            var finish = new Tile();
            finish.Y = map.FindIndex(x => x.Contains("B"));
            finish.X = map[finish.Y].IndexOf("B");
            // hier boven maak ik dan ook meteen nieuwe tiles aan

            // hier start ik de afstand voor de start Tile
            start.SetDistance(finish.X, finish.Y); 

            var activeTiles = new List<Tile>();
            activeTiles.Add(start);
            //hier voeg ik dus de start Tile toe aan de de lijst van alle tiles
            var visitedTiles = new List<Tile>();

            while (activeTiles.Any())
            {
                //ik geef er nu een kost aan om te kijken wat de optimale tile is om naar toe te bewegen.
                var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

                if (checkTile.X == finish.X && checkTile.Y == finish.Y)
                {
                    //met de orderbye kijk ik naar de meest optimale weg om te nemen die het meest overeen komt met de optimale waarde
                    //dit is dus de meest efficiente route. 
                    var tile = checkTile;
                    Console.WriteLine("Dit zijn alle stappen die ik heb genomen");
                    while (true)
                    {
                        Console.WriteLine($"{tile.X} : {tile.Y}");
                        if (map[tile.Y][tile.X] == ' ')
                        {
                            // hier plaats ik het pad alleen een lege velden.
                            var newMapRow = map[tile.Y].ToCharArray();
                            newMapRow[tile.X] = '*';
                            map[tile.Y] = new string(newMapRow);
                        }
                        tile = tile.Parent;
                        if (tile == null)
                        {
                            Console.WriteLine("Zo ziet de kaart eruit :");
                            Console.WriteLine("Het is een lijst van strings");
                            map.ForEach(x => Console.WriteLine(x));
                            Console.WriteLine("Klaar!");
                            return;
                        }
                    }
                }
                // hier kijk ik naar de bezochte Tiles en haal de active Tile weg 
                visitedTiles.Add(checkTile);
                activeTiles.Remove(checkTile);
                // kijk aan het einde van de class program voor de GetWalkableTiles
                var walkableTiles = GetWalkableTiles(map, checkTile, finish);

                foreach (var walkableTile in walkableTiles)
                {
                    //Hier kijken we naar de Tiles waar we al zijn geweest en zorgen ik er voor dat we er niet nog een keer langs komen!
                    if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                        continue;

                    //ik kijk hier of er eventueel een betere Tile is dan waar je nu al op staat 
                    if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                    {
                        var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                        if (existingTile.CostDistance > checkTile.CostDistance)
                        {
                            activeTiles.Remove(existingTile);
                            activeTiles.Add(walkableTile);
                        }
                    }
                    else
                    {
                        //Ik moet de nieuwe Tile wel toevoegen aan de lijst natuurlijk. 
                        activeTiles.Add(walkableTile);
                    }
                }
            }
            // als ik geen weg kan vinden
            Console.WriteLine("Geen pad gevonden!");
        }

        private static List<Tile> GetWalkableTiles(List<string> map, Tile currentTile, Tile targetTile)
        {
            var possibleTiles = new List<Tile>()
            {

                new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile, Cost = currentTile.Cost + 1 },
                new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile, Cost = currentTile.Cost + 1},
                new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
                new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
            };

            possibleTiles.ForEach(tile => tile.SetDistance(targetTile.X, targetTile.Y));

            var maxX = map.First().Length - 1;
            var maxY = map.Count - 1;
            // hier kijk ik naar de mogelijke Tiles waar k naar toe kan gaan
            return possibleTiles
                    .Where(tile => tile.X >= 0 && tile.X <= maxX)
                    .Where(tile => tile.Y >= 0 && tile.Y <= maxY)
                    .Where(tile => map[tile.Y][tile.X] == ' ' || map[tile.Y][tile.X] == 'B')
                    .ToList();
        }
    }
}
