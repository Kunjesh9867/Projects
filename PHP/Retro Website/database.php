<?php

class database{
  private $servername = "172.31.22.43";
  private $username   = "Kunjesh_Kantilal200515106";
  private $password   = "wLhe2Jgj3N";
  private $database   = "Kunjesh_Kantilal200515106";
  public  $con;


  // Database Connection
  public function __construct()
  {
    $this->con = new mysqli($this->servername, $this->username,$this->password,$this->database);
    if(mysqli_connect_error()) {
      trigger_error("Failed to connect to MySQL: " . mysqli_connect_error());
    }else{
      return $this->con;
    }
  }

  // Insert customer data into customer table
  public function insertData($post)
  {
    $firstname = $this->con->real_escape_string($_POST['firstname']);
    $lastname = $this->con->real_escape_string($_POST['lastname']);
    $email = $this->con->real_escape_string($_POST['email']);
    $pass = $this->con->real_escape_string($_POST['password']);
    $bio = $this->con->real_escape_string($_POST['bio']);
    $query="INSERT INTO RECORDS(FIRST_NAME,LAST_NAME,EMAIL,COUNTRY,BIO) VALUES('$firstname','$lastname','$email','$pass','$bio')";
    $sql = $this->con->query($query);
    if ($sql==true) {
      header("Location:index.php?msg1=insert");
    }else{
      echo "Registration failed try again!";
    }
  }

  // Fetch customer records for show listing
  public function displayData()
  {
    $query = "SELECT * FROM RECORDS";
    $result = $this->con->query($query);
    if ($result->num_rows > 0) {
      $data = array();
      while ($row = $result->fetch_assoc()) {
        $data[] = $row;
      }
      return $data;
    }else{
      echo "No found records";
    }
  }

  // Fetch single data for edit from customer table
  public function displyaRecordById($id)
  {
    $query = "SELECT * FROM RECORDS WHERE ID = '$id'";
    $result = $this->con->query($query);
    if ($result->num_rows > 0) {
      $row = $result->fetch_assoc();
      return $row;
    }else{
      echo "Record not found";
    }
  }

  // Update customer data into customer table
  public function updateRecord($postData)
  {
    $firstname = $this->con->real_escape_string($_POST['ufirstname']);
    $lastname = $this->con->real_escape_string($_POST['ulastname']);
    $email = $this->con->real_escape_string($_POST['uemail']);
    $password = $this->con->real_escape_string($_POST['upassword']);
    $bio = $this->con->real_escape_string($_POST['ubio']);
    $id = $this->con->real_escape_string($_POST['id']);
    // $password = hash('sha224', $password);
    if (!empty($id) && !empty($postData)) {
      $query = "UPDATE RECORDS SET FIRST_NAME = '$firstname',LAST_NAME = '$lastname', EMAIL = '$email',COUNTRY = '$password', BIO = '$bio' WHERE ID = '$id'";
      $sql = $this->con->query($query);
      if ($sql==true) {
        header("Location:index.php?msg2=update");
      }else{
        echo "Registration updated failed try again!";
      }
    }

  }

  // Delete customer data from customer table
  public function deleteRecord($id)
  {
    $query = "DELETE FROM RECORDS WHERE ID = '$id'";
    $sql = $this->con->query($query);
    if ($sql==true) {
      header("Location:index.php?msg3=delete");
    }else{
      echo "Record does not delete try again";
    }
  }
}
