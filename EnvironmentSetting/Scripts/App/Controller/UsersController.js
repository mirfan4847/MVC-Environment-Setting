var UsersController = function (usersService) {

    var showProgress = function () {
        $("#loader").show();
    };
    var hideProgress = function () {
        $("#loader").hide();
    };

    var addUser = function () {

        usersService.AddUser(param, "", addUserDone)
    }

    var getAllUsers = function () {
        debugger;
        $.ajax({
            type: "Get",
            url: "/User/GetAllUsers",

            beforeSend: function () {
                //showProgress.show();
            },
            success: function (data) {
                debugger;
                $('#AllUsersTable').html(data);
                var html = $(data).find('.login_wrapper');
                if (html.length != 0) {
                    window.location.href = "/login/login";
                }
                else {

                    $('#AllUsersTable thead .filters_1 th').each(function () {
                        var classs = $('#AllUsersTable thead tr:eq(0) th').eq($(this).index()).attr('class');
                        var title = $('#AllUsersTable thead tr:eq(0) th').eq($(this).index()).text();
                        if (title != '' && classs != 'Hhide') {
                            $(this).html('<input type="text" placeholder="Search ' + title + '" />');
                        }
                    });
                    var table = $('#AllUsersTable').DataTable({
                        // dom: 'lBfrtip',
                        "order": [],
                        columnDefs: [{ orderable: false, targets: 'no-sort' }],
                        lengthChange: true,
                        responsive: true,
                        orderCellsTop: true,
                        "pageLength": 50,
                        "bDestroy": true,
                        "sPaginationType": "full_numbers",
                        "oTableTools": {
                            "aButtons": ["copy", "xls", "pdf"]
                        }

                    });
                    if ($('#AllUsersTable').length != 0) {
                        table.columns().eq(0).each(function (colIdx) {
                            $('input', $('.filters_1 th')[colIdx]).on('keyup change', function () {
                                if (table.column(colIdx).visible()) {
                                    if (filterColIndex == 0 || filterColIndex == colIdx) {

                                        filterColIndex = colIdx;
                                        table
                                            .column(colIdx)
                                            .search(this.value)
                                            .draw();
                                    }
                                }
                            });
                        });
                    }

                }
               // hideProgress.hide();
            },
            error: function (error) {
               // hideProgress.hide();
                toastr.error(error);
            }

        });
    };

    var addUserFail = function () {

    }




    return {
        AddUser: addUser,
        GetAllUsers: getAllUsers
    };
}(UsersService);