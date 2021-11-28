
    function addCart(id) {
        $("#imgCart").attr("src", '/image/cartA.png');
            $("#imgBusy_" + id).show();
            setTimeout(function () {
        $("#imgBusy_" + id).hide();
            }, 500);
    }

function delCart(id) {
    $("#imgCart").attr("src", '/image/cart.png');
    $("#tr_" + id).hide();
    }

    function clearCart() {
        $("#imgCart").attr("src", '/image/cart.png');
    }
    function refreshMenu(obj)
    {
        //$("#imgCart").attr("src", '/image/cart.png');
        if (obj != "") {
            var html = '<li class="nav-item"><a class="nav-link text-dark" id="information" href="/Info">Hello ' + obj.email + '! | </a></li>';
            html += '<li class="nav-item"><a class="nav-link text-dark" id="history" href="/History">Đơn hàng | </a></li>'
            html += '<li class="nav-item"><a class="nav-link text-dark" id="logout" href="/Logout">Logout | </a></li>';
            document.getElementById('navLogin').outerHTML = html;
            //$("#navLogin").html(html);

        }
        else {
            var html = '<li class="nav-item">';
            html += '<a class="nav-link text-dark" id="register" href="/Register">Đăng ký</a></li>';
            html += '<li class="nav-item"><a class="nav-link text-dark" id="login" href="/Login">Đăng nhập</a></li>';
            document.getElementById('navLogin').outerHTML = html;
            //$("#navLogin").html(html);

        }
    }