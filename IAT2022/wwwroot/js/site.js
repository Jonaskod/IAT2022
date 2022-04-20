let test = document.getElementById("test");
let checkboxlist = document.getElementsByName("checkbox");
let boolResult = [];
boolResult.length = checkboxlist.length;
boolResult.fill(false);

for (let i = 0; i < checkboxlist.length; i++) {
    checkboxlist[i].addEventListener('change', function () {
        if (checkboxlist[i].checked) {
            boolResult[i] = true;
        }
        else {
            boolResult[i] = false;
        }
        Update();
    } )
}



function Update() {
    $(document).ready(function () {

        $.ajax({
            url: '/Assessment/test',
            type: 'POST',
            dataType: 'Boolean',
            data: { boolResult },
            success: function (data) {
                
            }, error: function (data) {

            }
        });
    });
}

var slideIndex = 1;
showSlides(slideIndex);

function plusSlides(n) {
    showSlides(slideIndex += n);
}

function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
}

var myDrop = new drop({
    selector: '#myMulti'
});

