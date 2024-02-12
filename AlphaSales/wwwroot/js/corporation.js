var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/MasterMind/corporation/getall' }, // Doğru controller ve action yolu
        "columns": [
            { data: 'name' },
            { data: 'city' },
            { data: 'adress' },
            { data: 'memberCount' },
            { data: 'totalSales' },
            { data: 'successfulSales' },
            { data: 'unsuccessfulSales' },
            {
                data: 'corporationID',
                render: function (data) {
                    return `<div class="table-data-feature">
                        <a href="/MasterMind/corporation/Edit?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Takımı Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/MasterMind/corporation/Delete?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Takımı Sil"><i class="zmdi zmdi-delete"></i></a>
                        </div>`;
                }

            }
        ],
        "searching": false, // Arama işlemini etkinleştir
        "lengthChange": false, // Show [X] entries seçeneklerini devre dışı bırak
        "paging": false, // Sayfalama işlemini devre dışı bırak
        "info": false, // Bilgi satırını devre dışı bırak
        "ordering": false // Sıralama oklarını devre dışı bırak
    });
}
