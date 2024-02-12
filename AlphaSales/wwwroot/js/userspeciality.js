
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/MasterMind/Admin/getalluserspeciality' }, // Doğru controller ve action yolu
        "columns": [
            { data: 'speciality.specialityName' },
            {
                data: 'applicationUser.name',
                "defaultContent": "" // Eğer veri yoksa boş bırak
            },
            {
                data: 'userSpeciality_id',
                render: function (data) {
                    return `<div class="table-data-feature">
                        <a href="/MasterMind/Admin/EditUserSpeciality?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="İlişkiyi Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/MasterMind/Admin/DeleteUserSpeciality?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="İlişkiyi Sil"><i class="zmdi zmdi-delete"></i></a>
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
