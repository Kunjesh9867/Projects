/*
 Created By = Kunjesh Ramani
 Date = March 7, 2023
*/

using System.Xml;

namespace World_War_III;

class Game
{
    Random random = new Random(); // Creating a reference of Random methods
    
    int playerHealth = 0;
    /*
     Player(User's) Health is set to 0 initially
     Health will be defined according to the user's Armor choice
    */
    
    int enemyHealth = 1000; // Enemy health is set to 1000
    
    int playerWeapon = 0;
    /*
     Again,
     Player(User's) Weapon is set to 0 initially
     It's Health Kill will be defined according to the user's Weapon choice
    */
   
    int enemyWeapon = 3;  // AK-47
    // By default, Enemy Weapon is set to AK-47
    
    int minimumHealthKill = 0;
    int maximumHealthKill = 0;
    // Minimum and Maximum will be defined according to the user's weapon choice
    
    int bomb = 100;  
    /*
     ONLY available for user
     This bomb will be given to user after a particular interval
     100 is the Health Kill of bomb
     Bomb will automatically be initiated
     It's an extra feature for user 
     */

    public String user = ""; // It will later filled with user name
    
    
    public int[] HealthChoiceArray = { 1300, 1500, 1000, 2000, 1700 };
    
    public int playerHealthChoice = 0;
    
    public void Introduction(String parameter)
    {
        Console.WriteLine(parameter);
        Console.WriteLine("Have a Nice day Ahead");
        for (int i = 0; i < 70; i++)
        {
            Console.Write('-');
            
        }
        Console.WriteLine();
    }
    public void Introduction()
    {
        int doWhileStart = 0;
        do
        {
            for (int i = 0; i < 70; i++)
            {
                Console.Write('-');
            
            }
            Console.WriteLine();
            Console.WriteLine("\t\tWelcome To WORLD WAR III");
            Console.WriteLine("This game is played between the USER(You) and the ENEMY(Computer)");
            Console.WriteLine("Whosoever win the game will get a Cookie");
            Console.WriteLine("GOOD LUCK!!!");
            for (int i = 0; i < 70; i++)
            {
                Console.Write('-');
            
            }
            Console.WriteLine();
        
        
            Console.Write("Please Enter your name here: ");
            user = Console.ReadLine(); // Get the User's name
            Console.WriteLine();
            Console.WriteLine("Let's begin the game "+user+"!\n");
            
        } while (doWhileStart==1);
        
        
    }


    public void armor()
    {
        Console.WriteLine("Select an ARMOR:\n\nEach armor has different health");
        Console.WriteLine("NOTE: You cannot change the armor in-between the game\nChoose Wisely!");
        Console.WriteLine(); // To add a newline
        
        Console.WriteLine("There are 5 Armors Available");
        Console.Write("(1)European Plate Armor\n(2)Level IV Armor\n(3)SAPI Armor\n(4)Milanese Plate Armor\n(5)Medieval Jousting Armor\n\n");

        String[] nameOfArmor = { "European Plate Armor",
            "Level IV Armor",
            "API Armor",
            "Milanese Plate Armor",
            "Medieval Jousting Armor"};
        // An array of armor

        Console.Write("Enter your choice here: "); // To take user's choice
        playerHealthChoice = Convert.ToInt16(Console.ReadLine()); // Convert string into integer
        
        Console.WriteLine();
        Console.WriteLine("Your armor is: "+nameOfArmor[playerHealthChoice-1]); // To display armor's name to useer
        
        /*
         Health of armors
         Each and every armor has different health
         
         
         European Plate Armor = 1300
         Level IV Armor = 1500
         SAPI Armor = 1000
         Milanese Plate Armor = 2000 (Strongest Armor)
         Medieval Jousting Armor = 1700
         */

        playerHealth = HealthChoiceArray[playerHealthChoice - 1];
        // User's health according to the armor 
    }

    public void weapon()
    {
        // Weapons
        Console.WriteLine("Select a WEAPON\n\nEach weapon has different range of health kill");
        Console.WriteLine("NOTE: You can change your weapon in-between the game but it available after a series of rounds\n");
        Console.WriteLine("There are 5 weapons available");
        Console.Write("(1)Rifle\n(2)Sword\n(3)Spear\n(4)AK-47\n(5)Flamethrower\n\n");
        
        Console.Write("Enter your choice here: "); // To choice weapon for users
        playerWeapon = Convert.ToInt16(Console.ReadLine()); // Convert String into Integer

        String[] weaponChoiceArray = {"Rifle","Sword", "Spear","AK-47","Flamethrower"};

        Console.WriteLine("Your weapon is: "+ weaponChoiceArray[playerWeapon-1]); // To display weapon name

        try
        {
            switch (playerWeapon)
        {
            // Weapon Maximum and Minimum Kill
            // Rifle
            case 1:
                minimumHealthKill = 300;
                maximumHealthKill = 400;
                break;
            // Sword
            case 2:
                minimumHealthKill = 200;
                maximumHealthKill = 350;
                break;
            // Spear
            case 3:
                minimumHealthKill = 150;
                maximumHealthKill = 300;
                break;
            // AK-47
            case 4:
                minimumHealthKill = 350;
                maximumHealthKill = 500;
                break;
            // Flamethrower
            case 5:
                minimumHealthKill = 350;
                maximumHealthKill = 400;
                break;
            // If any error occurs
            default:
                minimumHealthKill = 0;
                maximumHealthKill = 10000;
                break;
        }

        }
        catch (Exception e)
        {
            Console.WriteLine("Error in choosing Minimum and Maximum value of Health Kill");
            Console.WriteLine(e);
            throw;
        }
        
    }
    
