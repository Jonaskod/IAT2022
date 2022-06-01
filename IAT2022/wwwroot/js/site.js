let test = document.getElementById("test");
let checkboxlistCustomer = document.getElementsByName("checkboxCustomer");
let boolResultCustomer = [];
boolResultCustomer.length = checkboxlistCustomer.length;
boolResultCustomer.fill(false);

let checkboxlistProduct = document.getElementsByName("checkboxProduct");
let boolResultProduct = [];
boolResultProduct.length = checkboxlistProduct.length;
boolResultProduct.fill(false);

let checkboxlistTeam = document.getElementsByName("checkboxTeam");
let boolResultTeam = [];
boolResultTeam.length = checkboxlistTeam.length;
boolResultTeam.fill(false);

let checkboxlistIPR = document.getElementsByName("checkboxIPR");
let boolResultIPR = [];
boolResultIPR.length = checkboxlistIPR.length;
boolResultIPR.fill(false);

let checkboxlistFinance = document.getElementsByName("checkboxFinance");
let boolResultFinance = [];
boolResultFinance.length = checkboxlistFinance.length;
boolResultFinance.fill(false);

let checkboxlistBusiness = document.getElementsByName("checkboxBusiness");
let boolResultBusiness = [];
boolResultBusiness.length = checkboxlistBusiness.length;
boolResultBusiness.fill(false);

let nextButton = document.getElementById("nextBtn");
let prevButton = document.getElementById("prevBtn");

$("input:radio").on("click", function (e) {
    var inp = $(this); //cache the selector
    if (inp.is(".theone")) { //see if it has the selected class
        inp.prop("checked", false).removeClass("theone");
        return;
    }
    $("input:radio[name='" + inp.prop("name") + "'].theone").removeClass("theone");
    inp.addClass("theone");
});

$("textarea").each(function () {
    this.setAttribute("style", "height:" + (this.scrollHeight) + "px;overflow-y:hidden;");
}).on("input", function () {
    this.style.height = "auto";
    this.style.height = (this.scrollHeight) + "px";
});


for (let i = 0; i < checkboxlistBusiness.length; i++) {
    checkboxlistBusiness[i].addEventListener('change', function () {
        console.log(boolResultBusiness);
        if (checkboxlistBusiness[i].checked) {
            boolResultBusiness[i] = true;
        }
        else {
            boolResultBusiness[i] = false;
        }
        UpdateBusiness();
    })
}
for (let i = 0; i < checkboxlistBusiness.length; i++) {
    console.log(checkboxlistBusiness[i].checked)
    if (checkboxlistBusiness[i].checked) {
        boolResultBusiness[i] = true;
    }

}

function UpdateBusiness() {
    $(document).ready(function () {

        $.ajax({
            url: '/Assessment/BusinessResult',
            type: 'POST',
            dataType: 'Boolean',
            data: { boolResultBusiness },
            success: function (data) {

            }, error: function (data) {

            }
        });
    });
}

for (let i = 0; i < checkboxlistFinance.length; i++) {
    checkboxlistFinance[i].addEventListener('change', function () {
        console.log(boolResultFinance);
        if (checkboxlistFinance[i].checked) {
            boolResultFinance[i] = true;
        }
        else {
            boolResultFinance[i] = false;
        }
        UpdateFinance();
    })
}
for (let i = 0; i < checkboxlistFinance.length; i++) {
    console.log(checkboxlistFinance[i].checked)
    if (checkboxlistFinance[i].checked) {
        boolResultFinance[i] = true;
    }

}

function UpdateFinance() {
    $(document).ready(function () {

        $.ajax({
            url: '/Assessment/FinanceResult',
            type: 'POST',
            dataType: 'Boolean',
            data: { boolResultFinance },
            success: function (data) {

            }, error: function (data) {

            }
        });
    });
}

for (let i = 0; i < checkboxlistIPR.length; i++) {
    checkboxlistIPR[i].addEventListener('change', function () {
        console.log(boolResultIPR);
        if (checkboxlistIPR[i].checked) {
            boolResultIPR[i] = true;
        }
        else {
            boolResultIPR[i] = false;
        }
        UpdateIPR();
    })
}
for (let i = 0; i < checkboxlistIPR.length; i++) {
    console.log(checkboxlistIPR[i].checked)
    if (checkboxlistIPR[i].checked) {
        boolResultIPR[i] = true;
    }

}

