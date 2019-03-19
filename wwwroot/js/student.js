{
    function AddEditStudentRecord(StudentId) {
        if (StudentId > 0) {
            var url = "/Student/GetById?id=" + StudentId;
            $("#ModalTitle").html("Edit Student Record");
            $.ajax({
                type: "GET",
                url: url,
                async: true,
                success: function (data) {
                    var obj = JSON.parse(data);
                    dateReviver(obj.DateOfBirth);
                    $("#StudentId").val(obj.StudentId);
                    $("#FirstName").val(obj.FirstName);
                    $("#LastName").val(obj.LastName);
                    $("#Address").val(obj.Address);
                    $("#City").val(obj.City);
                    $("#State").val(obj.State);
                    $("#DateOfBirth").val(dateReviver(obj.DateOfBirth));
                    $("#Gender").val(obj.Gender);
                    document.getElementById('deleteStudentButton').style.display = 'block';
                }
            })
        }
        else {
            $("#form")[0].reset();
            $("#StudentId").val(0);
            $("#ModalTitle").html("Add New Student");
            document.getElementById('deleteStudentButton').style.display = 'none';
        }
    }

    var DeleteStudentRecord = function (StudentId) {
        $("#StudentId").val(StudentId);
    }

    var ConfirmationStudentDelete = function () {
        var StuId = $("#StudentId").val();
        $.ajax({
            type: "POST",
            async: true,
            url: "/Student/Delete?id=" + StuId,
            success: function (result) {
                if (result.success) {
                    location.reload();
                }
                else {
                    alert('Something went wrong. Please, try again.');
                }
            }
        })
    }

    function dateReviver(value) {
        if (typeof value === 'string') {
            var arayDate = /^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2}(?:\.\d*)?)(?:([\+-])(\d{2})\:(\d{2}))?Z?$/.exec(value);
            if (arayDate) {
                value = arayDate[1] + "-" + arayDate[2] + "-" + arayDate[3]
            }
        }
        return value;
    }
}
