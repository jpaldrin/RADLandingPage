$(document).ready(function () {
    var sitetable = $('#siteIndex').DataTable({
        processing: true,
        serverSide: false,
        ordering: true,
        paging: true,
        searching: true,
        ajax: "../api/getsite",
        columns: [
            { "data": "siteId" },
            { "data": "name" },
            { "data": "category" },
            { "data": "appNo" },
            { "data": "address" },
            { "data": "city" },
            { "data": "state" },
            { "data": "post" },
            { "data": "status" },
            { "data": "version" },
            { "data": "projectType" },
            { "data": "approvedBy" },
            { "data": "lastModified" },
            { "data": "lastModifiedBy" },
            { "data": "siteClass" },
            { "data": "siteType" },
            { "data": "planYear" },
            { "data": "market" },
            { "data": "vendor" },
            { "data": "region" },
            { "data": "latitude" },
            { "data": "longitude" },
            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a class="editButton btn btn-link btn-sm" href="/Site/Manager/' + data.siteId + '"> Manage </a>' +
                        '<a id="editSite" class="deleteButton btn btn-link btn-sm text-success" href="/Site/Edit/' + data.siteId + '"> Edit </a>' +
                        '<a id="deleteSite" class="deleteButton btn btn-link btn-sm text-danger" href="/Site/Delete/' + data.siteId + '"> Delete </a>';
                }
            },
        ],
        dom: 'Bfrtip',
        buttons: [
            {
                text: 'Create',
                className: 'data-create',
                toggleAttr: 'modal',
                targetAttr: '#createNewSite'
            },
            {
                extend: 'copyHtml5',
                text: '<i class="fa fa-files-o"></i>',
                titleAttr: 'Copy'
            },
            {
                extend: 'excelHtml5',
                text: '<i class="fa fa-success fa-file-excel-o"></i>',
                titleAttr: 'Excel'
            },
            {
                extend: 'csvHtml5',
                text: '<i class="fa fa-file-text-o"></i>',
                titleAttr: 'CSV'
            }
        ],
        columnDefs: [{
            id: '#delete',
            className: 'select-checkbox',
            targets: 0
        }],
        select: {
            style: 'os',
            selector: 'td:first-child'
        },
        order: [[1, 'asc']],
        initComplete: function () {
            this.api().columns([8]).every(function () {
                var column = this;
                var select = $('<select class="bootstrap-select" ><option value="">Sort (All)</option></select>')
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
        }
    });

    $('#siteIndex').on('init.dt', function () {
        $('.data-create')
            .attr('data-toggle', 'modal')
            .attr('data-target', '#createNewSite');
    });

    $('form[id="#createNewSite"]').validate({
        rules: {
            name: 'required',
            city: 'required',
        },
        messages: {
            nsme: 'This field is required',
            city: 'This field is required',
        }
    });

    $('#btnAdd').on('click', function (e) {
        $.ajax({
            url: '../api/siteapi',
            method: 'POST',
            data: {
                name: $('#name').val(),
                category: $('#category').val(),
                appNo: $('#appno').val(),
                address: $('#address').val(),
                city: $('#city').val(),
                state: $('#state').val(),
                post: $('#post').val(),
                status: $('#status').val(),
                version: $('#version').val(),
                projecttype: $('#projecttype').val(),
                approvedby: $('#approvedby').val(),
                siteclass: $('#siteclass').val(),
                sitetype: $('#sitetype').val(),
                planyear: $('#planyear').val(),
                market: $('#market').val(),
                vendor: $('#vendor').val(),
                region: $('#region').val(),
                latitude: $('#latitude').val(),
                longitude: $('#longitude').val()
            },
            success: function () {
                $('#createNewSite').modal('hide');
                Swal.fire({
                    position: 'top-end',
                    type: 'success',
                    title: 'A new site was created!',
                    showConfirmButton: true,
                })
                location.reload();
            },
            error: function (jqXHR) {
                Swal.fire({
                    position: 'top-end',
                    type: 'error',
                    title: jqXHR.responseText,
                    showConfirmButton: true,
                })
            }
        });
    });
    $('#btnClear').on('click', function (e) {
        $("#createSiteForm :text").val("");
        //$("#container select").empty();
    });
  
});
