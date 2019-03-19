function updateMark(value, studentId, courseId) {
    if (value == "" || value >= 6 && value <= 10) {
        var url = "/Mark/Save?value=" + value + "&studentId=" + studentId + "&courseId=" + courseId;
        $.ajax({
            type: "Post",
            url: url,
            async: true,
            success: function (data) {
                if (!data.success) {
                    alert('Something went wrong. Please, try again.');
                }
                else {
                    alert('Successfully updated student mark!');
                }
            }
        })
    }
}


