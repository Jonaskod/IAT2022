
let K1TEST;
let checkbox1 = document.getElementById('feature1')
let test = document.getElementById('test')
let bajs;

checkbox1.addEventListener('change', function () {
    if (this.checked) {
        K1TEST = true;
        console.log(K1TEST);
    } else {
        K1TEST = false;
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
                data: { K1TEST },
                success: function (data) {

                }, error: function (data) {

                }
            });
       
    });
}