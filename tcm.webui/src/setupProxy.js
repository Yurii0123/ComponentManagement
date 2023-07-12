const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/weatherforecast",
];

const onError = (err, req, resp, target) => {
    debugger
    console.error(`${err.message}`);
}

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7082',
        onError: onError,
        secure: false,
        // Uncomment this line to add support for proxying websockets
        //ws: true, 
        headers: {
            Connection: 'Keep-Alive'
        }
    });

    app.use(appProxy);
};


