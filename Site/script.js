function saveProduct() {
  let productName = document.getElementById("prod-name").value;
  let productPrice = document.getElementById("prod-price").value;
  let productQuantity = document.getElementById("prod-category").value;

  // Creăm un FormData pentru a trimite datele
  const formData = new FormData();
  formData.append("nume", productName);
  formData.append("pret", productPrice);
  formData.append("qt", productQuantity);

  fetch("http://localhost:5249/api/produse/adauga", {
    method: "POST",
    body: formData,
  })
    .then((response) => response.json())
    .then((data) => {
      alert(data.mesaj);
    })
    .catch((error) => {
      console.error("Eroare:", error);
    });
}

function saveExpense() {
  let expDescription = document.getElementById("exp-desc").value;
  let expAmount = document.getElementById("exp-amount").value;
  let data = document.getElementById("exp-date").value;

  const formData = new FormData();
  formData.append("nume", expDescription);
  formData.append("suma", expAmount);
  formData.append("data", data);

  fetch("http://localhost:5249/api/cheltuieli/adauga", {
    method: "POST",
    body: formData,
  })
    .then((response) => response.json())
    .then((data) => {
      alert(data.mesaj);
    })
    .catch((error) => {
      console.error("Eroare:", error);
    });
}

function saveNote() {
  let noteName = document.getElementById("notes").value;
  const formData = new FormData();
  formData.append("continut", noteName);
  fetch("http://localhost:5249/api/notite/adauga", {
    method: "POST",
    body: formData,
  })
    .then((response) => response.json())
    .then((data) => {
      alert(data.mesaj);
    })
    .catch((error) => {
      console.error("Eroare:", error);
    });
}
