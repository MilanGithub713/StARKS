function AddEditCourseRecord(CourseId) {
    if (CourseId > 0) {
        var url = "/Course/GetById?id=" + CourseId;
        $("#ModalCourseTitle").html("Edit Course Record");
        $.ajax({
            type: "GET",
            url: url,
            async: true,
            success: function (data) {
                var obj = JSON.parse(data);
                $("#CourseId").val(obj.CourseId);
                $("#Name").val(obj.Name);
                $("#Code").val(obj.Code);
                $("#Description").val(obj.Description);
                document.getElementById('deleteCourseButton').style.display = 'block';
            }
        })
    }
    else {
        $("#courseForm")[0].reset();
        $("#CourseId").val(0);
        $("#ModalCourseTitle").html("Add New Course");
        document.getElementById('deleteCourseButton').style.display = 'none';
    }
}

var DeleteCourseRecord = function (CourseId) {
    $("#CourseId").val(CourseId);
}
var ConfirmationCourseDelete = function () {
    var courseId = $("#CourseId").val();
    $.ajax({
        type: "POST",
        url: "/Course/Delete?id=" + courseId,
        async: true,
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


