using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._The_Pianist
{
    class Piece
    {
        public Piece(string composerName, string key)
        {
            this.Composer = composerName;
            this.Key = key;
        }

        public string Composer { get; set; }

        public string Key { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] currPiece = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                pieces.Add(currPiece[0], new Piece(currPiece[1], currPiece[2]));
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] pieceInfo = command
                    .Split('|');

                string action = pieceInfo[0];
                string currPieceName = pieceInfo[1];

                if (action == "Add")
                {
                    if (pieces.ContainsKey(currPieceName))
                    {
                        Console.WriteLine($"{currPieceName} is already in the collection!");
                    }
                    else
                    {
                        string composer = pieceInfo[2];
                        string key = pieceInfo[3];

                        pieces.Add(currPieceName, new Piece(composer, key));
                        Console.WriteLine($"{currPieceName} by {composer} in {key} added to the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    if (!pieces.ContainsKey(currPieceName))
                    {
                        Console.WriteLine($"Invalid operation! {currPieceName} does not exist in the collection.");
                    }
                    else
                    {
                        pieces.Remove(currPieceName);
                        Console.WriteLine($"Successfully removed {currPieceName}!");
                    }
                }
                else if (action == "ChangeKey")
                {
                    if (!pieces.ContainsKey(currPieceName))
                    {
                        Console.WriteLine($"Invalid operation! {currPieceName} does not exist in the collection.");
                    }

                    else
                    {
                        string newKey = pieceInfo[2];

                        pieces[currPieceName].Key = newKey;

                        Console.WriteLine($"Changed the key of {currPieceName} to {newKey}!");
                    }
                }
            }

            foreach (KeyValuePair<string, Piece> kvp in pieces)
            {
                Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value.Composer}, Key: {kvp.Value.Key}");
            }
        }
    }
}
