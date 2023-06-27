function sortAlcohol() {
    var sortType = document.getElementById('sort').value;
    var list = document.getElementById('alcoholList');
    var items = Array.from(list.getElementsByTagName('li'));

    items.sort(function (a, b) {
        var nameA = a.querySelector('.text-title').innerText;
        var nameB = b.querySelector('.text-title').innerText;
        var degreeA = parseFloat(a.querySelector('.degree').getAttribute('data-degree'));
        var degreeB = parseFloat(b.querySelector('.degree').getAttribute('data-degree'));

        if (sortType === '1') {
            // Сортировка от A до Z
            return nameA.localeCompare(nameB);
        } else if (sortType === '2') {
            // Сортировка от Z до A
            return nameB.localeCompare(nameA);
        } else if (sortType === '3') {
            return degreeA - degreeB;
        } else {
            return degreeB - degreeA;
        }
        // Добавьте другие варианты сортировки, если необходимо

        return 0; // По умолчанию не менять порядок элементов
    });

    // Удалите существующие элементы из списка
    while (list.firstChild) {
        list.firstChild.remove();
    }

    // Добавьте отсортированные элементы в список
    items.forEach(function (item) {
        list.appendChild(item);
    });
}