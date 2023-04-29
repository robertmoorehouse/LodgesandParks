Imports Microsoft.VisualBasic
Imports System.Net.Mail


Public Class emailer
    Public Sub sendmail(ByVal fromAddress As String, ByVal mailformats As String, ByVal mailprioritys As String, ByVal subject As String, ByVal body As String, ByVal toemail As String, Optional ByVal bcc As String = "", Optional ByVal cc As String = "")
        'Create an instance of the MailMessage class
        Dim objMM As New MailMessage()

        objMM.To.Add(toemail)
        objMM.From = New MailAddress(fromAddress)

        If cc > "" Then
            objMM.CC.Add(cc)
        End If

        If bcc > "" Then
            objMM.Bcc.Add(bcc)
        End If

        Select Case LCase(mailformats)
            Case "text"
                objMM.IsBodyHtml = False
            Case "html"
                objMM.IsBodyHtml = True
            Case Else
                objMM.IsBodyHtml = False
        End Select

        Select Case LCase(mailprioritys)
            Case "high"
                objMM.Priority = MailPriority.High
            Case "low"
                objMM.Priority = MailPriority.Low
            Case "normal"
                objMM.Priority = MailPriority.Normal
            Case Else
                objMM.Priority = MailPriority.Normal
        End Select

        objMM.Subject = subject

        objMM.Body = body

        Dim smtp As New SmtpClient("127.0.0.1")
        smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis
        smtp.Send(objMM)

    End Sub
End Class
