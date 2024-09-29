function functionConfirm(button) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: "Are you sure?",
      text: "This action cannot be undone!",
        icon: 'warning',
        showCancelButton: true,
      confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel!",
        reverseButtons: true,
        customClass: {
            popup: 'confirm-swal-popup', 
            confirmButton: 'custom-confirm-button', 
            cancelButton: 'custom-cancel-button' 
        }
    })
        .then((result) => {
        if (result.isConfirmed) {
            $(button).closest('form').submit();
        } else if (
            result.dismiss === Swal.DismissReason.cancel) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                '',
                'error'
            )
        }
    })
}