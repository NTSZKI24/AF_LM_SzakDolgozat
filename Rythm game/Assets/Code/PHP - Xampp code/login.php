<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "rythmn";

$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT Password_Hash FROM user WHERE Name == '". $loginUser . "'";

$result = $conn->query($sql);

if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()){
        if($row["Password_Hash"] == $loginPass){
            echo "Login success. ";
        }
        else {
            echo "Wrong credentials. ";
        }
    }
} else {
    echo "Username does not exists. ";
}
$conn->close()

?>