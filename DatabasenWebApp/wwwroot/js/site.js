const navbarUser = document.querySelector('.navbar-user');
const popup = navbarUser.querySelector('.popup');

let timeout;

navbarUser.addEventListener('mouseenter', () => {
    clearTimeout(timeout);
    popup.style.visibility = 'visible';
    popup.style.opacity = 1;
})

navbarUser.addEventListener('mouseleave', () => {
    timeout = setTimeout(() => {
        popup.style.opacity = 0;
        setTimeout(() => {
            popup.style.visibility = 'hidden';  // Hide it after the fade-out
        }, 300);
    }, 500)
})