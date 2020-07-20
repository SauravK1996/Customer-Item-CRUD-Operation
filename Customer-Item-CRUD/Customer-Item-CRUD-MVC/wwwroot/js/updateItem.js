$("body").on("click", ".js-update-rate", function (e) {
    
    e.preventDefault();
    var $button = $(this);

    var salesOrderItemDetails = $button.data("sordid");

    var array = salesOrderItemDetails.split("-");

    var sordid = array[0];
    var itemId = array[1];
    var itemName = array[2];
    var itemRate = array[3];

    $('#sordid').val(sordid);
    $('#itemId').val(itemId);
    $('#itemName').val(itemName);
    $('#itemRate').val(itemRate);

    $('#modalUpdateRate').find('.modal-title').html('UPDATE RATE OF ITEM');
    $('#modalUpdateRate').modal('show');
});