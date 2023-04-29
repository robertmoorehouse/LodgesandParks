<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Slideshow.aspx.vb" Inherits="_Slideshow" %>
<%
    ' output xml for flash images
    Response.Write(Trim(getImagesForFlash(Request("ref"), Request("productFilter"))))
%>