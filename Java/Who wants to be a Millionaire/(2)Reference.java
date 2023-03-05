import java.lang.Math; //importing Math class in Java
import java.util.Scanner; // Import the Scanner class

public class Reference {

    public Reference() { 
    }

    public void game_info() {  // game_info means Game Information 
        Integer number_of_questions = 15;  // Here I have used Wrapper Class = Integer
        System.out.println("There will be total of "+number_of_questions+" Question !!!");

        System.out.printf(  // printf is used for better look and feel
                "1  = $100%n2  = $200%n3  = $300%n4  = $500%n5  = $1,000%n6  = $2,000%n7  = $4,000%n8  = $8,000%n9  = $16,000%n10 = $32,000%n11 = $64,000%n12 = $125,000%n13 = $250,000%n14 = $500,000%n15 = $1,00,0000");

        // Below, 2 println statements are used to add extra spaces for look and feel
        System.out.println();
        System.out.println();
        System.out.println();

        System.out.println("You will have 4 LifeLines: ");
        System.out.printf("(1) Audience Poll%n(2) X2%n(3) 50:50%n(4) Call an Expert");
    }

    // void function is used to start the game
    public void game_start() { //game_start = Start the game
        Scanner sc2 = new Scanner(System.in); // Scanner object created

        // Different price value is stored in single-D array
        int value_of_price[] = {0, 100, 200, 300, 500, 1000, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 250000,
                500000, 1000000 };
        Integer i = 1;  // Wrapper class is used
        String variable = "A"; // This string variable is crucial as it will start,stop the "if" loop inside while loop which is further used.

        while (true) {

            if (variable.equals("A") || i.equals(15)) { // To check whether the variable is equals to A or i = 15
                // To print the appropriate message in the terminal
                System.out.println();
                System.out.println();
                for(int i3=0; i3<100;i3++){
                    System.out.print("-");
                }
                System.out.println();
                System.out.println("Question " + i + " for $"+value_of_price[i]+" is: ");
                System.out.println();

                // If the price value is less than $ 1000 then below if loop will be executed
                if (value_of_price[i] <= 1000) {
                    
                    String answer = array("A"); // To fetch the value of answer from array("A") and store it in the variable
                    // There are 3 function with name ARRAY with different parameters. I have used the concept of method overloading here
                    // array("A") = String 
                    // array(1) = integer
                    // array(3.2f) = float
                    // Concept of Method Overloading is used


                    // To whether use a lifeline or not
                    System.out.print("Do you wanna use a Lifeline (y/n): ");
                    String x = sc2.next();  // To get the input from the user
                    System.out.println();

                    // If the user want to use a lifeline then the flow of execution will be transferred to Lifeline function/Method otherwise it will move to validator function/Method
                    if (x.equals("y")) {
                        variable = Lifeline(answer);

                    } else {
                        variable =validator(answer);
                    }
                } 


                // If the price value is less than $ 32000 and more than 1000 then below if loop will be executed 
                else if ((value_of_price[i] > 1000) && (value_of_price[i] <= 32000)) {
                    String answer = array(1); // To fetch the value of answer from array(1) and store it in the variable

                    // To whether use a lifeline or not
                    System.out.print("Do you wanna use a Lifeline (y/n):  ");
                    String x = sc2.next();

                     // If the user want to use a lifeline then the flow of execution will be transferred to Lifeline function/Method otherwise it will move to validator function/Method
                    if (x.equals("y")) {
                        variable =Lifeline(answer);

                    } else {
                        variable =validator(answer);

                    }
                } 
                // If the price value is less than $ 1000000 and more than 32000 then below if loop will be executed
                else if ((value_of_price[i] > 32000) && (value_of_price[i] <= 1000000)) {
                    String answer = array(3.2f); // To fetch the value of answer from array(3.2f) and store it in the variable

                    // To whether use a lifeline or not
                    System.out.println("Do you wanna use a Lifeline (y/n): ");
                    String x = sc2.next();

                    // If the user want to use a lifeline then the flow of execution will be transferred to Lifeline function/Method otherwise it will move to validator function/Method
                    if (x.equals("y")) {
                        variable =Lifeline(answer);

                    } else {
                        variable =validator(answer);
                    }

                } 
                // To check whether the values are successfully retrieving from the array or not
                else {
                    System.out.println("Price Money Out of Range");
                }
            }
            // Below else loop is used to print the message and price amount in the terminal when the game is
            else{
                // System.out.println(value_of_price[i-2]);
                System.out.println();
                for(int i2=0; i2<50;i2++){
                    System.out.print("-");
                }
                System.out.println();
                System.out.println("You Won the amount of "+ value_of_price[i-2]);
                System.out.println();
                for(int i3=0; i3<50;i3++){
                    System.out.print("-");
                }
                break;
            }

            i++; // To increment the value of i , so that the next time the loop continue it took the next values available in the array
        }

    }

