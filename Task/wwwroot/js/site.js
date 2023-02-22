
let TotalOrder = 0;
let CustomerName = "";
function AddItem(id, Price, title ) {
    let Count = $(`#Item_${id} [type='number']`).val();
    let Total = Number(Count) * Number(Price);
    $(`#Items-Order`).append(`<div class="card mb-2"><div class="card-body"id="${id}"><h5 class="card-title">
                                ${title}</h5>   
                                <div class="d-flex justify-content-between">
                                <span>Count:x<span class='Count'>${Count}</span></span>    
                                <span class="text-primary fw-bold">$<span class='Total'>${Total}</span></span> 
                                <input type="hidden" value="${id}">
                                </div></div></div>`);
    TotalOrder += Total;
    $(`#TotalOrder`).text(TotalOrder);
    $(`tbody`).append(`<tr class="service">
                            <td class="tableitem"><p class="itemtext">${title}</p></td>
                            <td class="tableitem"><p class="itemtext">${Count}</p></td>
                            <td class="tableitem"><p class="itemtext">${Total}$</p></td> 
                        </tr>`);
    $("#CountInvoice").text(`${TotalOrder}$`);

    $(`#Item_${id} [type='number']`).val(1);

}
function GetCustomerName() {
     CustomerName = $(`#Name`).val();
    $("#Customer-Name").text(`Customer Name : ${CustomerName}`);

}
function AddOrder() {
    if (CustomerName == "") {
        Swal.fire({
            icon: 'error',
            title: 'Enter Customer Name',
            showConfirmButton: false,
            timer: 1500
        })
        return false;
    }
    let ItemsList = $(`#Items-Order [type="hidden"]`).map(function () {
        return $(this).val();
    }).get();
    let quantityList = $(`#Items-Order .Count`).map(function () {
        return $(this).text();
    }).get();
    let DataForm = JSON.stringify
        ({
            CustomerName: CustomerName,
            TotalOrder: TotalOrder ,
            ItemCount: ItemsList.length ,
            Items: ItemsList.toString(),
            quantity: quantityList.toString(),
        });
    $.ajax({
        url: '/Orders/AddOrder',
        type: 'POST',
        async: false,
        data: { modal:DataForm },
        success: function (result) {
            if (result) {
                Swal.fire({
                    icon: 'success',
                    title: 'Order Added successfully',
                    showConfirmButton: false,
                    timer: 1500
                });
                $(`#Name`).val('');
                $('#Items-Order , #table tbody').empty();
                $(`#TotalOrder , #CountInvoice , #Customer-Name`).text('');
            } else {
                Swal.fire({
                    icon: 'error',
                    title: result,
                    showConfirmButton: false,
                    timer: 1500
                });
            }
        },
        error: function (result) {
            Swal.fire({
                icon: 'error',
                title: 'An error occurred, try again later',
                showConfirmButton: false,
                timer: 1500
            })
        },
    });

}