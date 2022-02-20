function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#showImage')
                .attr('src', e.target.result)
            $('#imageDiv')
                .removeClass("hidden");
            $('#saveImage')
                .removeAttr("disabled");
        };

        reader.readAsDataURL(input.files[0]);
    }
}
function showDiv() {
    debugger;
    if (document.getElementById('area').style.display == "block") {
        document.getElementById('area').style.display = "none";
    } else {
        document.getElementById('area').style.display = "block";
    }
}
function showLocation() {
    debugger;
    if (document.getElementById('location').style.display == "block") {
        document.getElementById('location').style.display = "none";
    } else {
        document.getElementById('location').style.display = "block";
    }
}