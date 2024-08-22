document.addEventListener('DOMContentLoaded', () => {
    fetch('/api/businessTopics')
        .then(response => response.json())
        .then(data => {
            console.log(data);
            // içeriği güncelle
        });
});