    // This is the validator function which is executed when the used do not want to use a lifeline
    public static String validator(String answer) { // It returns the String value
        String return_str="A"; //Assigning a variable
        Scanner sc3 = new Scanner(System.in); // creating scanner object differently so that the code can be easily understood
        System.out.print("Enter your Answer [A,B,C,D]: ");
        String answer_validate = sc3.next(); // To get the input from the user 

        if (answer_validate.equals(answer)) {
            System.out.println("Hurray Your Answer is Correct");
        } else {
            System.out.println("OOPS Your Answer is Incorrect");
            return_str="B"; // When the answer is incorrect the value of variable changes, which further change the value of if loop (used under while loop) leads to stop the Loop

        }
        return return_str; // The value is returned

    }

    

    // This is the Lifeline function which is executed when the user want to use a lifeline
    public static String Lifeline(String ans) {
        String return_str = "A"; // Same as validator function
        Scanner sc1 = new Scanner(System.in); 

        // For message
        System.out.printf("(A) Audience Poll%n(B) X2%n(C) 50:50%n(D) Call an Expert");
        System.out.println();
        System.out.println();
        System.out.print("Which Lifeline Do you wanna use? ");
        String x2 = sc1.next();

        // When user enters A = "Audience Pool" then this loop will be executed
        if (x2.equals("A")) {

            // To print the answer and appropriate message
            System.out.println("You are using Audience Pool !!!");
            System.out.println("Correct answer is: " + ans);

            // To ask for answer
            System.out.print("Enter your Answer [A,B,C,D]: ");
            String answer_validate = sc1.next();
            if (answer_validate.equals(ans)) {
                System.out.println("Hurray, Your answer is Correct");
            } else {
                System.out.println("OOPS, Your answer is Incorrect");
                return_str="B"; // Same as validator function

            }

        } 
        // When user enters B = "X2" then this loop will be executed
        else if (x2.equals("B")) {
            System.out.println("You are using X2 Lifeline !!!");

            // To give double try to the user using "for" loop
            for (int i2 = 1; i2 < 3; i2++) {
                System.out.print("Enter your " + i2 + " Answer [A,B,C,D]: ");
                String answer1 = sc1.next();
                if (answer1.equals(ans)) {
                    System.out.println("Hurray, Your Answer is Correct");
                    break; //to break the loop if answer is correct
                }
            }
            
        } 
        // When user enters C = " 50:50 " then this loop will be executed
        else if (x2.equals("C")) {
            System.out.println("You are using 50:50  Lifeline !!!");

            
            String arr[] = { "A", "B", "C", "D" };
            double theRandomNumber = Math.floor(Math.random() * 4) + 1; // To get a random value from the above Single-D array
            int interger_value = (int) theRandomNumber; // To store the index in integer form
            String queString = arr[interger_value]; // To store the value

            // To display 2 options, out of which 1 will be correct to the user
            System.out.println("Now, You are left with 2 options, Which are " + ans + " and " + queString);
            System.out.print("Enter your Answer [A,B,C,D]: ");
            String answer = sc1.next();
            if (answer.equals(ans)) {
                System.out.println("Hurray, Your Answer is Correct");
            } else {
                System.out.println("OOPS, Your Answer is Incorrect");
                return_str="B";
            }
        } 
        // When user enters D = "Ask the Expert" then this loop will be executed
        // "Ask the expert" is same as "Audience Poll". Logic is also same
        else if (x2.equals("D")) { 
            String Str= "new1"; // To create a string
            // here, I used the concept of do while loop in such a form that the loop will be executed once only.
            do{
            System.out.println("You are using ASK THE EXPERT Lifeline !!!");
            System.out.println("Correct answer is: " + ans);
            System.out.print("Enter your Answer [A,B,C,D]: ");
            String answer_validate = sc1.next();
            if (answer_validate.equals(ans)) {
                System.out.println("Hurray, Your Answer is Correct");
            } else {
                System.out.println("OOPS, Your Answer is Incorrect");
                return_str="B";

            }
        }while(Str.equals("new"));  // change the equals so that the loop will be executed once.

        }
        return return_str;

    }

