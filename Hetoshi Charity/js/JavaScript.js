<div id="fb-root"></div>

function fbJS(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
                    if (d.getElementById(id)) return;
                    js = d.createElement(s); js.id = id;
                    js.src = 'https://connect.facebook.net/en_US/sdk.js#xfbml=1&version=v3.0';
                    fjs.parentNode.insertBefore(js, fjs);
            }(document, 'script', 'facebook-jssdk');

<div id="jsLogin"></div>
    var modal = document.getElementById('jsLogin');

    window.onclick = function (event) {
        if (event.target !== modal) {
            modal.style.display = "none";
        }
    };

<div id="jsNewVisitor"></div>
    var modal = document.getElementById('jsNewVisitor');

    window.onclick = function (event) {
        if (event.target !== modal) {
            modal.style.display = "none";
        }
    };

<div id="hamburgerNavMenu"></div>



//<div id="jsRestration"></div>
//var modalReg = document.getElementById('jsRegister');

//window.onclick = function (event) {
//    if (event.target != modalReg) {
//        modal.style.display = "none"
//    }
//};

