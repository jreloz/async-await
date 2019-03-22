<?php


 $dbhost = "localhost";
 $dbuser = "root";
 $dbpass = "";
 $db = "sms";

 $conn = new mysqli($dbhost, $dbuser, $dbpass,$db) or die("Connect failed: %s\n". $conn -> error);
  

//$_SERVER['REQUEST_METHOD'];

//if ($_SERVER['REQUEST_METHOD'] === 'POST') {



if(isset($_GET['searchref'])){

  $phone = $_GET['searchref'];
  

  $query = "SELECT * FROM sms WHERE phone = '$phone' ";
  $result = mysqli_query($conn,$query);
  
  $row = mysqli_fetch_row($result);

  if($re)
  $message = $row[1];

  echo json_encode(array($message));

}


if(isset($_POST['sendSMS'])){

  $phone = $_POST['phone'];
  $msg = $_POST['msg'];

  $query = "INSERT INTO sms (phone, msg) values('$phone','$msg')";
  mysqli_query($conn,$query);
  
  echo json_encode(array('SMS has been posted'));

}


/*if ($_SERVER['REQUEST_METHOD'] === 'POST') {

  $phone = $_POST['phone'];
  $msg = $_POST['msg'];

  $query = "INSERT INTO sms (phone, msg) values('$phone','$msg')";
  mysqli_query($conn,$query);
  
  echo json_encode(array('SMS has been posted'));

}*/


?>
