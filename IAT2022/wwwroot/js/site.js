
let K1TEST;
let K2TEST;
let K3TEST;
let K4TEST;

let checkbox1 = document.getElementById('feature1')
let checkbox2 = document.getElementById('feature2')
let checkbox3 = document.getElementById('feature3')
let checkbox4 = document.getElementById('feature4')
let test = document.getElementById('test')
let ProjectId = document.getElementById('ProjectId')


checkbox1.addEventListener('change', function () {
    if (this.checked) {
        K1TEST = true;
        console.log(K1TEST);
    } else {
        K1TEST = false;
        console.log("Checkbox is not checked..");
    }
});
checkbox2.addEventListener('change', function () {
    if (this.checked) {
        K2TEST = true;
        console.log(K1TEST);
    } else {
        K2TEST = false;
        console.log("Checkbox is not checked..");
    }
});
checkbox3.addEventListener('change', function () {
    if (this.checked) {
        K3TEST = true;
        console.log(K1TEST);
    } else {
        K3TEST = false;
        console.log("Checkbox is not checked..");
    }
});
checkbox4.addEventListener('change', function () {
    if (this.checked) {
        K4TEST = true;
        console.log(K1TEST);
    } else {
        K4TEST = false;
        console.log("Checkbox is not checked..");
    }
});


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