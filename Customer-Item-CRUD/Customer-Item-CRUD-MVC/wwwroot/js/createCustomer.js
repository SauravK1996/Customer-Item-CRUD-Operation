$("body").on("click", ".js-create-customer", function (e) {
    e.preventDefault();
    $('#modalAddItemToCustomer').find('.modal-title').html('Add Customer');
    $('#modalAddItemToCustomer').modal('show');
});