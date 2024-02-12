$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/MasterMind/admin/getall' }, // Doğru controller ve action yolu
        "columns": [
            { data: 'name' },
            { data: 'role' },
            { data: 'corporation' },
            { data: 'total' },
            { data: 'successful' },
            { data: 'unsuccessful' },
            { data: 'totalqc' },
            { data: 'successfulqc' },
            { data: 'unsuccessfulqc' },
            {
                data: { id: 'id', lockoutEnd: "lockoutEnd" },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if (lockout > today) {
                        return `
                        <div class="table-data-feature">
                                <a href="/MasterMind/admin/rolemanagement?userId=${data.id}" class="item" data-toggle="tooltip" data-placement="top" title="Düzenle"><i class="zmdi zmdi-edit"></i></a>
                                <a onclick=LockUnlock('${data.id}') class="item" data-toggle="tooltip" data-placement="top" title="Kiliti Kaldır"><i class="fa fa-lock"></i></a>
                        </div>`;
                    }
                    else {
                        return `
                        <div class="table-data-feature">
                                <a href="/MasterMind/admin/rolemanagement?userId=${data.id}" class="item" data-toggle="tooltip" data-placement="top" title="Düzenle"><i class="zmdi zmdi-edit"></i></a>
                                <a onclick=LockUnlock('${data.id}') class="item" data-toggle="tooltip" data-placement="top" title="Kilitle"><i class="fa fa-unlock"></i></a>
                        </div>`;
                    }

                },
                "width": "5%"
            }
        ]
    });
}

function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/MasterMind/Admin/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
    });
}



