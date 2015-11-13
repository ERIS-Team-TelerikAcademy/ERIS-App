'use strict';

var express = require('express');
var http = require('http');
var path = require('path');
var favicon = require('serve-favicon');
var morgan = require('morgan');
var errorhandler = require('errorhandler');
var app = express();

app.set('port', process.env.PORT || 3000);

//app.use(favicon(__dirname + '/app/favicon.png'));

app.use(morgan('dev'));

app.use(express.static(path.join(__dirname, 'app')));

if ('development' === app.get('env')) {
  app.use(errorhandler());
}

http.createServer(app).listen(app.get('port'), function () {
   console.log('server listening on port ' + app.get('port'));
});
