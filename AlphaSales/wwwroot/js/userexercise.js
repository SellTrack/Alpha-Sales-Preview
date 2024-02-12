$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/MasterMind/Admin/getalluserexercise' },
        "columns": [
            {
                data: 'exercisePlan.exercise_Name',
                "defaultContent": "" // Eğer veri yoksa boş bırak
            },            {
                data: 'applicationUser.name',
                "defaultContent": "" // Eğer veri yoksa boş bırak
            },
            {
                data: 'userExercisePlan_id',
                render: function (data) {
                    return `<div class="table-data-feature">
                        <a href="/MasterMind/Admin/EditUserexercise?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="İlişkiyi Düzenle"><i class="zmdi zmdi-edit"></i></a>
                        <a href="/MasterMind/Admin/DeleteUserexercise?id=${data}" class="item" data-toggle="tooltip" data-placement="top" title="İlişkiyi Sil"><i class="zmdi zmdi-delete"></i></a>
                        </div>`;
                }
            }
        ],
        "searching": false,
        "lengthChange": false,
        "paging": false,
        "info": false,
        "ordering": false
    });
}
