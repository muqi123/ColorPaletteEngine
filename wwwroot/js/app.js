window.util = {};
window.util.readFileBase64 = file => new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = error => reject(error);
});
window.util.readFileBase64FromId = async function (id) {
    return await window.util.readFileBase64(document.getElementById(id).files[0]);
}