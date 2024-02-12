var dataTable;
var dataTablePending;
var dataTableSuccess;
var dataTableFail;
let minDate, maxDate;

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


    $("#btnShowWeeklySales").click(function () {
        var today = new Date();
        var startOfWeek = new Date(today);
        var endOfWeek = new Date(today);

        // Haftanın başlangıcı olan pazartesi gününe ayarla
        startOfWeek.setDate(today.getDate() - (today.getDay() + 6) % 7);
        startOfWeek.setHours(0, 0, 0, 0); // Saat bilgisini sıfırla

        // Haftanın sonu olan pazar gününe ayarla
        endOfWeek.setDate(today.getDate() + (6 - today.getDay()));
        endOfWeek.setHours(23, 59, 59, 999); // Saat bilgisini son saniyeye ayarla

        var startOfWeekFormatted = formatDate(startOfWeek);
        var endOfWeekFormatted = formatDate(endOfWeek);

        // DataTable'ı haftalık satışlarla güncelleyin
        dataTable.columns(0).search(startOfWeekFormatted + '|' + endOfWeekFormatted).draw();
    });



    // Aylık satışları göstermek için buton tıklama olayını ekleyin
    $("#btnShowMonthlySales").click(function () {
        var today = new Date();
        var lastMonth = new Date(today.getFullYear(), today.getMonth() - 1, today.getDate());
        var lastMonthFormatted = lastMonth.toISOString().split('T')[0];
        dataTable.columns(0).search(lastMonthFormatted).draw();
    });

});

function formatDate(date) {
    var dd = String(date.getDate()).padStart(2, '0');
    var mm = String(date.getMonth() + 1).padStart(2, '0');
    var yyyy = date.getFullYear();
    return yyyy + '-' + mm + '-' + dd + 'T' + 
        String(date.getHours()).padStart(2, '0') + ':' + 
        String(date.getMinutes()).padStart(2, '0') + ':' + 
        String(date.getSeconds()).padStart(2, '0');
}

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/MasterMind/client/getall' }, // Doğru controller ve action yolu
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
                        <a href="/MasterMind/client/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/MasterMind/client/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                        <a href="/MasterMind/client/QCEdit?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="QC yap"><i class="zmdi zmdi-phone"></i></a>
                        <a onClick=Delete('/MasterMind/client/Delete/${data}') class="item" data-toggle="tooltip" data-placement="top" title="Satışı sil"><i class="zmdi zmdi-delete"></i></a>

                    </div>`;
                    } else {
                        return `<div class="table-data-feature">
                        <a href="/MasterMind/client/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/MasterMind/client/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                        <a href="/MasterMind/client/QCEdit?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="QC yap"><i class="zmdi zmdi-phone"></i></a>
                        <a onClick=Delete('/MasterMind/client/Delete/${data}') class="item" data-toggle="tooltip" data-placement="top" title="Satışı sil"><i class="zmdi zmdi-delete"></i></a>
                    </div>`;
                    }
                }
            }
        ],
        "initComplete": function () {
            var table = this;

            // Min-Max tarih aralığı uygulanırken
            $("#btnApplyDateFilter").click(function () {
                var min = minDate.val();
                var max = maxDate.val();
                table.columns(0).search(min + '|' + max).draw();
            });
        }
    });
}


function loadDataTablePending() {
    dataTablePending = $('#tblDataPending').DataTable({
        "ajax": { url: '/MasterMind/client/getall' }, // Doğru controller ve action yolu
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
                        <a href="/MasterMind/client/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/MasterMind/client/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                        <a href="/MasterMind/client/QCEdit?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="QC yap"><i class="zmdi zmdi-phone"></i></a>
                        <a onClick=Delete('/MasterMind/client/Delete/${data}') class="item" data-toggle="tooltip" data-placement="top" title="Satışı sil"><i class="zmdi zmdi-delete"></i></a>

                    </div>`;
                    } else {
                        return `<div class="table-data-feature">
                        <a href="/MasterMind/client/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/MasterMind/client/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                        <a href="/MasterMind/client/QCEdit?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="QC yap"><i class="zmdi zmdi-phone"></i></a>
                        <a onClick=Delete('/MasterMind/client/Delete/${data}') class="item" data-toggle="tooltip" data-placement="top" title="Satışı sil"><i class="zmdi zmdi-delete"></i></a>
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
        "ajax": { url: '/MasterMind/client/getall' }, // Doğru controller ve action yolu
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
                        <a href="/MasterMind/client/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/MasterMind/client/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                        <a href="/MasterMind/client/QCEdit?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="QC yap"><i class="zmdi zmdi-phone"></i></a>
                        <a onClick=Delete('/MasterMind/client/Delete/${data}') class="item" data-toggle="tooltip" data-placement="top" title="Satışı sil"><i class="zmdi zmdi-delete"></i></a>

                    </div>`;
                    } else {
                        return `<div class="table-data-feature">
                        <a href="/MasterMind/client/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/MasterMind/client/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                        <a href="/MasterMind/client/QCEdit?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="QC yap"><i class="zmdi zmdi-phone"></i></a>
                        <a onClick=Delete('/MasterMind/client/Delete/${data}') class="item" data-toggle="tooltip" data-placement="top" title="Satışı sil"><i class="zmdi zmdi-delete"></i></a>
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
        "ajax": { url: '/MasterMind/client/getall' }, // Doğru controller ve action yolu
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
                        <a href="/MasterMind/client/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/MasterMind/client/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                        <a href="/MasterMind/client/QCEdit?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="QC yap"><i class="zmdi zmdi-phone"></i></a>
                        <a onClick=Delete('/MasterMind/client/Delete/${data}') class="item" data-toggle="tooltip" data-placement="top" title="Satışı sil"><i class="zmdi zmdi-delete"></i></a>

                    </div>`;
                    } else {
                        return `<div class="table-data-feature">
                        <a href="/MasterMind/client/Upsert?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Satışı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/MasterMind/client/DownloadFile?clientID=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Pdf indir"><i class="zmdi zmdi-download"></i></a>
                        <a href="/MasterMind/client/QCEdit?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="QC yap"><i class="zmdi zmdi-phone"></i></a>
                        <a onClick=Delete('/MasterMind/client/Delete/${data}') class="item" data-toggle="tooltip" data-placement="top" title="Satışı sil"><i class="zmdi zmdi-delete"></i></a>
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


