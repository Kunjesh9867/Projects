using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

//Here the laptop is dealer and the player is user, I have used this reference to make it simple
// BlackJack Reference Video = https://youtu.be/eyoh-Ku9TCI

namespace BlackJack;

public class BlackJack
{
    // This is the inroduction of the Casino where the return value is the money that the player have to bet 
    public static double introductionTOGame()
    {
        for (int i = 0; i < 40; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
        Console.WriteLine("Welcome to the BlackJack Game :)");
        Console.WriteLine("Welcome to Phoenix Casino!!!");
        for (int i = 0; i < 40; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();

        Console.Write("How much money would you like to bet today?  ");
        double d = Convert.ToDouble(Console.ReadLine());
        for (int i = 0; i < 40; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
        return d;
    }

    // This is the method that ask the player whether he/she have to continue or not 
    public static int askToContinue()
    {
        Console.Write("Would you like to play? (Yes[1] or No[0]: ");
        int integer =  Convert.ToInt16(Console.ReadLine());
        for (int j = 0; j < 40; j++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
        return integer;
    }

    //This is the main function in which the game start to initiate
    public static void startTheGame()
    {
        
        
        double moneyToBet = introductionTOGame(); // takes the integer value from the intro() method and store it in this variable
        Console.WriteLine("Welcome to the BlackJack Game :)"); // just an intro
        int[] betPrice = {1000,2000,5000,10000,15000,20000,30000,40000,50000}; // an array of bet money money, it changes as the game move forward
        object[] myNum = {"Ace",2,3,4,5,6,7,8,9,"Jack","Queen","King"}; // an array of card values
        int length = betPrice.Length; // to get the length of an array
        int i = 0; // to define the value of i which will further used in the loops 
        //just defining the value of some variable which will further taken into consideration
        int randonIndex = 0, randonIndex2 = 0, randonIndex3 = 0, randonIndex4 = 0, randonIndex5 = 0, randonIndex6 = 0;
        int variable = 0;



        
        while(askToContinue()==1)  // when user is ready to play this loop will execute
        { 
            
            if (i < length) // when the value of i is less than the length of betPrice() array
            {
                Random random = new Random(); // to get the random value for the card
                
                Console.WriteLine("The bet for this round is:"+betPrice[i]);
                Console.Write("Would You Like To Continue(y/n)? ");
                String userInput = Console.ReadLine();
                for (int j = 0; j < 40; j++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                if (userInput == "y")
                {
                    int randomIndex2 = random.Next(0, length); // to get the first random value of the card for laptop
                    Console.WriteLine("Laptop's first card is:"+myNum[randomIndex2]);
                    
                    int randomIndex = random.Next(0, length); // to get the first random value of the card for player
                    Console.WriteLine("Your first card is: " + myNum[randomIndex]);
                    //When the value is jack, queen or king the the value is changed to 10
                    if (myNum[randomIndex] == "Jack" || myNum[randomIndex] == "Queen" || myNum[randomIndex] == "King")
                    {
                        randomIndex = 10;
                    }else if (myNum[randomIndex] == "Ace")//When the value is ace then it will ask the player to choice the value either 1 or 11 according to player wish

                    {
                        Console.WriteLine("You can convert your ace in 1 or 11, as you wish");
                        Console.Write("How do you want to convert Your Ace(1 or 11): ");
                        String input = Console.ReadLine();
                        myNum[randomIndex] = int.Parse(input);
                    }
                    
                    var randomIndex3 = random.Next(0, length); // to get the  random value of the card for laptop
                    Console.WriteLine("Your second card is: "+myNum[randomIndex3]);
                    for (int j = 0; j < 40; j++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                    if (myNum[randomIndex3] == "Jack" || myNum[randomIndex3] == "Queen" || myNum[randomIndex3] == "King")
                    {
                        randomIndex = 10;
                    }else if (myNum[randomIndex3] == "Ace")
                    {
                        Console.WriteLine("You can convert your Ace in 1 or 11, as you wish");
                        Console.WriteLine("How do you want to convert Your Ace(1 or 11): ");
                        String input = Console.ReadLine();
                        myNum[randomIndex3] = int.Parse(input);
                    }
                    


                    if (randomIndex + randomIndex3 == 21) // if the value = 21, then the player will ultimately won 
                    {
                        Console.WriteLine("Hurray, You Won 1.5 times i.e"+betPrice[i]*1.5);
                        moneyToBet += betPrice[i] * 1.5;
                        break; // to break the loop
                    }
                    bool newCard = true;
                    int randomIndex4 = 0;
                    int total = Convert.ToInt16(myNum[randomIndex])+Convert.ToInt16(myNum[randomIndex3]); //to get the total value of player card
                    //Console.WriteLine(total);
                    while (newCard)
                    {
                        //To ask the player if he/she want another card or not
                        Console.Write("Do You want another card from the deck? Presss 1=Hit or 2=Stay: ");
                        String anotherCard = Console.ReadLine();
                        if (int.Parse(anotherCard) == 1) //when the player wants the card
                        {
                            randomIndex4 = random.Next(0, length); // random card value
                            Console.WriteLine("Your card is: " + myNum[randomIndex4]);
                            if (myNum[randomIndex3] == "Jack" || myNum[randomIndex3] == "Queen" || myNum[randomIndex3] == "King")
                            {
                                myNum[randomIndex] = 10;
                            }else if (myNum[randomIndex3] == "Ace")
                            {
                                Console.WriteLine("You can convert your Ace in 1 or 11, as you wish");
                                Console.Write("How do you want to convert Your Ace(1 or 11): ");
                                String input = Console.ReadLine();
                                myNum[randomIndex3] = int.Parse(input);
                            }

                            total += Convert.ToInt16(myNum[randomIndex3]);
                            // if the total is greater than 21 for the player then the player is busted and he/she losses the money
                            if (total > 21)
                            {
                                for (int j = 0; j < 40; j++)
                                {
                                    Console.Write("-");
                                }
                                Console.WriteLine();
                                Console.WriteLine("You are Busted!!!");
                                moneyToBet -= betPrice[i];
                                break;
                            }
                            
                            
                        }else if (int.Parse(anotherCard) == 2) // When the player don't want the card
                        {
                            for (int j = 0; j < 40; j++)
                            {
                                Console.Write("-");
                            }
                            Console.WriteLine();
                            var randomIndex5 = random.Next(0, length);  // to get the random card
                            Console.WriteLine("Laptop's second card is: "+myNum[randomIndex5]); 
                            
                            if (myNum[randomIndex5] == "Ace")
                            {
                                if (randomIndex + 1 > 21)
                                {
                                    myNum[randomIndex5] = 11;
                                }
                                else
                                {
                                    myNum[randomIndex5] = 1;
                                }
                            }
                            else if (myNum[randomIndex5] == "Jack" || myNum[randomIndex5] == "Queen" ||
                                     myNum[randomIndex5] == "King")
                            {
                                myNum[randomIndex5] = 10;
                            }


                            int randomIndex6 = 0;
                            
                            // If the total card value for the laptop is >21, then the laptop losses and the player get 2x
                            if (Convert.ToInt16(myNum[randomIndex2]) + Convert.ToInt16(myNum[randomIndex5]) > 21)
                            {
                                for (int j = 0; j < 40; j++)
                                {
                                    Console.Write("-");
                                }
                                Console.WriteLine();
                                Console.WriteLine("Dealer is Busted!!!");
                                Console.WriteLine("You won 2 times i.e: "+betPrice[i]*2);
                                moneyToBet += betPrice[i] * 2 ;
                                
                            }
                            // If the total card value for the laptop is <16, then the player has to take another card from the deck 

                            else if (Convert.ToInt16(myNum[randomIndex2]) + Convert.ToInt16(myNum[randomIndex5]) < 16)
                            {
                                for (int j = 0; j < 40; j++)
                                {
                                    Console.Write("-");
                                }
                                Console.WriteLine();
                                Console.Write("You have to take another card: ");
                                //Thread.Sleep(3000);
                                randomIndex6 = random.Next(0, length);
                                Console.WriteLine("Your card is: "+myNum[randomIndex6]);
                                if (myNum[randomIndex6] == "Jack" || myNum[randomIndex6] == "Queen" || myNum[randomIndex6] == "King")
                                {
                                    myNum[randomIndex] = 10;
                                }else if (myNum[randomIndex6] == "Ace")
                                {
                                    Console.WriteLine("You can convert your ace in 1 or 11, as you wish");
                                    Console.WriteLine("How do you want to convert Your Ace(1 or 11): ");
                                    String input = Console.ReadLine();
                                    myNum[randomIndex] = int.Parse(input);
                                }

                                total += Convert.ToInt16(myNum[randomIndex6]); 
                                //if total of player >21, player losses 
                                if (total > 21)
                                {
                                    for (int j = 0; j < 40; j++)
                                    {
                                        Console.Write("-");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("You are Busted!");
                                    moneyToBet -= betPrice[i];
                                    
                                }
                                //if the player's total is greater than laptop's total then the player 2x
                                else if ((total > Convert.ToInt16(myNum[randomIndex2]) +
                                              Convert.ToInt16(myNum[randomIndex5])))
                                {
                                    for (int j = 0; j < 40; j++)
                                    {
                                        Console.Write("-");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("Hurray you won 2 times:"+betPrice[i]*2);
                                    moneyToBet += betPrice[i] * 2;
                                }
                                else if(total<Convert.ToInt16(myNum[randomIndex2]) +
                                        Convert.ToInt16(myNum[randomIndex5]))
                                {
                                    Console.WriteLine("You Lose");
                                    
                                }

                            }
                            else if (Convert.ToInt16(myNum[randomIndex2]) + Convert.ToInt16(myNum[randomIndex5]) > 16)
                            {
                                Console.WriteLine("Stay with your hand!!!");
                                //if the player's total is greater than 16, then the player won 2x

                                if (Convert.ToInt16(myNum[randomIndex]) + Convert.ToInt16(myNum[randomIndex3]) +
                                    Convert.ToInt16(myNum[randomIndex4]) + Convert.ToInt16(myNum[randomIndex6]) > 16)
                                {
                                    for (int j = 0; j < 40; j++)
                                    {
                                        Console.Write("-");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("You won 2 times of your bet: "+ betPrice[i]*2);
                                    moneyToBet += betPrice[i] * 2;
                                }
                                else
                                {
                                    for (int j = 0; j < 40; j++)
                                    {
                                        Console.Write("-");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("You lose!");
                                    moneyToBet -= betPrice[i];
                                }
                            }
                            break;
                            
                        }
                        //Just to check whether the loop works or not
                        else
                        {
                            for (int j = 0; j < 40; j++)
                            {
                                Console.Write("-");
                            }
                            Console.WriteLine();
                            Console.WriteLine("Something went wrong.");
                            
                        }

                    }

                }
                else
                {
                    break;
                }

                i++;
            }
        }

        if (askToContinue() == 0)
        {
            for (int j = 0; j < 40; j++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.WriteLine("Total Win: "+moneyToBet);
        }
        //Console.WriteLine("This bet is of $");
        //Console.WriteLine("Enter how many :");
    }

    public static void Main(string[] args)
    {
        
        startTheGame();
        Console.WriteLine();
    }
}