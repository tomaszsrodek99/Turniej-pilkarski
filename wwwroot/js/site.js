﻿function searchPlayerByName() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("searchTable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
function searchCountryByName() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("searchTable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function goBack() {
    history.back();
}

function createPlayerForm() {
    document.getElementById('addPlayerButton').style.visibility = 'hidden';
    document.getElementById('playerFormContainer').style.display = 'block';
}

function cancelForm() {
    document.getElementById('addPlayerButton').style.visibility = 'visible';
    document.getElementById('playerFormContainer').style.display = 'none';
}

/*MATCH*/
//Funkcja do dodawania opcji do select'a
function CreateOptions(countryList, selectId) {
    var selectElement = document.getElementById(selectId);

    // Usunięcie istniejących opcji
    selectElement.innerHTML = "";

    // Tworzenie opcji dla każdego kraju
    countryList.forEach(function (country) {
        var option = document.createElement("option");
        option.value = country.countryID;
        option.text = country.countryName;
        selectElement.appendChild(option);
    });
}

//Funkcja do szukania wybranego kraju
function FindSelectedCountry(selectedHomeId) {
    var selectedCountry;
    countriesData.forEach(function (country) {
        if (country.countryID == selectedHomeId) {
            selectedCountry = country;
        }
    });
    return selectedCountry;
}

//Funkcja do usuwania opcji z select'a
function RemoveOption(selectElement, optionValue) {
    for (var i = 0; i < selectElement.options.length; i++) {
        if (selectElement.options[i].value == optionValue) {
            selectElement.remove(i);
            break;
        }
    }
}
//Funkcja do aktualizowania select'a
function UpdateOptions(countriesData, selectedId, selectId) {
    CreateOptions(countriesData, selectId);
    RemoveOption(document.getElementById(selectId), selectedId);
}

//Funkcja do zarządzania listą w odpowiedich selectach
function GetCountryList(countriesData, select) {
    var selectedHomeId = document.getElementById("createMatchHomeId").value;
    var selectedVisitorId = document.getElementById("createMatchVisitorId").value;
    var playStage = document.getElementById("playStage").value;
    var selectedCountry;
    var filteredCountries;

    console.log("Wybrane HomeID: " + selectedHomeId);
    console.log("Wybrane VisitorID: " + selectedVisitorId);

    if (select === "playStage" && playStage !== "Grupa") {
        UpdateOptions(countriesData, selectedHomeId, "createMatchVisitorId");
        UpdateOptions(countriesData, selectedVisitorId, "createMatchHomeId");
        return; // Zakończ funkcję po zaktualizowaniu listy dla innych niż Grupa
    }

    if (select == "createMatchHomeId") {
        UpdateOptions(countriesData, selectedHomeId, "createMatchVisitorId");
    } else {
        UpdateOptions(countriesData, selectedVisitorId, "createMatchHomeId");
    }

    // Czyszczenie listy państw w zależności od wyboru
    if (playStage === "Grupa") {
        if (select == "createMatchHomeId") {
            selectedCountry = FindSelectedCountry(selectedHomeId);
            filteredCountries = countriesData.filter(function (country) {
                return country.grupa === selectedCountry.grupa && country.countryID != selectedHomeId;
            });
            CreateOptions(filteredCountries, "createMatchVisitorId");
        } else {
            selectedCountry = FindSelectedCountry(selectedVisitorId);
            filteredCountries = countriesData.filter(function (country) {
                return country.grupa === selectedCountry.grupa && country.countryID != selectedVisitorId;
            });
            CreateOptions(filteredCountries, "createMatchHomeId");
        }
    }
    //console.log("Wybrane HomeID: " + selectedHomeId);
    //console.log("Wybrane VisitorID: " + selectedVisitorId);
    //console.log("playStage: ", playStage);
    //console.log("countriesData: ", countriesData);
}










