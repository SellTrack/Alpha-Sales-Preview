
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/MasterMind/Admin/getallexercise' }, // Doğru controller ve action yolu
        "columns": [
            { data: 'exercise_Name' },
            {
                data: 'applicationUser',
                render: function (data) {
                    return data.name + ' ' + data.surname;
                }
            },
            { data: 'set_count' },
            { data: 'repeat_Count' },
            { data: 'startDate' },
            { data: 'exerciseDuration' },

            {
                data: 'exercisePlan_id',
                render: function (data) {
                    return `<div class="table-data-feature">
                        <a href="/MasterMind/Admin/EditExercise?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Egzersiz Programını Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/MasterMind/Admin/DeleteExercise?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="Egzersiz Programını Sil"><i class="zmdi zmdi-delete"></i></a>
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
