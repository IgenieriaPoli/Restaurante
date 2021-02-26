<%-- 
    Document   : Index
    Created on : 08-feb-2021, 14:20:44
    Author     : cristhianfc
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <h1>Datos facturación</h1>
        <form action="Registro" method="post">
            <label>Nombre articulo:</label>
            <input type="text" name="NArticulo"/>
            <br>
            <label>Valor unitario:</label>
            <input type="text" name="VUnitario"/>
            <br>
            <label>Cantidad:</label>
            <input type="text" name="Cantidad"/>
            <br>
            <label>Importado:</label>
            <input type="text" name="Importado"/>
            <br>
            <label>Nacional:</label>
            <input type="text" name="Nacional"/>
            <br>
            <br>
            <input type="submit" value="Enviar"/><br/><br/>
        </form>
    </body>
</html>
