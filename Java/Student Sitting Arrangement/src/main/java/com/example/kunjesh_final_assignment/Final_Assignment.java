package com.example.kunjesh_final_assignment;


import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.ColorPicker;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.layout.Pane;
import javafx.scene.paint.Color;
import javafx.scene.text.Text;
import java.util.*;
import java.util.Random;
public class Final_Assignment {

    @FXML
    private ColorPicker studentColor ;

    @FXML
    private TextField nameOfStudent;

    @FXML
    private Pane pane0;

    @FXML
    private Pane pane1;

    @FXML
    private Pane pane2;

    @FXML
    private Pane pane3;

    @FXML
    private Pane pane4;

    @FXML
    private Pane pane5;

    @FXML
    private Pane pane6;

    @FXML
    private Pane pane7;

    @FXML
    private Pane pane8;

    @FXML
    private Text student0;
    @FXML
    private Text student1;

    @FXML
    private Text student2;

    @FXML
    private Text student3;

    @FXML
    private Text student4;

    @FXML
    private Text student5;

    @FXML
    private Text student6;

    @FXML
    private Text student7;

    @FXML
    private Text student8;

    @FXML
    private Label messageToBeDisplayed;


    int sum=0;   // TO check at the end whether all the seats are full or not
    ArrayList<String> colorCode = new ArrayList<String>(); // To store all the color code which are used in the array
    ArrayList<String> studentNames = new ArrayList<String>(); // To store all the names of the student which are added in the array
    @FXML
    void onAddStudent(ActionEvent event) { // when user click the button, following tasks will be performed
        Random rand = new Random(); // To generate random number

        Pane[] paneArray = {pane0,pane1,pane2,pane3,pane4, pane5, pane6,pane7,pane8};
        Text[] studentNameArray = {student0,student1,student2,student3,student4, student5,student6,student7,student8};
        String[] array = {"EmptyColor","EmptyColor","EmptyColor","EmptyColor","EmptyColor","EmptyColor","EmptyColor","EmptyColor","EmptyColor","EmptyColor"};

        Color inputColor = studentColor.getValue();  // To get the color value
        String inputName = nameOfStudent.getText();  // To get the input value

        String error = "Error_Message";  // To store and later on display the error message

        int randomInteger = rand.nextInt(0, 9);

        if(sum==9){ // When seats are full, this loop will be executed
            messageToBeDisplayed.setText("No Vacant Seat Available :( ");
            messageToBeDisplayed.setVisible(true);
            error="No_Seat_Available";
        }
        while (!error.equals("No_Seat_Available")){ // When seats are not full

            if (paneArray[randomInteger].getStyle().equals("-fx-background-color: #ffffff;" )) // To check whether the background color is white or not
            {
                if(inputName.isEmpty()){ // To check whether the name is empty or not
                    error="Empty_Name"; break;
                }

                if(inputColor.toString().equals("0xffffffff")){ // To check whether the color chosen is white or not
                    error="White_Background";
                    break;
                }


                if(studentNames.contains(inputName.toLowerCase())){ // To check whether the name is already added
                    error="Name_Taken";
                    break;
                }
//
                if(colorCode.contains(inputColor.toString())){ // To check whether the color is empty or not
                    error="Color_Taken";
                    break;
                }

//
//


                studentNames.add(inputName.toLowerCase()); // To add the name in the name array
                colorCode.add(inputColor.toString());      // To add the color in the name array
                messageToBeDisplayed.setVisible(false);
                array[randomInteger]="Color"; // To change the value from "EmptyColor" => "Color"
                sum++;

                paneArray[randomInteger].setStyle("-fx-background-color: #" + inputColor.toString().substring(2));
//                System.out.println(inputColor.toString());

                studentNameArray[randomInteger].setText(inputName); // To set the name
                studentNameArray[randomInteger].setVisible(true);   // To display the name
                if(sum==9) { // When all the seats are taken
                    messageToBeDisplayed.setText("Congratulation!! All Seats taken");
                    messageToBeDisplayed.setStyle("-fx-background-color: rgba(255,0,0,.3)");
                    messageToBeDisplayed.setVisible(true);
                    break;
                }
                break;

            }else{
                error="Error_Message";
                randomInteger = rand.nextInt(0, 9);
                if(Objects.equals(array[randomInteger], "Empty"))
                    continue;
                if(sum==9)
                    break;
            }
        }
        // When the error occur, the loop will go into the following:
        switch (error) {
            case "Name_Taken" -> {
                messageToBeDisplayed.setText("STUDENT NAME TAKEN!!");
                messageToBeDisplayed.setStyle("-fx-background-color: rgba(255,0,0,.3)");
                messageToBeDisplayed.setVisible(true);
            }
            case "Color_Taken" -> {
                messageToBeDisplayed.setText("INVALID COLOR");
                messageToBeDisplayed.setStyle("-fx-background-color: rgba(255,0,0,.3)");
                messageToBeDisplayed.setVisible(true);
            }
            case "White_Background" -> {
                messageToBeDisplayed.setText("White Color is not valid");
                messageToBeDisplayed.setStyle("-fx-background-color: rgba(255,0,0,.3)");
                messageToBeDisplayed.setVisible(true);
            }
            case "Empty_Name" -> {
                messageToBeDisplayed.setText("Name is Empty");
                messageToBeDisplayed.setStyle("-fx-background-color: rgba(255,0,0,.3)");
                messageToBeDisplayed.setVisible(true);
            }
        }
    }

    @FXML
    void initialize() {
        student0.setVisible(false);
        student1.setVisible(false);
        student2.setVisible(false);
        student3.setVisible(false);
        student4.setVisible(false);
        student5.setVisible(false);
        student6.setVisible(false);
        student7.setVisible(false);
        student8.setVisible(false);
        messageToBeDisplayed.setVisible(false);
    }

}
