var dataTable;
var dataTablePending;
var dataTableSuccess;
var dataTableFail;

$(document).ready(function () {
    loadDataTable();
    loadDataTablePending();
    loadDataTableSuccess();
    loadDataTableFail();


    $("#btnShowTodaysSales").click(function () {
        // Bugünkü tarih için bir dize oluşturun
        var today = new Date();
        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth() + 1).padStart(2, '0'); // Ocak 0 ile başladığı için +1 ekliyoruz
        var yyyy = today.getFullYear();
        today = yyyy + '-' + mm + '-' + dd;

        var searchResult = dataTable.columns(0).search(today).draw();
        console.log("Arama Sonucu:", searchResult.data());


        dataTable.columns(0).search(today).draw();
    });

    $("#btnShowAllSales").click(function () {
        dataTable.columns(0).search('').draw();
    });

    function onDataTableUpdate() {
        var tableData = dataTable.rows().data();
        console.log(tableData);

        // Burada haftalık veya aylık satışları işlemek veya filtrelemek için kodunuzu ekleyebilirsiniz.
    }

});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/EmployeeArea/Employee/getall' }, // Doğru controller ve action yolu
        "columns": [
            { data: 'client_insert_date'},
            { data: 'client_order_number' },
            { data: 'client_tariff_type' },
            {
                data: 'applicationUser.name',
                "defaultContent": "" // Eğer veri yoksa boş bırak
            },
            {
                data: 'corporation.name',
                "defaultContent": "" // Eğer veri yoksa boş bırak
            },
            {
                data: 'client_status',
                "render": function (data) {
                    if (data === 0) {
                        return "Değerlendirilmedi";
                    } else if (data === 1) {
                        return "Başarılı";
                    } else if (data === 2) {
                        return "Başarısız";
                    } else {
                        return "Bilinmeyen"; // Diğer durumlar için varsayılan metin
                    }
                }
            },
            { data: 'client_Description' },
            { data: 'client_QC_Description' },
            { data: 'applicationUser2.name' },
            {
                data: 'clientID',
                "render": function (data, type, row) {
                    if (row.client_status === 1 || row.client_status === 2) {
                        return `<div class="table-data-feature">
                        <a href="/EmployeeArea/Employee/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/EmployeeArea/Employee/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                       
                    </div>`;
                    } else {
                        return `<div class="table-data-feature">
                        <a href="/EmployeeArea/Employee/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/EmployeeArea/Employee/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                        <a onClick=Delete('/EmployeeArea/Employee/Delete/${data}') class="item" data-toggle="tooltip" data-placement="top" title="Satışı sil"><i class="zmdi zmdi-delete"></i></a>
                    </div>`;
                    }
                }
            }
        ]
    });
}


function loadDataTablePending() {
    dataTablePending = $('#tblDataPending').DataTable({
        "ajax": { url: '/EmployeeArea/Employee/getall' }, // Doğru controller ve action yolu
        "columns": [
            { data: 'client_insert_date' },
            { data: 'client_order_number' },
            { data: 'client_tariff_type' },
            {
                data: 'applicationUser.name',
                "defaultContent": "" // Eğer veri yoksa boş bırak
            },
            {
                data: 'corporation.name',
                "defaultContent": "" // Eğer veri yoksa boş bırak
            },
            {
                data: 'client_status',
                "render": function (data) {
                    if (data === 0) {
                        return "Değerlendirilmedi";
                    } else if (data === 1) {
                        return "Başarılı";
                    } else if (data === 2) {
                        return "Başarısız";
                    } else {
                        return "Bilinmeyen"; // Diğer durumlar için varsayılan metin
                    }
                }
            },
            { data: 'client_Description' },
            { data: 'client_QC_Description' },
            { data: 'applicationUser2.name' },
            {
                data: 'clientID',
                "render": function (data, type, row) {
                    if (row.client_status === 1 || row.client_status === 2) {
                        return `<div class="table-data-feature">
                        <a href="/EmployeeArea/Employee/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/EmployeeArea/Employee/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                    </div>`;
                    } else {
                        return `<div class="table-data-feature">
                        <a href="/EmployeeArea/Employee/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/EmployeeArea/QCEmployee/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                        <a onClick=Delete('/EmployeeArea/Employee/Delete/${data}') class="item" data-toggle="tooltip" data-placement="top" title="Satışı sil"><i class="zmdi zmdi-delete"></i></a>
                    </div>`;
                    }
                }
            }
        ]
    });

dataTablePending.columns(5).search('Değerlendirilmedi').draw();

}



