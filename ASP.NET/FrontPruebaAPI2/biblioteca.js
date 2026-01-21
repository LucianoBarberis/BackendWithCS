const contLibros = document.getElementById("mapLibros")
const inputDate = document.getElementById("inpFecha")
const form = document.querySelector("form")
const url = "https://localhost:7040/api/biblioteca"

fetchBooks()

form.addEventListener("submit", async (e)=>{
    e.preventDefault()
    
    dataLibro = {
        Titulo: document.getElementById("inpTitulo").value,
        Autor: document.getElementById("inpAutor").value,
        publicacion: document.getElementById("inpFecha").value
    }
    console.log(dataLibro.Fecha)

    await fetch(url, {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(dataLibro)
    })
    fetchBooks()

})

function fetchBooks() {
    contLibros.innerHTML = ""
    fetch(url)
        .then(res => res.json())
        .then(data => data.map(libro => {
            boxLibro = document.createElement("div")
            boxLibro.innerHTML = `
            <p>Título: ${libro.titulo}</p>
            <p>Autor: ${libro.autor}</p>
            <p>Publicación: ${libro.publicacion.split('T')[0]}</p>
            <p>Id: ${libro.id}</p>
            <button onclick="deleteBook(${libro.id})">Delete</button>
            `
            contLibros.appendChild(boxLibro)
        }))
}

async function deleteBook(id) {
    await fetch(url + "/" + id, {
        method: "DELETE",
    })
    fetchBooks()
}