function saveProduct() {
  let productName = document.getElementById("prod-name").value;
  let productPrice = document.getElementById("prod-price").value;
  let productQuantity = document.getElementById("prod-category").value;

  // Creăm un FormData pentru a trimite datele
  const formData = new FormData();
  formData.append("nume", productName);
  formData.append("pret", productPrice);
  formData.append("qt", productQuantity);

  if (!productName || !productPrice || !productQuantity) {
    alert("Te rog completeaza toate campurile!");
    return;
  }

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

  if (!expDescription || !expAmount || !data) {
    alert("Te rog completeaza toate campurile!");
    return;
  }

  const formData = new FormData();
  formData.append("Name", expDescription);
  formData.append("suma", expAmount);
  formData.append("datasdaa", data);

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

  if (!noteName) {
    alert("Te rog completeaza toate campurile!");
    return;
  }

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

function saveCar() {
  let carName = document.getElementById("car-name").value;
  let carPrice = document.getElementById("car-price").value;
  let carQuantity = document.getElementById("car-category").value;

  // Creăm un FormData pentru a trimite datele
  const formData = new FormData();
  formData.append("nume", carName);
  formData.append("pret", carPrice);
  formData.append("qt", carQuantity);

  if (!carName || !carPrice || !carQuantity) {
    alert("Te rog completeaza toate campurile!");
    return;
  }

  fetch("http://localhost:5249/api/masini/", {
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
