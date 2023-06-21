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
function previewImage(event) {
    const file = event.target.files[0];
    const reader = new FileReader();

    reader.onload = function (e) {
        const imagePreview = document.getElementById('myBlock');
        imagePreview.innerHTML = `<img src="${e.target.result}" alt="Preview" />`;
    };

    reader.readAsDataURL(file);
}