    public static String array(String x) {  // Method Overloading
        // I have store 15 differenct question of easy level in 2-D array below with answers
        String[][] array1 = { { "In the UK, the abbreviation NHS stands for National what Service?", "B" },
                { "Which sport is also known as football?", "A" },
                { "What city contains the Eiffel Tower?", "D" },
                { "How many continents are there?", "C" },
                { "Which of the following is not a type of pasta?", "C" },
                { "What gas makes voices sound higher when inhaled?", "C" },
                { "What American holiday falls on July 4?", "B" },
                { "Which candy bar shares its name with a galaxy?", "C" },
                { "What is the capital of England?", "D" },
                { "What is someone who collects coins called?" },
                { "Which princess lost a glass slipper?", "A" },
                { "Which American car company makes the Mustang, the F-150 and Escape?", "B" },
                { "How many days are in a leap year?", "D" },
                { "Who is the current host of 'The Tonight Show?'", "A" } };

        String[][] array_answer = { { "A = Humanity || B = Health || C = Honour || D = Household" },
                { "A = Soccer || B = Basketball || C = Baseball || D = Cricket" },
                { "A = Sydney || B = Las Angeles || C = New York City || D = Paris" },
                { "A = 1 || B = 3 || C = 7 || D = 20" },
                { "A = Rigatoni || B = Mostaccioli || C = Patella || D = Vermicelli" },
                { "A = Nitrogen || B = Oxygen || C = Helium || D = Boron" },
                { "A = Thanksgiving Day || B = Independence Day || C = Christmas Day || D = New Year's Day" },
                { "A = Snickers || B = 3 Musketeers || C = Milky Way || D = Almond Joy" },
                { "A = Washington D.C. || B = Rome || C = Moscow || D = London" },
                { "A = Professor || B = Chef || C = Psychiatrist || D = Numismatist" },
                { "A = Cinderella || B = Snow White || C = Mulan || D = Belle" },
                { "A = Toyota || B = Ford || C = BMW || D = Ferrari" },
                { "A = 364 || B = 365 || C = 400 || D = 366" },
                { "A = Jimmy Fallon || B = Oprah Winfrey || C = Anne Curry  || D = Bob Barker" }
             };

        // Use of Random function from the math library to get a random question from the above 15 question with answer
        double theRandomNumber = Math.floor(Math.random() * 15) + 1;
        int convert_into_integer = (int) theRandomNumber;

        String queString = array1[convert_into_integer][0];
        System.out.println(queString); // To print the question

        System.out.println(array_answer[convert_into_integer][0]); //To print the options
        System.out.println();
        System.out.println();

        String correct_answer = array1[convert_into_integer][1]; // To store the answer in the variable
        return correct_answer; // to return the correct answer

    }

    public static String array(Integer x) { // Method Overloading
        // I have store 15 differenct question of moderate level in 2-D array below with answers
        String[][] array1 = { { "How many rings are on the Olympic flag?", "C" },
                { "How did Spider-Man get his powers?", "A" },
                { " In darts, what's the most points you can score with a single throw?", "C" },
                { "Which of these animals does NOT appear in the Chinese zodiac?", "A" },
                { "What are the main colors on the flag of Spain?", "D" },
                { "What is the name of this symbol: ¶", "D" },
                { " What is Times New Roman?", "A" },
                { "Which of these islands is furthest south?", "C" },
                { "Which of these colors is closest to chartreuse?  ", "D" },
                { "How long does it take light to travel from the Sun to the Earth?", "B" },

                { " When did Mahatma Gandhi die?", "A" },
                { " Has Toronto ever hosted the Olympics?", "B" },
                { "Which of these noble ranks is highest?", "B" },
                { "Who is Paul Simon?", "D" },
                { "Which of the following is a synonym of 'benighted'?", "B" } };

        String[][] array_answer = { { "A = None || B = 4 || C = 5   || D = 7" },
                { "A = Bitten by radioactive spider || B = Born with them || C = Military experiment gone wrong || D = Woke up with them after a strange dream" },
                { "A = 20|| B = 50 || C = 60 || D = 100" },
                { "A = Bear || B = Dragon || C = Rabbit || D = Dog" },
                { "A = Black and Yellow || B = Blue and White || C = Green and White || D = Red and Yellow" },
                { "A = Biltong || B = Fermata || C = Interrobang || D = Pilcrow" },
                { "A = A font || B = A mathematical formula || C = A newspaper || D = A religious movement" },
                { "A = Cuba || B = Jamaica || C = Trinidad || D = Andaman and Nicobar" },
                { "A = Gray || B = Pink || C = Orange || D = Yellow green" },
                { "A = Instataneous || B = 8 minutes || C = 11 days || D = 3 months" },
                { "A = 1948 || B = 1961 || C = 1975 || D = 1997" },
                { "A = Yes || B = No || C = Maybe" },
                { "A = Baron || B = Duke || C = Earl || D = Marquis" },
                { "A = Lawyer || B = Playwriter || C = Serial Killer || D = singer-songwriter" },
                { "A = Ignorant || B = Noble || C = Old || D = Smitten" } };


         // Use of Random function from the math library to get a random question from the above 15 question with answer
        double theRandomNumber = Math.floor(Math.random() * 15) + 1;
        int convert_into_integer = (int) theRandomNumber;

        String queString = array1[convert_into_integer][0];
        System.out.println(queString); // To print the question

        System.out.println(array_answer[convert_into_integer][0]); //To print the options
        System.out.println();
        System.out.println();

        String correct_answer = array1[convert_into_integer][1]; // To store the answer in the variable
        return correct_answer; // to return the correct answer

    }

