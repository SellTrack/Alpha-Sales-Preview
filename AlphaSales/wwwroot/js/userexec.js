$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/EmployeeArea/executive/getall' }, // Doğru controller ve action yolu
        "columns": [
            { data: 'name'},
            { data: 'role'},
            { data: 'total'},
            { data: 'successful'},
            { data: 'unsuccessful'},
            { data: 'totalqc'},
            { data: 'successfulqc'},
            { data: 'unsuccessfulqc'},
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="table-data-feature">
                                <a href="/EmployeeArea/executive/rolemanagement?userId=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Düzenle"><i class="zmdi zmdi-edit"></i></a>
                            </div>`;
                },
                "width": "5%"
            }
        ]
    });
}
