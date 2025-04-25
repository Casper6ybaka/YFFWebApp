document.addEventListener("load", lastInnTodoListe)

function leggTilTodo() {
    const tekst = document.getElementById("taskInput").value.trim();
    const liste = JSON.parse(localStorage.getItem("tasks"));
    liste.push(tekst);

    localStorage.setItem("tasks", JSON.stringify(liste));

    lastInnTodoListe();
}

function lastInnTodoListe() {
    const tasks = JSON.parse(localStorage.getItem("tasks"))
    const liste = document.getElementById("taskList")

    liste.innerHTML = '' // reset

    for (task in tasks) {
        const li = document.createElement("li");
        li.textContent = task;
        liste.appendChild(li);
    };
}