    public static String array(Float x) { // Method Overloading
        // I have store 15 differenct question of hard level in 2-D array below with answers
        String[][] array1 = { { "In which year America was declared independent from England?", "C" },
                { "Which President has been given credit for abolishing slavery in the USA?", "A" },
                { "Which European is given the credit of reaching North America first?", "C" },
                { "When is International Women's Day observed?", "A" },
                { "Who is the youngest President of the United States of America?", "B" },
                { "In which year was Joan of Arc burnt at stake?", "D" },
                { "Who was the renowned civil rights leader who fought through the means of non-violence?", "A" },
                { "What was the name of the first college founded in the United States?", "C" },
                { "When was the LEGO brick invented?", "D" },
                { "What is dermatophobia the fear of?", "B" },
                { "Who designed the Eiffel Tower?", "A" },
                { "When was the first computer invented?", "B" },
                { "What is the largest moon of Saturn called?", "B" },
                { "'Moonshine' was a slang term for which type of beverage?", "D" },
                { "Tom Cruise is an outspoken member of which religion?", "B" } };

        String[][] array_answer = { { "A = 1774 || B = 1775 || C = 1776   || D = 1777" },
                { "A = Abraham Lincoln || B = John Kennedy || C =  Barack Obama || D = Donald Trump" },
                { "A = Leonardo Da Vinci || B = Stephen Hawkings || C = Christopher Columbus || D = Galileo Galilei" },
                { "A = March 8 || B = March 10 || C = April 8 || D = April 10" },
                { "A = Abraham Lincoln || B = John Kennedy || C =  Barack Obama || D = Donald Trump" },
                { "A = 1429 || B = 1429|| C = 1430 || D = 1431" },
                { "A = Martin Luther King, Jr || B = Abraham Lincoln || C = John Keneddy || D = Sir George Brown" },
                { "A = Oxford University || B = Stanford University || C = Harvard University || D = MIT" },
                { "A = 1955 || B = 1956 || C = 1957 || D = 1958" },
                { "A = Height || B = Skin disease || C = Failure || D = Water" },
                { "A = Gustave Eiffel || B = Stan Eiffel || C = David Eiffel || D = Zelensky Eiffel" },
                { "A = 1945 || B = 1946 || C = 1947 || D = 1948" },
                { "A = Moon || B = Titan || C = Kernel || D = STV-8" },
                { "A = Wiskey || B = Scotch || C = Kingfisher || D = Alcohol" },
                { "A = Cosmology || B = Scientology || C = Philosophy || D = Pharmacology" } };

        double theRandomNumber = Math.floor(Math.random() * 15) + 1;
        int convert_into_integer = (int) theRandomNumber;

        String queString = array1[convert_into_integer][0];
        System.out.println(queString); // To print the question

        System.out.println(array_answer[convert_into_integer][0]); //To print the options
        System.out.println();
        System.out.println();

        String correct_answer = array1[convert_into_integer][1]; // To store the answer in the variable
        return correct_answer; // to return the correct answer

    }
}
