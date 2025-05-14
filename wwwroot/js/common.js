function ShowConfirmationModal() {
    debugger;
    console.log(document.getElementById('bsConfirmationModal')); 
    bootstrap.Modal.getOrCreateInstance(document.getElementById('bsConfirmationModal')).show();
}

function HideConfirmationModal() {
    bootstrap.Modal.getOrCreateInstance(document.getElementById('bsConfirmationModal')).hide();
}