<%-- 
    Document   : Salida
    Created on : 08-feb-2021, 15:15:08
    Author     : cristhianfc
--%>
<%@page import="Modelo.Registros"%>
<% 
    Registros item = (Registros)request.getAttribute("Factura");
%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <h1>Datos de facturacion:</h1>
        <p>______________________</p>
        <ul>
            <li>Nombre articulo: <%= item.getNombre()%></li>
            <li>Valor unitario:  <%= item.getValor() %></li>
            <li>Cantidad: <%= item.getCantidad() %></li>
            <li>Importado: <%= item.getImportado() %></li>
            <li>Nacionla: <%= item.getNacional() %></li>
           
        </ul>
        <a href="Index.jsp">Volver</a>
    </body>
</html>
