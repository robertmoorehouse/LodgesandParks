
Partial Class admin_Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim keyList As ArrayList = New ArrayList
        Dim CacheEnum As IDictionaryEnumerator = Cache.GetEnumerator()
        While CacheEnum.MoveNext()
            keyList.Add(CacheEnum.Key.ToString())
        End While
        GridView1.DataSource = keyList
        gridview1.databind()
        Dim ipadd As String = Request.ServerVariables("REMOTE_ADDR")


        Dim ApplicationNumber As String = Application("RatioNumber")
        lblApplication.Text = ApplicationNumber

        ' Get the appSettings key,value pairs collection.
        Dim appSettings As NameValueCollection = System.Web.Configuration.WebConfigurationManager.AppSettings

        ' Get the collection enumerator.
        Dim appSettingsEnum As IEnumerator = appSettings.GetEnumerator()

        ' Loop through the collection and 
        ' display the appSettings key, value pairs.
        Dim i As Integer = 0
        appVals.Text = "[Display appSettings]<br />"
        While appSettingsEnum.MoveNext()
            Dim key As String = appSettings.AllKeys(i)
            appVals.Text = appVals.Text & "Key:" & key & " Value:" & appSettings(i) & "<br />"

            i += 1

        End While

  


    End Sub

    Protected Sub appButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles appButton1.Click
        Application("RatioNumber") = ddApplication.SelectedValue.ToString
        lblApplication.Text = Application("RatioNumber")
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Cache.Remove("LookupsDataset")
        ''Response.Write(IsNothing(Cache.Item("LookupsDataset")))

        ClearSearchResults()
    End Sub
    Public Sub ClearSearchResults()
        Dim keyList As ArrayList = New ArrayList
        Dim CacheEnum As IDictionaryEnumerator = Cache.GetEnumerator()
        While CacheEnum.MoveNext()
            If Not CacheEnum.Key.ToString.Contains("searchResult") Then
                keyList.Add(CacheEnum.Key.ToString())
            End If
        End While
        Dim key As String
        For Each key In keyList
            Cache.Remove(key)
        Next
    End Sub
    Public Sub Clearreviews()
        Dim keyList As ArrayList = New ArrayList
        Dim CacheEnum As IDictionaryEnumerator = Cache.GetEnumerator()
        While CacheEnum.MoveNext()
            If Not CacheEnum.Key.ToString.Contains("reviews") Then
                keyList.Add(CacheEnum.Key.ToString())
            End If
        End While
        Dim key As String
        For Each key In keyList
            Cache.Remove(key)
        Next
    End Sub

    Public Sub Clearpropertydetails()
        Dim keyList As ArrayList = New ArrayList
        Dim CacheEnum As IDictionaryEnumerator = Cache.GetEnumerator()
        While CacheEnum.MoveNext()
            If Not CacheEnum.Key.ToString.Contains("details") Then
                keyList.Add(CacheEnum.Key.ToString())
            End If
        End While
        Dim key As String
        For Each key In keyList
            Cache.Remove(key)
        Next
    End Sub
    Public Sub Clearpropertyavailability()
        Dim keyList As ArrayList = New ArrayList
        Dim CacheEnum As IDictionaryEnumerator = Cache.GetEnumerator()
        While CacheEnum.MoveNext()
            If Not CacheEnum.Key.ToString.Contains("availability") Then
                keyList.Add(CacheEnum.Key.ToString())
            End If
        End While
        Dim key As String
        For Each key In keyList
            Cache.Remove(key)
        Next
    End Sub
    Public Sub Clearlocations()
        Dim keyList As ArrayList = New ArrayList
        Dim CacheEnum As IDictionaryEnumerator = Cache.GetEnumerator()
        While CacheEnum.MoveNext()
            If Not CacheEnum.Key.ToString.Contains("Locations") Then
                keyList.Add(CacheEnum.Key.ToString())
            End If
        End While
        Dim key As String
        For Each key In keyList
            Cache.Remove(key)
        Next
    End Sub
    Public Sub ClearAll()
        Dim keyList As ArrayList = New ArrayList
        Dim CacheEnum As IDictionaryEnumerator = Cache.GetEnumerator()
        While CacheEnum.MoveNext()
            keyList.Add(CacheEnum.Key.ToString())
        End While
        Dim key As String
        For Each key In keyList
            Cache.Remove(key)
        Next
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Clearreviews()
    End Sub
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Clearpropertydetails()
    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Clearpropertyavailability()
    End Sub
    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Clearlocations()
    End Sub
    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        ClearAll()
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        Response.Redirect("produceGoogleSitemap.aspx")
    End Sub
    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        Response.Redirect("errors.aspx")
    End Sub
End Class
