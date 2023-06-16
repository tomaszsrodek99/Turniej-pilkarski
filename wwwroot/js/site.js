function searchPlayerByName() {
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

// Funkcja do usuwania wszystkich opcji z selecta
function RemoveAllOptions(selectElement) {
    selectElement.innerHTML = "";
}

//Funkcja do zarządzania listą w odpowiedich selectach
function GetCountryList(countriesData, select) {
    var selectedHomeId = document.getElementById("createMatchHomeId").value;
    var selectedVisitorId = document.getElementById("createMatchVisitorId").value;
    var playStage = document.getElementById("playStage").value;
    var selectedCountry;
    var filteredCountries;

    /*if (select === "playStage" && playStage !== "Group") {
        UpdateOptions(countriesData, selectedHomeId, "createMatchVisitorId");
        UpdateOptions(countriesData, selectedVisitorId, "createMatchHomeId");
        return; // Zakończ funkcję po zaktualizowaniu listy dla innych niż Grupa
    } else if (select !== "playStage") {
        if (select == "createMatchHomeId") {
            console.log("if 1");
            var visitorSelect = document.getElementById("createMatchVisitorId");
            var homeSelectedOption = visitorSelect.options[visitorSelect.selectedIndex];
            UpdateOptions(countriesData, selectedHomeId, "createMatchVisitorId");
            // Przywróć wybraną opcję
            for (var i = 0; i < visitorSelect.options.length; i++) {
                if (visitorSelect.options[i].value == homeSelectedOption.value) {
                    visitorSelect.selectedIndex = i;
                    break;
                }
            }
        } else {
            console.log("if 2");
            var homeSelect = document.getElementById("createMatchHomeId");
            var visitorSelectedOption = homeSelect.options[homeSelect.selectedIndex];
            UpdateOptions(countriesData, selectedVisitorId, "createMatchHomeId");
            // Przywróć wybraną opcję
            for (var i = 0; i < homeSelect.options.length; i++) {
                if (homeSelect.options[i].value == visitorSelectedOption.value) {
                    homeSelect.selectedIndex = i;
                    break;
                }
            }
        }
    }*/

    // Czyszczenie listy państw w zależności od wyboru
    if (select == "createMatchHomeId") {
        selectedCountry = FindSelectedCountry(selectedHomeId);
        filteredCountries = countriesData.filter(function (country) {
            return country.group === selectedCountry.group && country.countryID != selectedCountry.countryID;
        });

        var visitorSelect = document.getElementById("createMatchVisitorId");
        var homeSelectedOption = visitorSelect.options[visitorSelect.selectedIndex];
        RemoveAllOptions(visitorSelect);

        CreateOptions(filteredCountries, "createMatchVisitorId");
        // Przywróć wybraną opcję
        for (var i = 0; i < visitorSelect.options.length; i++) {
            if (visitorSelect.options[i].value == homeSelectedOption.value) {
                visitorSelect.selectedIndex = i;
            }
        }

    } else {
        selectedCountry = FindSelectedCountry(selectedVisitorId);
        filteredCountries = countriesData.filter(function (country) {
            return country.group === selectedCountry.group && country.countryID != selectedCountry.countryID;
        });

        var homeSelect = document.getElementById("createMatchHomeId");
        var visitorSelectedOption = homeSelect.options[homeSelect.selectedIndex];
        RemoveAllOptions(homeSelect);

        CreateOptions(filteredCountries, "createMatchHomeId");
        if (homeSelect.options[i].value == visitorSelectedOption.value) {
            homeSelect.selectedIndex = i;
        }
    }
}










