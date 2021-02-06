function getInstrutors()
{
    var instrutors = '{"instrutors": [{"firstName": "Aaron", "middleInitial": "W." , "lastName": "Whistler" }, {"firstName": "Jake", "middleInitial": "B." , "lastName": "Vandargeer" }]}'
    return JSON.parse(instrutors);
}

function intializeInstrutors() 
{
    var data = getInstrutors();
    displayInstrutors(data.instrutors);
}

function displayInstrutors(instrutors)
{
    var tableRow ="";
    for(i=0;i<instrutors.length; i++)
    {
        var firstName = instrutors[i].firstName;
        var middleInitial = instrutors[i].middleInitial;
        var  lastName = instrutors[i].lastName;
        tableRow += "<tr><td>" + firstName + "</td><td>" + middleInitial + "</td><td>"+ lastName + "</d></tr>";
    }

    document.getElementById("instrutorTable").innerHTML = tableRow;
}
