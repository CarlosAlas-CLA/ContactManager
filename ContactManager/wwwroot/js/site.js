$(document).ready(function () {
    $("#buttonSubmit").click(function (e) {
        var fn = document.forms["myForm"]["fn"].value;
        var ln = document.forms["myForm"]["ln"].value;
        var email = document.forms["myForm"]["email"].value;
        var emailT = document.forms["myForm"]["emailT"].value;
        var data = {
            ContactID: 0,
            EmailAddresses: '',
            FirstName: fn,
            LastName: ln,
            Email: email,
            EmailType: emailT
        };
        $.ajax({
            url: '/api/ContactAndEmail/Post',
            headers: {
                'Content-Type': 'application/json'
            },
            method: 'Post',
            dataType: 'json',
            data: JSON.stringify(data),
            success: function (data) {
                var row = '';
                $.each(data, function (index, obj) {
                    row += '<tr><td> ' + obj.contactID + ' </td> <td> ' + obj.firstName + ' </td> <td>' + obj.lastName + '</td> <td>' + obj.email + '</td><td>' + obj.emailT + '</td> </tr>';
                }); $("#Details").append(row);
                console.log('succes: ' + data);
            }
        });
    });
});
$(document).ready(function () {
    var data = [];
    $.ajax({
        method: 'Get',
        url: '/api/ContactAndEmail/GetAllRecords',
        dataType: 'json',
        data: JSON.stringify(data),
        success: function (data) {
            var row = '';
            $.each(data, function (index, obj) {
                row += '<tr><td> ' + obj.contactID + ' </td> <td> ' + obj.firstName + ' </td> <td>' + obj.lastName + '</td> <td>' + obj.email + '</td><td>' + obj.emailT + '</td> </tr>';
            }); $("#Details").append(row);
        }
    });
});