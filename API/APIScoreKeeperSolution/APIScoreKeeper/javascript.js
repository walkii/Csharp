
if ('serviceWorker' in navigator) {
    navigator.serviceWorker
        .register('service-worker.js')
        .then(function () { console.log('Service Worker Registered'); });
}

var uri = 'api/score';
var jsons = { "name": ["", "", "", "", ""], "points": ["", "", "", "", ""] };
var i = 0;

function getdata() {
    var dataNoneParse = localStorage.getItem('myKey');
    var dataParse = JSON.parse(dataNoneParse);

    for (i in dataParse.name) {
        addTable(dataParse.name[i], dataParse.points[i]);
    }
}

// Make a request for a user with a given ID
console.log(navigator.onLine);
if (navigator.onLine) {

    axios.get(uri)
        .then(function (response) {
            // handle success

            response.data.forEach(function (item) {
                jsons.name[i] = item.Name;
                jsons.points[i] = item.Points;
                i++;
            });
            localStorage.setItem('myKey', JSON.stringify(jsons));
        })
        .catch(function (error) {
            // handle error
            console.log(error);
        })
        .then(function () {
            // always executed
            getdata();
        });
}
else {
    getdata();
}

function addTable(name, points) {

    var IdTable = document.getElementById("myTable");
    // var tblBody = document.createElement("tbody");
    var row = document.createElement("tr");
    var cellName = document.createElement("td");
    var cellTextName = document.createTextNode(name);
    cellName.appendChild(cellTextName);
    var cellPoint = document.createElement("td");
    var cellTextPoint = document.createTextNode(points + " Points");
    cellPoint.appendChild(cellTextPoint);
    row.appendChild(cellName);
    row.appendChild(cellPoint);
    //tblBody.appendChild(row);
    IdTable.appendChild(row);
}