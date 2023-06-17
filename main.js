let x = document.getElementById("main-content");
let y = document.getElementById("sidebar");
y.offsetWidth = 250;
document.getElementById('menu_bars').addEventListener('click', function () {

  if (y.offsetWidth  == 250) {
    y.classList.remove('expanded');
    y.classList.add('collapse');
    y.style.width = "65px";
    x.style.marginLeft = "65px";
  } else {
    y.classList.remove('collapse');
    y.classList.add('expanded');
    x.style.marginLeft = "250px";
    y.style.width = "250px";
  }
});


// Get the container element

var btns = document.querySelectorAll(".nav-links li");
for (var i = 0; i < btns.length; i++) {
  btns[i].addEventListener("click", function () {
    if (!this.classList.contains("active")) {
      for (var i = 0; i < btns.length; i++) {
        btns[i].classList.remove('active');
      }
      this.classList.add('active');
    }
  });
}


var glide_testimonial = new Glide('.glide-testimonial', {
  type: 'carousel',
  perView: 3,
  focusAt: 2,
  gap: 40,
  autoplay: false,//default false
  hoverpause: true, //default true
  animationDuration:1000,
  breakpoints: {
    800: {
      perView: 2
    },
    480: {
      perView: 1
    }
  }
})

glide_testimonial.mount();


const checkboxes = document.querySelectorAll('input[type="checkbox"]');

checkboxes.forEach(checkbox => {
  let clickCount = 0;
  checkbox.addEventListener('click', () => {
    clickCount++;
    if (clickCount === 1) {
      checkbox.checked = true;
    } else if (clickCount === 2) {
      checkbox.checked = false;
    } else {
      checkbox.checked = false;
      clickCount = 0;
    }
  });
});