//Add
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
});//GetAllRecords
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
                row += '<tr><td  class=id> ' + obj.contactID + ' </td> <td contenteditable="true" class=fn> ' + obj.firstName + ' </td> <td contenteditable="true"class=ln>' + obj.lastName + '</td> <td contenteditable="true"class=email>' + obj.email + '</td><td contenteditable="true" class=emailT  >' + obj.emailT + '</td><td>' + '<button type="button"  onclick="buttonDelete(this)">Delete</button>' + '</td><td>' + '<button type="button"  onclick="buttonUpdate(this)">Update</button>' + '</td><td class=idE hidden="hidden">' + obj.emailID + '</td></tr>';

            }); $("#Details").append(row);
        }
    });
});//Delete
function buttonDelete(e) {
    var id = $(e).closest('tr').find('.id').text();
    $(e).closest('tr').remove();
    var data = {
        ContactID: id
    };
    $.ajax({
        url: '/api/ContactAndEmail/Delete',
        headers: {
            'Content-Type': 'application/json'
        },
        method: 'Post',
        dataType: 'json',
        data: JSON.stringify(data),
        success: function (data) {
            console.log('succes: ' + data);
        }
    });
}//Update
function buttonUpdate(e) {
    var idE = $(e).closest('tr').find('.idE').text();
    var id = $(e).closest('tr').find('.id').text();
    var fn = $(e).closest('tr').find('.fn').text();
    var ln = $(e).closest('tr').find('.ln').text();
    var email = $(e).closest('tr').find('.email').text();
    var emailT = $(e).closest('tr').find('.emailT').text();
    var data = {
        EmailID: idE,
        ContactID: id,
        EmailAddress: email,
        FirstName: fn,
        LastName: ln,
        Email: email,
        EmailType: emailT
    };
    $.ajax({
        url: '/api/ContactAndEmail/Update',
        headers: {
            'Content-Type': 'application/json'
        },
        method: 'Post',
        dataType: 'json',
        data: JSON.stringify(data),
        success: function (data) {
            console.log('succes: ' + data);
        }
    });
}
