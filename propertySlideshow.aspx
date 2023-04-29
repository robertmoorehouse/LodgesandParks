<%@ Page Language="VB" AutoEventWireup="false" CodeFile="propertySlideshow.aspx.vb" Inherits="propertySlideshow" %>
<%
    ' output xml for flash images
    Response.Write(Trim(getImagesForFlash(Request("ref"), Request("productFilter"))))
%>