function UpdateIPR() {
    $(document).ready(function () {

        $.ajax({
            url: '/Assessment/IprResult',
            type: 'POST',
            dataType: 'Boolean',
            data: { boolResultIPR },
            success: function (data) {

            }, error: function (data) {

            }
        });
    });
}

for (let i = 0; i < checkboxlistTeam.length; i++) {
    checkboxlistTeam[i].addEventListener('change', function () {
        console.log(boolResultTeam);
        if (checkboxlistTeam[i].checked) {
            boolResultTeam[i] = true;
        }
        else {
            boolResultTeam[i] = false;
        }
        UpdateTeam();
    })
}
for (let i = 0; i < checkboxlistTeam.length; i++) {
    console.log(checkboxlistTeam[i].checked)
    if (checkboxlistTeam[i].checked) {
        boolResultTeam[i] = true;
    }

}

function UpdateTeam() {
    $(document).ready(function () {

        $.ajax({
            url: '/Assessment/TeamResult',
            type: 'POST',
            dataType: 'Boolean',
            data: { boolResultTeam },
            success: function (data) {

            }, error: function (data) {

            }
        });
    });
}

for (let i = 0; i < checkboxlistProduct.length; i++) {
    checkboxlistProduct[i].addEventListener('change', function () {
        console.log(boolResultProduct);
        if (checkboxlistProduct[i].checked) {
            boolResultProduct[i] = true;
        }
        else {
            boolResultProduct[i] = false;
        }
        UpdateProduct();
    })
}
for (let i = 0; i < checkboxlistProduct.length; i++) {
    console.log(checkboxlistProduct[i].checked)
    if (checkboxlistProduct[i].checked) {
        boolResultProduct[i] = true;
    }

}

function UpdateProduct() {
    $(document).ready(function () {

        $.ajax({
            url: '/Assessment/ProdutResult',
            type: 'POST',
            dataType: 'Boolean',
            data: { boolResultProduct },
            success: function (data) {

            }, error: function (data) {

            }
        });
    });
}



for (let i = 0; i < checkboxlistCustomer.length; i++) {
    checkboxlistCustomer[i].addEventListener('change', function () {
        console.log(boolResultCustomer);
        if (checkboxlistCustomer[i].checked) {
            boolResultCustomer[i] = true;
        }
        else {
            boolResultCustomer[i] = false;
        }
        Update();
    } )
}
for (let i = 0; i < checkboxlistCustomer.length; i++) {
    console.log(checkboxlistCustomer[i].checked)
    if (checkboxlistCustomer[i].checked) {
        boolResultCustomer[i] = true;
    }
    
}

function Update() {
    $(document).ready(function () {

        $.ajax({
            url: '/Assessment/test',
            type: 'POST',
            dataType: 'Boolean',
            data: { boolResultCustomer },
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
    var counter = document.getElementById("pageCounter");
    let slideCounter = n;

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
    disableNextBtn(n);
    disablePrevBtn(n);
    counter.innerHTML = slideCounter + "/" + "3";
}
function disableNextBtn(x) {
    if (x >= 3) {
        nextButton.disabled = true;
    }
    else {
        nextButton.disabled = false;
    }
}
function disablePrevBtn(x) {
    if (x <= 1) {
        prevButton.disabled = true;
    }
    else {
        prevButton.disabled = false;
    }
}

var myDrop = new drop({
    selector: '#myMulti'
});
function showPdfSuggestions() {
    document.getElementById("pdfSuggestions").style.display = "block";
}
function closePdfSuggestions() {
    document.getElementById("pdfSuggestions").style.display = "none";
}
function pdfDownload() {
    var element = document.getElementById('assessmentPage');
    let aTags = document.getElementsByTagName("a");
    let atl = aTags.length;
    for (i = 0; i < atl; i++) {
        aTags[i].removeAttribute("href"); //Removes href from <a>
    }
    html2pdf(element);
    setTimeout(() => { location.reload(); }, 2000);
}


