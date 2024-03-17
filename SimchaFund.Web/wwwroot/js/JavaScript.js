


$(() => {

    console.log('clicked')
    $("#show-modal").on('click', function () {
        console.log('clicked on add')
        new bootstrap.Modal($(".add")[0]).show()
        console.log('should show')
    })
})


