
Partial Class test
    Inherits System.Web.UI.Page
    Public Function setdate()
        setdate = (Now() & "-" & Request.Url.Query)
    End Function
End Class
