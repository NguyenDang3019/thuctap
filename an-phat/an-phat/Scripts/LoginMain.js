//LOGIN FB
//[1] Hàm kiểm tra trạng thái đăng nhập
function statusChangeCallback(response) {             
    if (response.status === 'connected') {
        testAPI();
    } else {
        document.getElementById('status').innerHTML = 'Please log ' +
            'into this webpage.';
    }
}

//[2] Hàm dùng cho button login
function checkLoginState() {               // Called when a person is finished with the Login Button.
    FB.getLoginStatus(function (response) {   // See the onlogin handler
        statusChangeCallback(response);
    });
}

//[3] Các thành phần của ứng dụng
window.fbAsyncInit = function () {
    FB.init({
        appId: '2884515071779060',
        cookie: true,                     // Enable cookies to allow the server to access the session.
        xfbml: true,                     // Parse social plugins on this webpage.
        version: 'v8.0'           // Use this Graph API version for this call.
    });


    FB.getLoginStatus(function (response) {   // Called after the JS SDK has been initialized.
        statusChangeCallback(response);        // Returns the login status.
    });
};

//[4] Hàm xử lý
function testAPI() {                      // Testing Graph API after login.  See statusChangeCallback() for when this call is made.
    FB.api('/me', function (response) {
        // chuỗi xử lý ở đây
        document.getElementById('status').innerHTML =
            'Thanks for logging in, ' + response.name + '!';
    });
}


//END LOGIN FB------------------------------------

/*//Login Google====================
function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    console.log('Name: ' + profile.getName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
    alert('Email: ' + profile.getEmail());
}*/

    //button G