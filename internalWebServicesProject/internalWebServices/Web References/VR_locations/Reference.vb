﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.832
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.832.
'
Namespace VR_locations
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="VillarentersSoap", [Namespace]:="http://tempuri.org/VillarentersWebService/Villarenters")>  _
    Partial Public Class Villarenters
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private VillaSearchOperationCompleted As System.Threading.SendOrPostCallback
        
        Private XMLMapSourceOperationCompleted As System.Threading.SendOrPostCallback
        
        Private CountryListOperationCompleted As System.Threading.SendOrPostCallback
        
        Private RegionListOperationCompleted As System.Threading.SendOrPostCallback
        
        Private TownListOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.internalWebServices.My.MySettings.Default.internalWebServices_VR_locations_Villarenters
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event VillaSearchCompleted As VillaSearchCompletedEventHandler
        
        '''<remarks/>
        Public Event XMLMapSourceCompleted As XMLMapSourceCompletedEventHandler
        
        '''<remarks/>
        Public Event CountryListCompleted As CountryListCompletedEventHandler
        
        '''<remarks/>
        Public Event RegionListCompleted As RegionListCompletedEventHandler
        
        '''<remarks/>
        Public Event TownListCompleted As TownListCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/VillarentersWebService/Villarenters/VillaSearch", RequestNamespace:="http://tempuri.org/VillarentersWebService/Villarenters", ResponseNamespace:="http://tempuri.org/VillarentersWebService/Villarenters", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function VillaSearch(ByVal Rag As String, ByVal lngOwnerRef As Long, ByVal lngPropRef As Long, ByVal strCountry As String, ByVal strRegion As String, ByVal strTown As String, ByVal intMaxPrice As Integer, ByVal intMinPrice As Integer, ByVal intSleeps As Integer, ByVal blnInstantBooking As Boolean, ByVal intVillarentersIndex As Integer, ByVal strOrderBy As String, ByVal intPage As Integer, ByVal intPageSize As Integer, ByVal blnUnbranded As Boolean) As VillaResults
            Dim results() As Object = Me.Invoke("VillaSearch", New Object() {Rag, lngOwnerRef, lngPropRef, strCountry, strRegion, strTown, intMaxPrice, intMinPrice, intSleeps, blnInstantBooking, intVillarentersIndex, strOrderBy, intPage, intPageSize, blnUnbranded})
            Return CType(results(0),VillaResults)
        End Function
        
        '''<remarks/>
        Public Overloads Sub VillaSearchAsync(ByVal Rag As String, ByVal lngOwnerRef As Long, ByVal lngPropRef As Long, ByVal strCountry As String, ByVal strRegion As String, ByVal strTown As String, ByVal intMaxPrice As Integer, ByVal intMinPrice As Integer, ByVal intSleeps As Integer, ByVal blnInstantBooking As Boolean, ByVal intVillarentersIndex As Integer, ByVal strOrderBy As String, ByVal intPage As Integer, ByVal intPageSize As Integer, ByVal blnUnbranded As Boolean)
            Me.VillaSearchAsync(Rag, lngOwnerRef, lngPropRef, strCountry, strRegion, strTown, intMaxPrice, intMinPrice, intSleeps, blnInstantBooking, intVillarentersIndex, strOrderBy, intPage, intPageSize, blnUnbranded, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub VillaSearchAsync( _
                    ByVal Rag As String,  _
                    ByVal lngOwnerRef As Long,  _
                    ByVal lngPropRef As Long,  _
                    ByVal strCountry As String,  _
                    ByVal strRegion As String,  _
                    ByVal strTown As String,  _
                    ByVal intMaxPrice As Integer,  _
                    ByVal intMinPrice As Integer,  _
                    ByVal intSleeps As Integer,  _
                    ByVal blnInstantBooking As Boolean,  _
                    ByVal intVillarentersIndex As Integer,  _
                    ByVal strOrderBy As String,  _
                    ByVal intPage As Integer,  _
                    ByVal intPageSize As Integer,  _
                    ByVal blnUnbranded As Boolean,  _
                    ByVal userState As Object)
            If (Me.VillaSearchOperationCompleted Is Nothing) Then
                Me.VillaSearchOperationCompleted = AddressOf Me.OnVillaSearchOperationCompleted
            End If
            Me.InvokeAsync("VillaSearch", New Object() {Rag, lngOwnerRef, lngPropRef, strCountry, strRegion, strTown, intMaxPrice, intMinPrice, intSleeps, blnInstantBooking, intVillarentersIndex, strOrderBy, intPage, intPageSize, blnUnbranded}, Me.VillaSearchOperationCompleted, userState)
        End Sub
        
        Private Sub OnVillaSearchOperationCompleted(ByVal arg As Object)
            If (Not (Me.VillaSearchCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent VillaSearchCompleted(Me, New VillaSearchCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/VillarentersWebService/Villarenters/XMLMapSource", RequestNamespace:="http://tempuri.org/VillarentersWebService/Villarenters", ResponseNamespace:="http://tempuri.org/VillarentersWebService/Villarenters", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function XMLMapSource(ByVal intGetItemType As Integer, ByVal strFilter As String, ByVal strAvailabiltyFrom As String, ByVal strAvailabiltyTo As String, ByVal lngHighlightItemID As Long, ByVal strPd As String) As MapData
            Dim results() As Object = Me.Invoke("XMLMapSource", New Object() {intGetItemType, strFilter, strAvailabiltyFrom, strAvailabiltyTo, lngHighlightItemID, strPd})
            Return CType(results(0),MapData)
        End Function
        
        '''<remarks/>
        Public Overloads Sub XMLMapSourceAsync(ByVal intGetItemType As Integer, ByVal strFilter As String, ByVal strAvailabiltyFrom As String, ByVal strAvailabiltyTo As String, ByVal lngHighlightItemID As Long, ByVal strPd As String)
            Me.XMLMapSourceAsync(intGetItemType, strFilter, strAvailabiltyFrom, strAvailabiltyTo, lngHighlightItemID, strPd, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub XMLMapSourceAsync(ByVal intGetItemType As Integer, ByVal strFilter As String, ByVal strAvailabiltyFrom As String, ByVal strAvailabiltyTo As String, ByVal lngHighlightItemID As Long, ByVal strPd As String, ByVal userState As Object)
            If (Me.XMLMapSourceOperationCompleted Is Nothing) Then
                Me.XMLMapSourceOperationCompleted = AddressOf Me.OnXMLMapSourceOperationCompleted
            End If
            Me.InvokeAsync("XMLMapSource", New Object() {intGetItemType, strFilter, strAvailabiltyFrom, strAvailabiltyTo, lngHighlightItemID, strPd}, Me.XMLMapSourceOperationCompleted, userState)
        End Sub
        
        Private Sub OnXMLMapSourceOperationCompleted(ByVal arg As Object)
            If (Not (Me.XMLMapSourceCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent XMLMapSourceCompleted(Me, New XMLMapSourceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/VillarentersWebService/Villarenters/CountryList", RequestNamespace:="http://tempuri.org/VillarentersWebService/Villarenters", ResponseNamespace:="http://tempuri.org/VillarentersWebService/Villarenters", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CountryList() As AreasResults
            Dim results() As Object = Me.Invoke("CountryList", New Object(-1) {})
            Return CType(results(0),AreasResults)
        End Function
        
        '''<remarks/>
        Public Overloads Sub CountryListAsync()
            Me.CountryListAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub CountryListAsync(ByVal userState As Object)
            If (Me.CountryListOperationCompleted Is Nothing) Then
                Me.CountryListOperationCompleted = AddressOf Me.OnCountryListOperationCompleted
            End If
            Me.InvokeAsync("CountryList", New Object(-1) {}, Me.CountryListOperationCompleted, userState)
        End Sub
        
        Private Sub OnCountryListOperationCompleted(ByVal arg As Object)
            If (Not (Me.CountryListCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent CountryListCompleted(Me, New CountryListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/VillarentersWebService/Villarenters/RegionList", RequestNamespace:="http://tempuri.org/VillarentersWebService/Villarenters", ResponseNamespace:="http://tempuri.org/VillarentersWebService/Villarenters", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function RegionList() As AreasResults
            Dim results() As Object = Me.Invoke("RegionList", New Object(-1) {})
            Return CType(results(0),AreasResults)
        End Function
        
        '''<remarks/>
        Public Overloads Sub RegionListAsync()
            Me.RegionListAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub RegionListAsync(ByVal userState As Object)
            If (Me.RegionListOperationCompleted Is Nothing) Then
                Me.RegionListOperationCompleted = AddressOf Me.OnRegionListOperationCompleted
            End If
            Me.InvokeAsync("RegionList", New Object(-1) {}, Me.RegionListOperationCompleted, userState)
        End Sub
        
        Private Sub OnRegionListOperationCompleted(ByVal arg As Object)
            If (Not (Me.RegionListCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent RegionListCompleted(Me, New RegionListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/VillarentersWebService/Villarenters/TownList", RequestNamespace:="http://tempuri.org/VillarentersWebService/Villarenters", ResponseNamespace:="http://tempuri.org/VillarentersWebService/Villarenters", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function TownList() As AreasResults
            Dim results() As Object = Me.Invoke("TownList", New Object(-1) {})
            Return CType(results(0),AreasResults)
        End Function
        
        '''<remarks/>
        Public Overloads Sub TownListAsync()
            Me.TownListAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub TownListAsync(ByVal userState As Object)
            If (Me.TownListOperationCompleted Is Nothing) Then
                Me.TownListOperationCompleted = AddressOf Me.OnTownListOperationCompleted
            End If
            Me.InvokeAsync("TownList", New Object(-1) {}, Me.TownListOperationCompleted, userState)
        End Sub
        
        Private Sub OnTownListOperationCompleted(ByVal arg As Object)
            If (Not (Me.TownListCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent TownListCompleted(Me, New TownListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/VillarentersWebService/Villarenters")>  _
    Partial Public Class VillaResults
        
        Private resultsField As Integer
        
        Private pagesField As Integer
        
        Private pageField As Integer
        
        Private villasField() As Villa
        
        '''<remarks/>
        Public Property Results() As Integer
            Get
                Return Me.resultsField
            End Get
            Set
                Me.resultsField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Pages() As Integer
            Get
                Return Me.pagesField
            End Get
            Set
                Me.pagesField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Page() As Integer
            Get
                Return Me.pageField
            End Get
            Set
                Me.pageField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute(IsNullable:=false)>  _
        Public Property Villas() As Villa()
            Get
                Return Me.villasField
            End Get
            Set
                Me.villasField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/VillarentersWebService/Villarenters")>  _
    Partial Public Class Villa
        
        Private prop_refField As Long
        
        Private owner_refField As Long
        
        Private titleField As String
        
        Private summaryField As String
        
        Private imageLocationField As String
        
        Private filenameField As String
        
        Private countryField As String
        
        Private countyField As String
        
        Private townField As String
        
        Private minPriceField As Decimal
        
        Private maxPriceField As Decimal
        
        Private currencyField As String
        
        Private currencyLogoField As String
        
        Private sleepsField As Integer
        
        Private doubleBedsField As Integer
        
        Private twinBedsField As Integer
        
        Private singleBedsField As Integer
        
        Private cotsField As Integer
        
        Private bathroomsField As Integer
        
        Private tvField As Boolean
        
        Private internetField As Boolean
        
        Private centralHeatingField As Boolean
        
        Private instantBookingField As Boolean
        
        Private villarentersIndexField As Integer
        
        '''<remarks/>
        Public Property prop_ref() As Long
            Get
                Return Me.prop_refField
            End Get
            Set
                Me.prop_refField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property owner_ref() As Long
            Get
                Return Me.owner_refField
            End Get
            Set
                Me.owner_refField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Title() As String
            Get
                Return Me.titleField
            End Get
            Set
                Me.titleField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Summary() As String
            Get
                Return Me.summaryField
            End Get
            Set
                Me.summaryField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property ImageLocation() As String
            Get
                Return Me.imageLocationField
            End Get
            Set
                Me.imageLocationField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Filename() As String
            Get
                Return Me.filenameField
            End Get
            Set
                Me.filenameField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Country() As String
            Get
                Return Me.countryField
            End Get
            Set
                Me.countryField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property County() As String
            Get
                Return Me.countyField
            End Get
            Set
                Me.countyField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Town() As String
            Get
                Return Me.townField
            End Get
            Set
                Me.townField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property MinPrice() As Decimal
            Get
                Return Me.minPriceField
            End Get
            Set
                Me.minPriceField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property MaxPrice() As Decimal
            Get
                Return Me.maxPriceField
            End Get
            Set
                Me.maxPriceField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Currency() As String
            Get
                Return Me.currencyField
            End Get
            Set
                Me.currencyField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property CurrencyLogo() As String
            Get
                Return Me.currencyLogoField
            End Get
            Set
                Me.currencyLogoField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Sleeps() As Integer
            Get
                Return Me.sleepsField
            End Get
            Set
                Me.sleepsField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property DoubleBeds() As Integer
            Get
                Return Me.doubleBedsField
            End Get
            Set
                Me.doubleBedsField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property TwinBeds() As Integer
            Get
                Return Me.twinBedsField
            End Get
            Set
                Me.twinBedsField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property SingleBeds() As Integer
            Get
                Return Me.singleBedsField
            End Get
            Set
                Me.singleBedsField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Cots() As Integer
            Get
                Return Me.cotsField
            End Get
            Set
                Me.cotsField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Bathrooms() As Integer
            Get
                Return Me.bathroomsField
            End Get
            Set
                Me.bathroomsField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property TV() As Boolean
            Get
                Return Me.tvField
            End Get
            Set
                Me.tvField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Internet() As Boolean
            Get
                Return Me.internetField
            End Get
            Set
                Me.internetField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property CentralHeating() As Boolean
            Get
                Return Me.centralHeatingField
            End Get
            Set
                Me.centralHeatingField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property InstantBooking() As Boolean
            Get
                Return Me.instantBookingField
            End Get
            Set
                Me.instantBookingField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property VillarentersIndex() As Integer
            Get
                Return Me.villarentersIndexField
            End Get
            Set
                Me.villarentersIndexField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/VillarentersWebService/Villarenters")>  _
    Partial Public Class Area
        
        Private areaDescriptionField As String
        
        Private codeField As Integer
        
        '''<remarks/>
        Public Property AreaDescription() As String
            Get
                Return Me.areaDescriptionField
            End Get
            Set
                Me.areaDescriptionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Code() As Integer
            Get
                Return Me.codeField
            End Get
            Set
                Me.codeField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/VillarentersWebService/Villarenters")>  _
    Partial Public Class AreasResults
        
        Private areasField() As Area
        
        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute(IsNullable:=false)>  _
        Public Property Areas() As Area()
            Get
                Return Me.areasField
            End Get
            Set
                Me.areasField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/VillarentersWebService/Villarenters")>  _
    Partial Public Class MapItem
        
        Private itemIDField As Long
        
        Private itemTypeField As Integer
        
        Private itemLonField As Double
        
        Private itemLatField As Double
        
        Private titleField As String
        
        Private areaField As String
        
        Private popUpTabField As String
        
        Private uRLField As String
        
        Private mapImagePathField As String
        
        Private imageURLField As String
        
        '''<remarks/>
        Public Property ItemID() As Long
            Get
                Return Me.itemIDField
            End Get
            Set
                Me.itemIDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property ItemType() As Integer
            Get
                Return Me.itemTypeField
            End Get
            Set
                Me.itemTypeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property ItemLon() As Double
            Get
                Return Me.itemLonField
            End Get
            Set
                Me.itemLonField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property ItemLat() As Double
            Get
                Return Me.itemLatField
            End Get
            Set
                Me.itemLatField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Title() As String
            Get
                Return Me.titleField
            End Get
            Set
                Me.titleField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Area() As String
            Get
                Return Me.areaField
            End Get
            Set
                Me.areaField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property PopUpTab() As String
            Get
                Return Me.popUpTabField
            End Get
            Set
                Me.popUpTabField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property URL() As String
            Get
                Return Me.uRLField
            End Get
            Set
                Me.uRLField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property MapImagePath() As String
            Get
                Return Me.mapImagePathField
            End Get
            Set
                Me.mapImagePathField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property ImageURL() As String
            Get
                Return Me.imageURLField
            End Get
            Set
                Me.imageURLField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/VillarentersWebService/Villarenters")>  _
    Partial Public Class MapData
        
        Private mapItemsField() As MapItem
        
        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute(IsNullable:=false)>  _
        Public Property MapItems() As MapItem()
            Get
                Return Me.mapItemsField
            End Get
            Set
                Me.mapItemsField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub VillaSearchCompletedEventHandler(ByVal sender As Object, ByVal e As VillaSearchCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class VillaSearchCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As VillaResults
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),VillaResults)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub XMLMapSourceCompletedEventHandler(ByVal sender As Object, ByVal e As XMLMapSourceCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class XMLMapSourceCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As MapData
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),MapData)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub CountryListCompletedEventHandler(ByVal sender As Object, ByVal e As CountryListCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class CountryListCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As AreasResults
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),AreasResults)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub RegionListCompletedEventHandler(ByVal sender As Object, ByVal e As RegionListCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class RegionListCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As AreasResults
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),AreasResults)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub TownListCompletedEventHandler(ByVal sender As Object, ByVal e As TownListCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class TownListCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As AreasResults
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),AreasResults)
            End Get
        End Property
    End Class
End Namespace
