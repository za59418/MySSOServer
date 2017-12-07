DCISSO = function (clientId, serverUrl, clientUrl) {

    var $this = this;
    this.token = null;

    this.clientId = clientId; //'jsClient'
    this.serverUrl = serverUrl; // https://192.168.1.115:44319/identity
    this.clientUrl = clientUrl; // http://localhost/jsClient/index.html

    this.login = function () {
        if (window.location.hash) {
            $this.token = $this.processTokenCallback();
        }

        if (!$this.token) {
            var authorizationUrl = this.serverUrl + '/connect/authorize';
            var response_type = "token";
            var scope = "logon";
            var state = Date.now() + "" + Math.random();

            var url =
            authorizationUrl + "?" +
            "client_id=" + encodeURI($this.clientId) + "&" +
            "redirect_uri=" + encodeURI($this.clientUrl) + "&" +
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

    this.callApi = function () {

        var xhr = new XMLHttpRequest();
        xhr.onload = function (e) {
            if (xhr.status >= 400) {
                alert('ok');
            }
            else {
                alert(JSON.parse(xhr.response));
            }
        };
        xhr.onerror = function (e) {
            alert("unknown http error");
        };
        xhr.open("GET", "http://localhost:48545/user", true);
        xhr.setRequestHeader("Authorization", "Bearer " + $this.token);
        xhr.send();

    }


    this.logout = function () {
        window.location = this.serverUrl + "/connect/endsession?post_logout_redirect_uri=" + encodeURIComponent(window.location.protocol + "//" + window.location.host + "/index.html") + "&id_token_hint=" + encodeURIComponent($this.token);
    };   
}