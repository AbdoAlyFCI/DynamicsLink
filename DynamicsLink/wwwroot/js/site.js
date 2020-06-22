"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/StoresHub").build();

connection.start().then(function () {
    console.log("Start Connection");
}).catch(function (err) {
    return console.error(err.toString());
});



class Unit {
    constructor(unitId, unitName, unitPrice, unityQty, unitDiscount) {
        this.id = unitId;
        this.name = unitName;
        this.price = unitPrice;
        this.qty = unityQty;
        this.discount = unitDiscount;
    }
}

class Item {
    constructor(itemId, itemName) {
        this.id = itemId;
        this.name = itemName;
        this.units = null;
    }

    SetUnits(units) {
        if (this.units == null) {
            this.units = new Array();
            for (var i = 0; i < units.length; i++) {
                let item = new Unit(
                    units[i]['id'],
                    units[i]['name'],
                    units[i]['price'],
                    units[i]['quntity'],
                    units[i]['discount']);
                this.units.push(item);
            }
        }
    }

    GetUnit(unitId) {
        for (var i = 0; i < this.units.length; i++) {
            if (this.units[i]["id"] === unitId)
                return this.units[i];
        }

        return null;
    }

    
}

class Store {
    constructor(storeId, storeName) {
        this.id = storeId;
        this.name = storeName;
        this.items = null;
        this.invoiceRows = null;
        this.rowCount = 0;
        this.totalPrice = 0;
        this.taxes = .14;
        this.NetPrice = 0;
    }

    SetItems(items) {
        if (this.items == null) {
            this.items = new Array();
            //const response = await getItemResponse(this.id);
            for (var i = 0; i < items.length; i++) {
                let item = new Item(items[i]["id"], items[i]["name"]);
                this.items.push(item);
            }

        }
    }

    GetItemIndex(itemId) {
        for (var i = 0; i < this.items.length; i++) {
            if (this.items[i]["id"] === itemId)
                return i;
        }

        return -1;
    }

}



let tbody = document.getElementById("tbody");
let table = document.getElementById("InvoiceTable");
var tablerows = document.getElementById("rows");
let storesOption = document.getElementById("stores");

//Get current stores
let stores = new Array();

for (var i = 0; i < storesOption.length; i++) {
    let store = new Store(storesOption[i].value, storesOption[i].innerText);
    var storeBody = tbody.cloneNode(true);
    storeBody.id = "tbody" + storesOption[i].innerText;
    store.invoiceRows = storeBody;
    createRowIdintfication(store.invoiceRows.childNodes[1], 1);
    store.rowCount++;
    stores.push(store);
}

let currentStore = stores[0];
console.log(currentStore.invoiceRows)
table.removeChild(tbody);
table.appendChild(currentStore.invoiceRows);
//GetItemsFromServer();


function LoadItems() {
    if (currentStore['items'] == null) {
        connection.invoke("GetItems", currentStore["id"]).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    }
}

function LoadUnit(e) {

    let num = e.id.split("_")[1];
    console.log(num);
    let itemList = document.getElementById("ItemList_" + num.toString());
    let selectedItem = itemList.options[itemList.selectedIndex].value;
    let itemIndex = currentStore.GetItemIndex(selectedItem);
    if (currentStore['items'][itemIndex]['units'] == null) {
        connection.invoke("GetItemUnits", selectedItem, itemIndex).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    }
    else {
        setUnitsOnDom(currentStore['items'][itemIndex]['units'],num);
    }
}

function SetUnitValues(e) {

    let id = e.id.split("_")[1].toString();
    console.log(id);
    let itemList = document.getElementById("ItemList_"+id);
    let selectedItem = itemList.options[itemList.selectedIndex].value;
    let itemIndex = currentStore.GetItemIndex(selectedItem);

    let unitList = document.getElementById("UnitList_"+id);
    let selectedUnit = unitList.options[unitList.selectedIndex].value;

    //Get unit
    let unit = currentStore.items[itemIndex].GetUnit(selectedUnit);

    let price = document.getElementById("UnitPrice_"+id);
    price.innerText = unit['price'];
    let discount = document.getElementById("UnitDiscount_"+id);
    discount.innerText = unit['discount']
    let  qty = document.getElementById("UnitQty_"+id);
    qty.max = unit['qty']

}

function changeQty(e) {
    let num = e.id.split("_")[1];
    console.log(num);
    let totalElement = document.getElementById("TotalPrice_" + num);
    let netElement = document.getElementById("Net_" + num);
    let unitPrice = parseInt(document.getElementById("UnitPrice_" + num).innerText);
    let unitDiscount = parseFloat(document.getElementById("UnitDiscount_" + num).innerText);

    let totalPrice = e.value * unitPrice;
    totalElement.innerText = totalPrice;

    let netPrice = totalPrice - (totalPrice * unitDiscount);
    netElement.innerText = netPrice;
    UpdateCashTable();

}

function AddRow() {
    currentStore.rowCount++;
    let newRow = tablerows.cloneNode(true);;
    newRow.id = (tablerows.id + currentStore.rowCount.toString() + currentStore.rowCount.toString());
    createRowIdintfication(newRow, currentStore.rowCount);

    const prevRowNum = currentStore.rowCount - 1;
    //let ItemListId = "ItemList_" + currentStore.rowCount.toString() + currentStore.rowCount.toString();

    currentStore.invoiceRows.appendChild(newRow);

    document.getElementById("ItemList_" + currentStore.rowCount.toString()).innerHTML =
        document.getElementById("ItemList_" + prevRowNum.toString()).innerHTML;

    document.getElementById("UnitList_" + currentStore.rowCount.toString()).innerHTML =
        document.getElementById("UnitList_" + prevRowNum.toString()).innerHTML;




}


function UpdateCashTable() {
    var total = document.getElementById("Total");
    let t = 0,n=0;
    for (var i = 1; i <= currentStore.rowCount; i++) {
        t += parseFloat(document.getElementById("TotalPrice_" + i).innerHTML);
        n += parseFloat(document.getElementById("Net_" + i).innerHTML);
    }
    total.innerHTML = t.toString();

    var taxes = t * currentStore.taxes
    var net = n + taxes
    document.getElementById("Taxes").innerHTML = taxes.toString();
    document.getElementById("Net").innerHTML = net.toString();
}



connection.on("SetItems", function (items) {
    //Get items for first time only
    currentStore.SetItems(items);
    let itemList = document.getElementById("ItemList_1");
    for (var i = 0; i < items.length; i++) {
        let option = document.createElement("option");
        option.value = items[i]["id"];
        option.innerText = items[i]["name"];
        itemList.appendChild(option);
    }

    itemList.onclick = '';
    //document.getElementById("UnitList").disabled  = false;


});


connection.on("SetItemUnits", function (units, index) {
    // Get item units for first time only
    console.log(units);
    currentStore.items[index].SetUnits(units);
    setUnitsOnDom(units, 1);
});


function setUnitsOnDom(units,num) {

    let unitList = document.getElementById("UnitList_"+num);
    unitList.innerHTML = '';
    for (var i = 0; i < units.length; i++) {
        let option = document.createElement("option");
        option.value = units[i]["id"];
        option.innerText = units[i]["name"];
        unitList.appendChild(option);
    }
}


function createRowIdintfication(row, num) {
    for (var j = 0, col; col = row.cells[j]; j++) {
        col.childNodes[1].id = col.childNodes[1].id + (num.toString());
    }
   
}









