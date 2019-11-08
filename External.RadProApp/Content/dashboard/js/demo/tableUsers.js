// Call the dataTables jQuery plugin
$(document).ready(function () {
    var productsTable = $('#tblUsers').DataTable({
        responsive: {
            details: {
                display: $.fn.dataTable.Responsive.display.childRowImmediate
            }
        },
        columnDefs: [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 }
        ],

        initComplete: function () {
            this.api().columns([1]).every(function () {
                var column = this;
                var select = $('<select data-size="5" data-live-search="true"><option value="">Sort (All)</option></select>')
                    .appendTo("#table").end()
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                column.cells('', column[0]).render('display').sort().unique().each(function (d, j) {
                    if (column.search() === '^' + d + '$') {
                        select.append('<option value="' + d + '" selected="selected">' + d + '</option>')
                    } else {
                        select.append('<option value="' + d + '">' + d + '</option>')
                    }
                });
            });
        },

        "bJqueryUI": true,
        "bPaginate": true,
        "aaSorting": [[1, 'asc']],
        "aoPreSearchCols": [[1]],


        lengthMenu: [
            [3, 9, 12, 1000],
            ['3', '9', '12', 'all']
        ],

        "language": {
            "lengthMenu": "Display _MENU_ records per page",
            "zeroRecords": "User Accounts",
            "info": "Showing page _PAGE_ of _PAGES_",
            "infoEmpty": "Radio Antenna Developers has returned 0 Results.",
            "infoFiltered": "(filtered from _MAX_ total records)"
        }
    });
});