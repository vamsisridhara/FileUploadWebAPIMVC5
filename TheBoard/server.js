var http = require('http');
var express = require('express');
var app = express();
app.get("/", function (request, response) {
    response.send("<html><body><h1>Express</h1></body></html>");
});
app.get("/api/users", function (request, response) {
    response.set("Content-Type", "application/json");
    response.send({
        name: "vamsi",
        email:"vamsisridhara@gmail.com"
    });
});

var server = http.createServer(app).listen(3000);
//var port = process.env.port || 1337;
//http.createServer(function (req, res) {
//    res.writeHead(200, { 'Content-Type': 'text/plain' });
//    res.end('Hello World\n');
//}).listen(port);