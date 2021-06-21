const uri = 'api/Shops';
let shops = [];

function getShops() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayShops(data))
        .catch(error => console.error('Unable to get shops.', error));
}

function addShop()
{
    const addNameTextbox = document.getElementById('add-name');

    const shop = {
        name: addNameTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(shop)
    }).then(response => response.json())
        .then(() => {
            getShops();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add shop.', error));
}
function deleteShop(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getShops())
        .catch(error => console.error('Unable to delete shop.', error));
}

function displayEditForm(id) {
    const shop = shops.find(shop => shop.id === id);

    document.getElementById('edit-id').value = shop.id;
    document.getElementById('edit-name').value = shop.name;
    document.getElementById('editForm').shop.display = 'block';
}

function updateShop() {
    const shopid = document.getElementById('edit-id').value;
    const shop = {
        id: parseInt(shopid, 10),
        name: document.getElementById('edit-name').value.trim()

    };

    fetch(`${uri}/${shopid}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(shop)
    })
        .then(() => getShops())
        .catch(error => console.error('Unable to update shop.', error));

    closeInput();

    return false;
}
function closeInput() {
    document.getElementById('editForm').shop.display = 'none'; //editForm -> change to editStyle
}

function _displayShops(data) {
    const tBody = document.getElementById('shops');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(shop => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Редагувати';
        editButton.setAttribute('onclick', `displayEditForm(${shop.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Видалити';
        deleteButton.setAttribute('onclick', `deleteShop(${shop.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(shop.name);
        td1.appendChild(textNode);

        let td3 = tr.insertCell(1);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(2);
        td4.appendChild(deleteButton);

    });

    shops = data;
}