    int round = 1; 
    // This variable is assigned for showing the NUMBER OF ROUNDS performed 
    int playerOrEnemyChoice = 1; // To interchange "if loop" in while Loop
    int changeWeaponCount = 0; // TO give option to user for changing weapon
    int whileLoopStart = 1;
    
    public void gamePlay()
    {
        try
        {
            while (whileLoopStart==1) // infinite loop
            {
                for (int i = 0; i < 70; i++)
                {
                    Console.Write('-');
            
                }
                Console.WriteLine();
                Console.WriteLine("ROUND: "+round);
                for (int i = 0; i < 70; i++)
                {
                    Console.Write('-');
            
                }
                Console.WriteLine();
                // Player's Turn
                if (playerOrEnemyChoice == 1) 
                {
                    Console.WriteLine("It's "+user+" Choice");
                    Console.Write("(1)Attack\n(2)Heal: ");
                    int playerBattlefieldChoice = Convert.ToInt16(Console.ReadLine());
                
                    // (1) Attack
                    if (playerBattlefieldChoice == 1)
                    {
                        enemyHealth -= random.Next(minimumHealthKill, maximumHealthKill);
                        // Decrease enemy health my random number
                        // Console.WriteLine(enemyHealth);  For Checking Purpose
                    }
                
                    // (2) Heal 
                    else if (playerBattlefieldChoice == 2)
                    {
                        /*
                         If Health is less than maximum health => Increase Health
                         If Health is equals or more than maximum health => set it to maximum health
                         */
                    
                        if (playerHealth < HealthChoiceArray[playerHealthChoice - 1] ) 
                        {
                            playerHealth += 100;
                            // Console.WriteLine(playerHealth);
                        }

                        if (playerHealth > HealthChoiceArray[playerHealthChoice - 1])
                        {
                            playerHealth = HealthChoiceArray[playerHealthChoice - 1];
                            Console.WriteLine(playerHealth);
                        }
                    }


                    // When enemyHealth is 0 or Negative(-), USER WINS :)
                    if (enemyHealth == 0 || enemyHealth < 0)
                    {
                        for (int i = 0; i < 70; i++)
                        {
                            Console.Write('-');
            
                        }
                        Console.WriteLine();
                        Console.WriteLine("Game Over!");
                        Console.WriteLine("You Won!");
                        Console.WriteLine("Here is your Cookie");
                        for (int i = 0; i < 70; i++)
                        {
                            Console.Write('-');
            
                        }
                        Console.WriteLine();
                        whileLoopStart = 0;
                        break;
                    }

                    playerOrEnemyChoice = 2; // To change TURN => USER to ENEMY
                    changeWeaponCount++; // TO increase the count by 1
                
                    if (changeWeaponCount == 5)
                    {
                        changeWeaponCount = 0;
                        changeWeapon();
                    }
                }

                //Enemy's Turn
                if (playerOrEnemyChoice == 2)
                {
                
                    Console.WriteLine();
                    Console.WriteLine("It's Enemy Choice");
                    int randomChoice = random.Next(1, 3);
                    /*
                     To Choice random from Attack or Heal
                     (1) => Attack
                     (2) => Heal
                     */

                    // Attack
                    if (randomChoice == 1)
                    {
                        Console.WriteLine("Enemy Choose to ATTACK");
                        playerHealth -= random.Next(250,400); // To decrease player's Health
                        // Console.WriteLine(playerHealth);  For Checking Purpose
                    }
                    // Heal
                    else if (randomChoice == 2)
                    {
                        Console.WriteLine("Enemy Choose to HEAL");

                        if (enemyHealth < 1000)
                        {
                            enemyHealth += 100;
                            // Console.WriteLine(enemyHealth);
                        }

                        if (enemyHealth > 1000)
                        {
                            enemyHealth = 1000;
                            Console.WriteLine(enemyHealth);
                        }
                    }
                
                    // If player's health is 0 or negative(-) then Enemy(Computer) Wins :(
                    if (playerHealth == 0 || playerHealth < 0 )
                    {
                        for (int i = 0; i < 70; i++)
                        {
                            Console.Write('-');
            
                        }
                        Console.WriteLine();
                        Console.WriteLine("Game Over");
                        Console.WriteLine("You Lose!");
                        for (int i = 0; i < 70; i++)
                        {
                            Console.Write('-');
            
                        }
                        Console.WriteLine();
                        // Console.WriteLine("Here is your Cookie");
                        whileLoopStart = 0;
                        break;
                    }
                    playerOrEnemyChoice = 1; // To change TURN => ENEMY to USER
                }

                round++;
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    
    public void changeWeapon()
    {
        for (int i = 0; i < 70; i++)
        {
            Console.Write('-');
            
        }

        enemyHealth -= 100;  //Bomb
        Console.WriteLine();
        Console.Write("Would you like to change the weapon?\n(1)YES\n(2)NO: ");
        int answer = Convert.ToInt16(Console.ReadLine());
        if (answer == 1)
        {
            weapon();
        }
        else
        {
            Console.WriteLine("Error in choosing value");
            Console.WriteLine("EXCEPTION");
        }
    }
}