function updateTitle() {
    var input = document.getElementById("name");
    var title = document.getElementById("product-title");
    var value = input.value;
    if (value.length <= 13) {
        title.textContent = value;
    } else {
        var truncatedValue = value.substring(0, 10) + "...";
        title.textContent = truncatedValue;
    }
};
function updateDescription() {
    var input = document.getElementById("description");
    var title = document.getElementById("product-description");
    var value = input.value;
    if (value.length <= 31) {
        title.textContent = value;
    } else {
        var truncatedValue = value.substring(0, 30) + "...";
        title.textContent = truncatedValue;
    }
};
function changeBackground() {
    var colorPicker = document.getElementById("colorPicker");
    var block = document.getElementById("myBlock");
    // Обработчик события изменения цвета
    var selectedColor = colorPicker.value;
    block.style.backgroundColor = selectedColor;

};
function showImage() {


    var selectedglass = document.querySelector('input[name="glass"]:checked').value;
    var selectedice = document.querySelector('input[name="glass_ice"]:checked').value;
    var selectecolor = document.querySelector('input[name="color"]:checked').value;
    var coctailFolder = selectedglass + selectedice;
    var coctail = selectedglass + selectedice + selectecolor;
    var imageElement = document.getElementById("image");
    imageElement.src = "icon/glass/" + coctailFolder + "/" + coctail + ".svg"



};