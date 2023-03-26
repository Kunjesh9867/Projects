import java.util.Scanner;
import java.util.Random;

public class Main {
    public static void main(String[] args) {

        String[] arr = { "R", "P", "S" };

        boolean x = true;
        while (x) {
            String computer_Number = arr[new Random().nextInt(arr.length)];
            String user_input;

            while (true) {
                Scanner sc = new Scanner(System.in);
                System.out.print("Please enter your value here (Rock=R, Scissor=S, Paper=P): ");
                user_input = sc.nextLine();

                if (user_input.equals("R") || user_input.equals("P") || user_input.equals("S")) {
                    break;
                } else {
                    System.out.println("Please enter the correct input. Note the case sensitivity of your input");
                }
            }

            System.out.print("Computer Played: ");
            System.out.println(computer_Number);


            if (user_input.equals(computer_Number)) {
                System.out.println("It's a tie");
            }

            else if (user_input.equals("R")) {
                if (computer_Number.equals("P")) {
                    System.out.println("User Wins !!!");
                    x=false;
                } else {
                    System.out.println("Computer Wins !!!");
                }
            }

            else if (user_input.equals("P")) {
                if (computer_Number.equals("R")) {
                    System.out.println("User Win !!!");
                    x=false;
                } else {
                    System.out.println("Computer win !!!");
                }
            }

            else if (user_input.equals("S")) {
                if (computer_Number.equals("P")) {
                    System.out.println("User Win !!!");
                    x=false;
                } else {
                    System.out.println("Computer win !!!");
                }
            }

            else {
                System.out.println("Sorry, your input is invalid. Try again");
            }

        }
        System.out.println("Game Over. Thank you for playing :)");

    }

}
