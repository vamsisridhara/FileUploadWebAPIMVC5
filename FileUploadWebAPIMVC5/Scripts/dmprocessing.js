$(document).ready(function () {
    $.getJSON('/api/contact', function (contactsJsonPayload) {
        $(contactsJsonPayload).each(function (i, item) {
            $('#contacts').append('<li>' + item.Name + '</li>');
        });
    });
    $('#saveContact').click(function () {
        $.post("api/contact",
              $("#saveContactForm").serialize(),
              function (value) {
                  $('#contacts').append('<li>' + value.Name + '</li>');
              },
              "json"
        );
    });

    $(".lblerror").hide();
    $(".lblvalidate").hide();
    var dialog = $("#dialog-form").dialog({
        title: 'Upload Files',
        autoOpen: false,
        height: 300,
        width: 350,
        modal: true,
        buttons: {
            Cancel: function () {
                hideErrors(dialog);
            }
        },
        close: function () {
            hideErrors(dialog);
        }
    });

    function hideErrors(dialog) {
        $(".lblerror").hide();
        $(".lblvalidate").hide();
        $("#fileUpload").val('');
        dialog.dialog("close");
    }

    $('#btnAddFile').on('click', function () {
        dialog.dialog("open");
    });

    $('#btnUploadFile').on('click', function () {
        var files = $("#fileUpload").get(0).files;
        if (files.length == 0) {
            $(".lblerror").show(); return false;
        }
        var extn = $('#fileUpload').val().split('.').pop().toLowerCase();
        if ($.inArray(extn, ['txt']) == -1) {
            $(".lblerror").hide();
            $(".lblvalidate").show();
            return false;
        }
        var data = new FormData();
        var uploadedFiles = '';
        var count = 0;
        if (files.length > 0) {
            $(".lblvalidate").hide();
            $(".lblerror").hide();
            $.each(files, function (count) {
                data.append("UploadedImage" + count, files[count]);
            });
            var ajaxRequest = $.ajax({
                type: "POST",
                url: "/api/fileupload/uploadfile",
                contentType: false,
                processData: false,
                data: data
            });
            ajaxRequest.done(function (data) {
                $('#divupload').empty();
                if (data.Data != null && data.Data.length > 0) {
                    var table = $('<table id="tblfiles" border="0" width="100%"></table>');
                    for (count = 0; count < data.Data.length; count++) {
                        var deleteFileName = data.Data[count];
                        var tr = $("<tr>");
                        $('<td />', {
                            id: 'fileId' + count,
                            text: deleteFileName
                        }).appendTo(tr);
                        table.append(tr);
                    }
                    $('#divupload').append(table);
                    $("#fileUpload").val('');
                    dialog.dialog("close");
                }
            });
        }
    });
    $("#divunique").hide();
    $("#btnUnique").click(function () {
        $("#divunique").show();
        $("#divComparision").hide();
    });
    $("#btnComparision").click(function () {
        $("#divunique").hide();
        $("#divComparision").show();
    });
});