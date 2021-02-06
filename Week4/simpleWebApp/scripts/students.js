// Don't add spaces on the jSON object property name
// 
function getStudents()
{
    var students = '{"students": [{"studentID": "48631", "emailAddress": "mike_@test.com" }, {"studentID": "54613", "emailAddress": "jane_@test.com" }]}'
    return JSON.parse(students);
}

function intializeStudents() 
{
    var data = getStudents();
    displayStudents(data.students);
}

// Don't fully understand what this piece code is doing
// What is tableRow variable for?
// How are looping through each element in the student
// object?
function displayStudents(students)
{
    var tableRow ="";
    for(i=0;i<students.length; i++)
    {
        var studentID = students[i].studentID;
        var emailAddress= students[i].emailAddress;
        tableRow += "<tr><td>" + studentID + "</td><td>" + emailAddress + "</d></tr>";
    }

    document.getElementById("studentTable").innerHTML = tableRow;
}

