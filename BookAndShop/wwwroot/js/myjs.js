function AddBookClick() {
	var x = document.getElementById("animclick");
	x.style.display = 'block';

	setTimeout(function () { x.style.display = 'none'; }, 600);

}