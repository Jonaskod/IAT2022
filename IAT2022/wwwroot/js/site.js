let test = document.getElementById("test");
let checkboxlist = document.getElementsByName("checkbox");
let kresultlist = [];
kresultlist.length = checkboxlist.length;
kresultlist.fill(false);

for (let i = 0; i < checkboxlist.length; i++) {
    checkboxlist[i].addEventListener('change', function () {
        if (checkboxlist[i].checked) {
            kresultlist[i] = true;
            console.log(kresultlist[i]);
        }
        else {
            kresultlist[i] = false;
            console.log("Checkbox is not checked.")
        }
    } )
}

test.addEventListener('click', function () {
    Update();
});



function Update() {
    $(document).ready(function () {
        
            $.ajax({
                url: '/Assessment/test',
                type: 'POST',
                dataType: 'Boolean',
                data: { K1TEST, K2TEST, K3TEST, K4TEST },
                success: function (data) {

                }, error: function (data) {

                }
            });
        console.log(K1TEST)
       
    });

}
function Update() {
    $(document).ready(function () {

        $.ajax({
            url: '/Assessment/test',
            type: 'POST',
            dataType: 'Boolean',
            data: { kresultlist },
            success: function (data) {

            }, error: function (data) {

            }
        });
        console.log(K1TEST)

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