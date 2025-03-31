<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "rythmn";

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
echo "Connected Succesfully, Users in the database: ";

$sql = "SELECT id, name, email FROM user";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()){
        echo "<br>". "id: " .$row["id"]. " - Name: " .$row["name"]. " - Email: " .$row["email"];
    }
} else {
    echo "<br> 0 results";
}
$conn->close()

?>