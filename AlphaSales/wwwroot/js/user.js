$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/MasterMind/admin/getall' }, // Doğru controller ve action yolu
        "columns": [
            { data: 'name' },
            { data: 'role' },
            {
                data: { id: 'id', lockoutEnd: "lockoutEnd" },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if (lockout > today) {
                        return `
                        <div class="table-data-feature">
                                <a onclick=LockUnlock('${data.id}') class="item" data-toggle="tooltip" data-placement="top" title="Kiliti Kaldır"><i class="fa fa-lock"></i></a>
                        </div>`;
                    }
                    else {
                        return `
                        <div class="table-data-feature">
                                <a onclick=LockUnlock('${data.id}') class="item" data-toggle="tooltip" data-placement="top" title="Kilitle"><i class="fa fa-unlock"></i></a>
                        </div>`;
                    }

                }
            }
        ],
        "info": false,
        "pageLength": 10, // Sayfa başına görüntülenecek satır sayısı
        "lengthChange": false, // Sayfa başına satır sayısını değiştirme seçeneğini kapatır
        "paging": true, // Sayfalama özelliğini kapatır
        "searching": false, // Arama kutusunu kapatır,
        "pagingType": "simple" // Sayfalama türünü basitleştirilmiş versiyona ayarla
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
