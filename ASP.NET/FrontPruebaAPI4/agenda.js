let tbody = document.getElementById("contactosBody")
let counterContactos = document.getElementById("totalContactos")
let placeholder = document.getElementById("placeholderId")
let btnAdd = document.querySelector(".btn-add")
let modal = document.getElementById("modalNuevoContacto")
let closeBtn = document.getElementById("closeBtn")
let cancelBtn = document.getElementById("cancelBtn")
let formContacto = document.getElementById("formContacto")

// Modal Editar
let modalEditar = document.getElementById("modalEditarContacto")
let closeEditBtn = document.getElementById("closeEditBtn")
let cancelEditBtn = document.getElementById("cancelEditBtn")
let formEditarContacto = document.getElementById("formEditarContacto")
let contactoEnEdicion = null

// Event Listeners
btnAdd.addEventListener("click", openModal)
closeBtn.addEventListener("click", closeModal)
cancelBtn.addEventListener("click", closeModal)
window.addEventListener("click", closeModalOnBackdrop)
formContacto.addEventListener("submit", handleSubmitForm)

// Event Listeners Modal Editar
closeEditBtn.addEventListener("click", closeModalEditar)
cancelEditBtn.addEventListener("click", closeModalEditar)
formEditarContacto.addEventListener("submit", handleSubmitFormEditar)

updateContactos()

async function updateContactos() {
    tbody.replaceChildren()
    let cantidadContactos = 0
    const res = await fetch("https://localhost:7107/api/agenda")
    const data = await res.json()
    data.forEach((contacto) => {
        let tr = document.createElement("tr")
        tr.innerHTML = `
        <td>${contacto.contactId}</td>
        <td>${contacto.name}</td>
        <td>${contacto.email}</td>
        <td>${contacto.phone}</td>
        <td>
            <button class="btn-delete" onclick="deleteContact(${contacto.contactId})">
                <svg xmlns="http://www.w3.org/2000/svg" width="23" height="23" fill="#252525" viewBox="0 0 24 24" >
                    <path d="M17 6V4c0-1.1-.9-2-2-2H9c-1.1 0-2 .9-2 2v2H2v2h2v12c0 1.1.9 2 2 2h12c1.1 0 2-.9 2-2V8h2V6zM9 4h6v2H9zM6 20V8h12v12z"></path><path d="M9 10h2v8H9zm4 0h2v8h-2z"></path>
                </svg>
            </button>
            <button class="btn-edit" onclick="openModalEditar(${contacto.contactId}, '${contacto.name}', '${contacto.email}', '${contacto.phone}')">
            <svg  xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="#252525" viewBox="0 0 24 24" >
                <path d="M19.67 2.61c-.81-.81-2.14-.81-2.95 0L3.38 15.95c-.13.13-.22.29-.26.46l-1.09 4.34c-.08.34.01.7.26.95.19.19.45.29.71.29.08 0 .16 0 .24-.03l4.34-1.09c.18-.04.34-.13.46-.26L21.38 7.27c.81-.81.81-2.14 0-2.95L19.66 2.6ZM6.83 19.01l-2.46.61.61-2.46 9.96-9.94 1.84 1.84zM19.98 5.86 18.2 7.64 16.36 5.8l1.78-1.78s.09-.03.12 0l1.72 1.72s.03.09 0 .12"></path>
            </svg>
            </button>
        </td>
        `
        tbody.appendChild(tr)
        cantidadContactos++
    })
    counterContactos.textContent = cantidadContactos
    if (cantidadContactos > 0) placeholder.classList.add("none")
    else placeholder.classList.remove("none")
}

async function deleteContact(id) {
    if (confirm("¿Estás seguro de que deseas eliminar este contacto?")) {
        await fetch(`https://localhost:7107/api/agenda/${id}`, {
            method: "DELETE",
        })
        await updateContactos()
    }
}

// Modal Functions
function openModal() {
    modal.classList.add("show")
    formContacto.reset()
}

function closeModal() {
    modal.classList.remove("show")
    formContacto.reset()
}

function closeModalOnBackdrop(event) {
    if (event.target === modal) {
        closeModal()
    }
}

async function handleSubmitForm(event) {
    event.preventDefault()
    
    const nombre = document.getElementById("nombreInput").value.trim()
    const email = document.getElementById("emailInput").value.trim()
    const telefono = document.getElementById("telefonoInput").value.trim()
    
    if (!nombre || !email || !telefono) {
        alert("Por favor, completa todos los campos")
        return
    }
    
    try {
        const response = await fetch("https://localhost:7107/api/agenda", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                name: nombre,
                email: email,
                phone: telefono,
            }),
        })
        
        if (response.ok) {
            alert("Contacto agregado exitosamente")
            closeModal()
            await updateContactos()
        } else {
            alert("Error al agregar el contacto")
        }
    } catch (error) {
        console.error("Error:", error)
        alert("Error al procesar la solicitud")
    }
}

// Modal Editar Functions
function openModalEditar(id, nombre, email, telefono) {
    contactoEnEdicion = id
    document.getElementById("editIdInput").value = id
    document.getElementById("editNombreInput").value = nombre
    document.getElementById("editEmailInput").value = email
    document.getElementById("editTelefonoInput").value = telefono
    modalEditar.classList.add("show")
}

function closeModalEditar() {
    modalEditar.classList.remove("show")
    formEditarContacto.reset()
    contactoEnEdicion = null
}

async function handleSubmitFormEditar(event) {
    event.preventDefault()
    
    const nombre = document.getElementById("editNombreInput").value.trim()
    const email = document.getElementById("editEmailInput").value.trim()
    const telefono = document.getElementById("editTelefonoInput").value.trim()
    
    if (!nombre || !email || !telefono) {
        alert("Por favor, completa todos los campos")
        return
    }
    
    try {
        const res = await fetch(`https://localhost:7107/api/agenda/${contactoEnEdicion}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                name: nombre,
                email: email,
                phone: telefono
            }),
        })
        if(res.ok) {
            alert("Contacto editado")
        }
    } catch (error) {
        console.log("Error: " + error)
    }
    
    closeModalEditar()
    await updateContactos()
}