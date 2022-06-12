var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable(){
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Admin/Product/getall"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "manufacturer", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "deviceClass.name", "width": "15%" },
            { "data": "price", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                  <div role="group">
                 <a href="/Admin/Product/Upsert?id=${data}" class="btn btn-yellow-glow float-md-none"> <i class="bi bi-pencil-square"></i> Edit</a>
                 <a onClick=Delete('/Admin/Product/Delete/${data}') class="btn btn-danger-glow float-md-none"> <i class="bi bi-trash-fill"></i> Delete </a>
                 </div>
                    `
                },
                "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}