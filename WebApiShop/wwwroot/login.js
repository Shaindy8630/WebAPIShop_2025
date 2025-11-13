const emailForUpdate = document.querySelector("#userName");
const firstNameForUpdate = document.querySelector("#firstName");
const lastNameForUpdate = document.querySelector("#lastName");
const passwordForUpdate = document.querySelector("#password");


const register = async () => {
    const password = passwordForUpdate.value;

    try {
        const response = await fetch('https://localhost:44367/api/Users/checkPassword', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(password)
        });
        
        if (response.status === 204) {
            const score = Number(response.headers.get('X-Password-Score'));
            if (score < 2) {
                alert("הסיסמה שלך חלשה מדי, בחר סיסמה חזקה יותר");
                return;
            }
        }
        else {
            alert("Error");
        }
        
        if (score < 2) {
            alert("הסיסמה שלך חלשה מדי, בחר סיסמה חזקה יותר.");
            return;
        }
    }
    catch (error) {
        console.error('Error occurred:', error);
    }

    const newUser = {
        userId: 0,
        UserEmail: emailForUpdate.value,
        UserFirstName: firstNameForUpdate.value,
        UserLastName: lastNameForUpdate.value,
        UserPassword: passwordForUpdate.value
    }


    try {
        const response = await fetch('https://localhost:44367/api/Users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)
        })
        if (response.ok) {
            alert("נרשמת בהצלחה!");
        }
        else
            alert("יש בעיה בהרשמה, נסה שוב..");
    }
    catch (error) {
        console.error('Error occurred:', error);
    }
    
    
}


const loginUserEmail = document.querySelector("#loginUserName");
const loginUserPassword = document.querySelector("#loginUserPassword");

const login = async () => {
    const loginUser = {
        loginUserEmail: loginUserEmail.value,
        loginUserPassword: loginUserPassword.value,
    }

    try {
        const response = await fetch('https://localhost:44367/api/Users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(loginUser)
        })

        if (response.ok && response.status !== 204) {
            const user = await response.json();
            sessionStorage.setItem('CurrentUser', JSON.stringify(user))
            window.location.href = "update.html"
        }
        else {
            alert("משתמש לא נמצא 😕");
            }
    }
    catch (error) {
        console.error('Error occurred:', error);
    }
}
const checkPassword = async () => {
    const pass = passwordForUpdate.value;
    const response = await fetch('https://localhost:44367/api/Users/check', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'

        },
        body: JSON.stringify(pass)
    })
    if (response.status === 204) {
        const score = Number(response.headers.get('X-Password-Score'));
        updateStrengthUI(score);
    }
    else {
        alert("Error");
    }

    

    updateStrengthUI(score);
    

}
function updateStrengthUI(score) {
    const colors = ["#ff4d4d", "#ff944d", "#ffdb4d", "#80ff80", "#33cc33"];
    const text = ["חלשה מאוד", "חלשה", "בינונית", "חזקה", "חזקה מאוד"];

    for (let i = 0; i < 5; i++) {
        const box = document.getElementById("l" + i);
        box.style.backgroundColor = (i <= score) ? colors[score] : "#ddd";
    }

    document.getElementById("strengthText").innerText =
        `דירוג ${score} – ${text[score]}`;
}





