// NOTE = I have used the Format Document function. After Formatting, the files was messy and hard to understand so I indent all the statement in the "easy to understand" manner.

// NOTE = Here, Lifeline is made available for infinite times to check the code working or not till 15 questions.

// NOTE = Sometimes it get the error , I don't know why. Sometimes its works perfectly fine. Please check multiple times for output.



// This is the Main file of the Game

import java.util.Scanner; // Import the Scanner class

public class Main {

    public static void main(String[] args) {

        // Reference file is been added by creating the object below
        Reference obj = new Reference();

        Scanner sc = new Scanner(System.in); // Create a Scanner object

        // Below statement are used for designing purpose
        System.out.println();
        for (int i = 0; i < 30; i++) {
            System.out.print("*");
        }
        System.out.print("  WHO WANTS TO BE A MILLIONAIRE?  ");
        for (int i = 0; i < 30; i++) {
            System.out.print("*");
        }
        System.out.println();
        System.out.println();

        // Here I have used array, random function (to generate a random number from the array), and switch statement to display the message accoordingly.

        int[] message_using_switch = { 1, 2, 3 }; // Integer array is created here
        double theRandomNumber = Math.floor(Math.random() * 3) + 1; // Generating a random Number
        int integer_value = (int) theRandomNumber; // Converting the number in the integer value

        // switch statement is used for message
        switch (integer_value) {
            case 1:
                System.out.println("------Welcome Ladies and Gentlemen------");
                break;
            case 2:
                System.out.println("------Namaste, Canada------");
                break;
            case 3:
                System.out.println("------Welcome to the world of quizzes------");
                break;
            default: // If any of the above case is not satisfied then the default statement will be
                // display. Default does not require break statement so I haven't used it.
                System.out.println("------Hello Everyone------");
        }

        // Below I have used the concept of exceptional handling using try and catch
        try {
            System.out.println();
            System.out.println();
            obj.game_info();  // To pass the flow of execution to the game_info function/method
            System.out.println();
            System.out.println();
            System.out.println();

            System.out.print("Press 'y' to start the game:  ");

            String x = sc.next(); // To get the output from the user
            if (x.equals("y")) {
                System.out.println();
                System.out.println("Game has been Started");
                for(int i=0; i<100;i++){
                    System.out.print("-");
                }
                System.out.println();
                obj.game_start();  // From here, the game will be started
            } else {
                System.out.println("Wrong Input");
            }
        } catch (Exception e) {
            System.out.println("Not Working Properly Please review");
        }
    }
}