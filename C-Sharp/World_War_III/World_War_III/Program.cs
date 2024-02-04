/*
 Created By = Kunjesh Ramani
 Date = March 7, 2023
*/
    

using System.Xml;

namespace World_War_III;

class Program
{

    public static void designLoop()
    {
        /*
         FOR loop is used for designing purpose
         This is optional, I have used it to make it user friendly
         There are several of it's kind in this game 
        */
        for (int i = 0; i < 70; i++)
        {
            Console.Write('-');
            
        }
        Console.WriteLine();
        
    }
    
    static void Main(string[] args)
    {
        
        Game game = new Game(); // A reference to Game.cs File
        
        game.Introduction(); // Calling Introduction method from Game.cs
        
        designLoop();
        
        
        game.armor();
        
        designLoop();

        game.weapon();
        
        game.gamePlay();
        
        game.Introduction("Thank You for Playing!!!");
        
    }
}