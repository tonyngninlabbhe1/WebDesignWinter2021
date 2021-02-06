
function validate() {
document.getElementById('username-error').style.visibility = 'hidden';
document.getElementById('password-error').style.visibility = 'hidden';

let username = document.getElementById('username').value;
let password = document.getElementById('password').value;

console.debug('username: ', username);
console.debug('password: ', password);

if(username === '')
{
    document.getElementById('username-error').style.visibility = 'visible';
}


if(password === '')
{
    document.getElementById('password-error').style.visibility = 'visible';
}

if(password != '' && password !='')
{
    alert("validation succeeded");
    window.location.href="index.html";
}

 document.cookie = `username=${username} ${password}; expires=31 Dec 2024 12:00:00 UTC; path=/`;
}
