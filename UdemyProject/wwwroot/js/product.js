var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable(){
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Admin/Product/getAll"
        },
        "columns": [
            { "data": "Name", "width": "15%" },
            { "data": "Description", "width": "15%" },
            { "data": "Manufacturer", "width": "15%" },
            { "data": "Category", "width": "15%" },
            { "data": "Price", "width": "15%" },
        ]
    });
}