function on() {
    document.getElementById("overlay").style.display = "block";
}
function off() {
    document.getElementById("overlay").style.display = "none";
}
function informationRecieved() {
    document.getElementById("informationMessage").style.display = "none";
}
function showHelp() {
    document.getElementById("helpInformation").style.display = "block";
}
function closeHelp() {
    document.getElementById("helpInformation").style.display = "none";
}
function showCustomer() {
    document.getElementById("CustomerQuestionChanger").style.display = "block";
}
function showProduct() {
    document.getElementById("ProductQuestionChanger").style.display = "block";
}
function showIPR() {
    document.getElementById("IPRQuestionChanger").style.display = "block";
}
function showTeam() {
    document.getElementById("TeamQuestionChanger").style.display = "block";
}
function showBusiness() {
    document.getElementById("BusinessQuestionChanger").style.display = "block";
}
function showFinance() {
    document.getElementById("FinanceQuestionChanger").style.display = "block";
}
function closeAllCategories() {
    document.getElementById("CustomerQuestionChanger").style.display = "none";
    document.getElementById("ProductQuestionChanger").style.display = "none";
    document.getElementById("IPRQuestionChanger").style.display = "none";
    document.getElementById("TeamQuestionChanger").style.display = "none";
    document.getElementById("BusinessQuestionChanger").style.display = "none";
    document.getElementById("FinanceQuestionChanger").style.display = "none";
}
function displaySearch() {

    let checkBoxName = document.getElementById("checkBoxName");
    let checkBoxTag = document.getElementById("checkBoxTag");


    if (checkBoxName.checked == true) {
        let searchNameDiv = document.getElementById("searchNameDiv").style.display = "block";
    }
    else {
        let searchNameDiv = document.getElementById("searchNameDiv").style.display = "none";
    }
    if (checkBoxTag.checked == true) {
        let tagSearchDiv = document.getElementById("tagSearchDiv").style.display = "block";
    }
    else {
        let tagSearchDiv = document.getElementById("tagSearchDiv").style.display = "none";
    }
}
