$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/LeaderBoardArea/LeaderBoard/getall', // Doğru controller ve action yolu
        },
        "columns": [
            { data: 'name', className: 'text-center' }, // İsim sütunu sağa hizalı
            { data: 'successful', className: 'text-center' } // Successful sütunu sola hizalı
        ],
        "columnDefs": [
            {
                "targets": "_all", // Tüm sütunlar için hizalama yap
                "className": "dt-center", // Sütun içeriğini ortala
            }
        ],
        "order": [[1, 'desc']],
        "searching": false, // Arama işlemini etkinleştir
        "lengthChange": false, // Show [X] entries seçeneklerini devre dışı bırak
        "paging": false, // Sayfalama işlemini devre dışı bırak
        "info": false, // Bilgi satırını devre dışı bırak
        "ordering": false // Sıralama oklarını devre dışı bırak
    });

    // Başarısız satışları gizlemek için
    dataTable.rows().every(function () {
        var data = this.data();
        var successful = data.successful;

        if (successful == 0) {
            this.nodes().to$().hide();
        }
    });

    // Yazıları daha büyük yapmak için CSS ekleyin
}
