ADependencyInjection
===================
- where we register services inside dependency Injections system of .Net Core

Attributes
==========
- hold custom data Annotations that used inside api controller like (ResponseType) 

Security
========
- web Api Secured by Token Based Authentications where identity generate JWT and token sent to user when login and stored inside Request Header and every Request user made will inject token inside its header

========================================================================================================================================================

Http Request Header
===================
- store info sent from client to server like authentication type or content type 

Http Request Body
==================
- store data will be sent from client to server like json content or xml

Http Methods/Verb
=================
- define the target from request like

- HTTP GET  => to retreive data from server
- HTTP POST => to send data for save or insert
- HTTP Put  => to update data into server
- HTTP DELETE => to delete data into server

Http Statues Code
=================
- define the response type that sent from server to client after process client request

- 200 : (ok) mean success response
- 201 : (Created) mean post request success for creating the record , commonlly used with POST requests
- 204 : (No Content) mean request success but no content reqturend from the server , will be used commonlly for update requests (PUT)

- 400 : (Bad Request) mean request is not valid
- 401 : (UnAuthorized) mean request need authorized person not anynomouse users
- 403 : (Forbidden) mean client is authenticated but not authorized or not have permission for that action
- 404 : (Not Found) mean the request resource was not found