function loadDataTableSuccess() {
    dataTableSuccess = $('#tblDataSuccess').DataTable({
        "ajax": { url: '/EmployeeArea/Employee/getall' }, // Doğru controller ve action yolu
        "columns": [
            { data: 'client_insert_date' },
            { data: 'client_order_number' },
            { data: 'client_tariff_type' },
            {
                data: 'applicationUser.name',
                "defaultContent": "" // Eğer veri yoksa boş bırak
            },
            {
                data: 'corporation.name',
                "defaultContent": "" // Eğer veri yoksa boş bırak
            },
            {
                data: 'client_status',
                "render": function (data) {
                    if (data === 0) {
                        return "Değerlendirilmedi";
                    } else if (data === 1) {
                        return "Başarılı";
                    } else if (data === 2) {
                        return "Başarısız";
                    } else {
                        return "Bilinmeyen"; // Diğer durumlar için varsayılan metin
                    }
                }
            },
            { data: 'client_Description' },
            { data: 'client_QC_Description' },
            { data: 'applicationUser2.name' },
            {
                data: 'clientID',
                "render": function (data, type, row) {
                    if (row.client_status === 1 || row.client_status === 2) {
                        return `<div class="table-data-feature">
                        <a href="/EmployeeArea/Employee/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/EmployeeArea/Employee/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                    </div>`;
                    } else {
                        return `<div class="table-data-feature">
                        <a href="/EmployeeArea/Employee/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/EmployeeArea/Employee/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                        <a onClick=Delete('/EmployeeArea/QCEmployee/Delete/${data}') class="item" data-toggle="tooltip" data-placement="top" title="Satışı sil"><i class="zmdi zmdi-delete"></i></a>
                    </div>`;
                    }
                }
            }
        ]
    });

    dataTableSuccess.columns(5).search('Başarılı').draw();

}

function loadDataTableFail() {
    dataTableFail = $('#tblDataFail').DataTable({
        "ajax": { url: '/EmployeeArea/Employee/getall' }, // Doğru controller ve action yolu
        "columns": [
            { data: 'client_insert_date' },
            { data: 'client_order_number' },
            { data: 'client_tariff_type' },
            {
                data: 'applicationUser.name',
                "defaultContent": "" // Eğer veri yoksa boş bırak
            },
            {
                data: 'corporation.name',
                "defaultContent": "" // Eğer veri yoksa boş bırak
            },
            {
                data: 'client_status',
                "render": function (data) {
                    if (data === 0) {
                        return "Değerlendirilmedi";
                    } else if (data === 1) {
                        return "Başarılı";
                    } else if (data === 2) {
                        return "Başarısız";
                    } else {
                        return "Bilinmeyen"; // Diğer durumlar için varsayılan metin
                    }
                }
            },
            { data: 'client_Description' },
            { data: 'client_QC_Description' },
            { data: 'applicationUser2.name' },
            {
                data: 'clientID',
                "render": function (data, type, row) {
                    if (row.client_status === 1 || row.client_status === 2) {
                        return `<div class="table-data-feature">
                        <a href="/EmployeeArea/Employee/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/EmployeeArea/Employee/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                    </div>`;
                    } else {
                        return `<div class="table-data-feature">
                        <a href="/EmployeeArea/Employee/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/EmployeeArea/Employee/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                        <a onClick=Delete('/EmployeeArea/Employee/Delete/${data}') class="item" data-toggle="tooltip" data-placement="top" title="Satışı sil"><i class="zmdi zmdi-delete"></i></a>
                    </div>`;
                    }
                }
            }
        ]
    });

    dataTableFail.columns(5).search('Başarısız').draw();

}

function Delete(url) {
    Swal.fire({
        title: 'Silmek istediğinizden emin misiniz?',
        text: "Bu işlem geri alınamayacaktır!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'İptal',
        confirmButtonText: 'Sil gitsin!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}


