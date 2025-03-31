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

$sql = "SELECT Name FROM user WHERE Name == '". $loginUser . "'";

$result = $conn->query($sql);

if ($result->num_rows > 0) {
    echo "Username is already taken";

} else {
    echo "Creating user... ";
    $sql2 = "INSERT INTO users (Name, Password_Hash) VALUES ('" . $loginUser . "', '" . $loginPass . "')";
    if ($conn->query($sql2) === TRUE) {
        echo "New record created succesfully";
    } else {
        echo "Error: " . $sql2 . "<br>" . $conn->error;
    }
}
$conn->close()

?>