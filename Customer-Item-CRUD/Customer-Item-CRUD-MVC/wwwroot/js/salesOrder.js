var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $('#tblData thead tr').clone(true).appendTo('#tblData thead');

    $('#tblData thead tr:eq(1) th.src').each(function (i) {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');

        $('input', this).on('keyup change', function () {
            if (dataTable.column(i).search() !== this.value) {
                dataTable
                    .column(i)
                    .search(this.value)
                    .draw();
            }
        });
    });
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/SalesOrder/GetAllSalesOrder",
            "type": "GET",
            "datatype": "json"
        },
        "orderCellsTop": "true",
        "fixedHeader": "true",
        "columns": [
            {
                "data": "sordid",
                "render": function (id) {
                    return `<div">
                                <a href="/items/index/${id}">${id}</a>
                             </div>
                            `;
                },
                "width": "20%"
            },
            { "data": "customer", "width": "20%" },
            { "data": "sorddate", "width": "20%" },
            { "data": "sordamnt", "width": "20%" },
            {
                "data": "sordid",
                "render": function (data) {
                    return `<div class="text-center">
                                
                                <a onclick=Delete("/SalesOrder/DeleteSalesOrder/${data}") class='btn btn-danger text-white'
                                    style='cursor:pointer;'> <i class='far fa-trash-alt'></i></a>
                                </div>
                            `;
                }, "width": "20%"
            }
        ],
    });
}

function Delete(url) {
    //sweetalert
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        //based on user clicks yes or no 
        if (willDelete) {
            $.ajax({
                type: 'PATCH',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                        swal("Item has been successfully deleted!", {
                            icon: "success",
                        });
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        } else {
            swal("Item is safe!");
        }
    });
}