document.getElementById('ProgramId').onchange = function() {
    if (document.getElementById('ProgramId').value == 3) {
        document.getElementById('smartForm').style.display = "block";
    } else {
        document.getElementById('smartForm').style.display = "none";
    }
};