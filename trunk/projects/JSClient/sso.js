function DCISSO() {

    var $this = this;

    this.token = null;

    this.login = function () {
        if (window.location.hash) {
            $this.token = processTokenCallback();
        }

        if (!$this.token) {
            var authorizationUrl = 'https://192.168.1.115:44319/identity/connect/authorize';
            var client_id = 'jsClient';
            var redirect_uri = 'http://localhost/jsClient/index.html';
            var response_type = "token";
            var scope = "logon";
            var state = Date.now() + "" + Math.random();

            var url =
            authorizationUrl + "?" +
            "client_id=" + encodeURI(client_id) + "&" +
            "redirect_uri=" + encodeURI(redirect_uri) + "&" +
            "response_type=" + encodeURI(response_type) + "&" +
            "scope=" + encodeURI(scope) + "&" +
            "state=" + encodeURI(state);
            window.location = url;
        }
    };

    this.processTokenCallback = function () {
        var hash = window.location.hash.substr(1);
        var result = hash.split('&').reduce(function (result, item) {
            var parts = item.split('=');
            result[parts[0]] = parts[1];
            return result;
        }, {});

        if (!result.error) {
            return result.access_token;
        }
    };

    this.logout = function () {
        window.location = "https://192.168.1.115:44319/identity/connect/endsession?post_logout_redirect_uri=" + encodeURIComponent(window.location.protocol + "//" + window.location.host + "/index.html") + "&id_token_hint=" + encodeURIComponent($this.token);
    };
}