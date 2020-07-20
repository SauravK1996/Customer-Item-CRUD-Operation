function Delete(itemId,salesId) {
   
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
                url: '/Items/DeleteSalesItem',
                data: {
                    'itemId': itemId,
                    'salesOrderId': salesId
                },
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        setTimeout(function () { location.reload(); }, 1000);
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