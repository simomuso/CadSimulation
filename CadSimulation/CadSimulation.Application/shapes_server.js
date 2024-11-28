var http = require('http');

const PORT=8282; 
var shapes = "";

http.createServer(function(request, response) {
  var headers = request.headers;
  var method = request.method;
  var url = request.url;
  var body = "";
  
  console.log("Incoming request");
  
  request.on('error', function(err) {
    console.error(err);
  }).on('data', function(chunk) {
		body = body + chunk;
  }).on('end', function() {

	console.log("method:");
	console.log(method);

	if (method == "POST") {
		console.log("Body:");
		console.log(body);
		shapes = body;
		response.end("OK")
	}
	else if (method == "GET") {
		console.log("Shapes");
		console.log(shapes);
		response.end(shapes);
	}
  });
}).listen(PORT);

