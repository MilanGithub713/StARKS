function openInformation(starks) {
    $(this).closest('.nav').find('.active').removeClass('active');
    $(event.target).addClass('active');
    var i;
    var x = document.getElementsByClassName("starks");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    document.getElementById(starks).style.display = "block";
}
window.onload = function () {
    var selectedTab = localStorage.getItem('selectedTab');
    if (selectedTab != null) {
        $('a[data-toggle="tab"][href="' + selectedTab + '"]').tab('show');
    }
}

$('a[data-toggle="tab"]').click(function (e) {
    e.preventDefault();
    $(this).tab('show');
});

$('a[data-toggle="tab"]').on("shown.bs.tab", function (e) {
    var id = $(e.target).attr("href");
    localStorage.setItem('selectedTab', id)
    document.getElementById(id).style.display = "block";
});



