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
Namespace VR_pricechecker
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="priceCheckerSoap", [Namespace]:="http://tempuri.org/VillarentersWebService/priceChecker")>  _
    Partial Public Class priceChecker
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private checkAvailabilityOperationCompleted As System.Threading.SendOrPostCallback
        
        Private mainPriceCalcOperationCompleted As System.Threading.SendOrPostCallback
        
        Private discountPriceCalcOperationCompleted As System.Threading.SendOrPostCallback
        
        Private ExtrasPriceCalcOperationCompleted As System.Threading.SendOrPostCallback
        
        Private FullPriceCalcOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.internalWebServices.My.MySettings.Default.internalWebServices_VR_pricechecker_priceChecker
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
        Public Event checkAvailabilityCompleted As checkAvailabilityCompletedEventHandler
        
        '''<remarks/>
        Public Event mainPriceCalcCompleted As mainPriceCalcCompletedEventHandler
        
        '''<remarks/>
        Public Event discountPriceCalcCompleted As discountPriceCalcCompletedEventHandler
        
        '''<remarks/>
        Public Event ExtrasPriceCalcCompleted As ExtrasPriceCalcCompletedEventHandler
        
        '''<remarks/>
        Public Event FullPriceCalcCompleted As FullPriceCalcCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/VillarentersWebService/priceChecker/checkAvailability", RequestNamespace:="http://tempuri.org/VillarentersWebService/priceChecker", ResponseNamespace:="http://tempuri.org/VillarentersWebService/priceChecker", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function checkAvailability(ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String) As Availability
            Dim results() As Object = Me.Invoke("checkAvailability", New Object() {prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num})
            Return CType(results(0),Availability)
        End Function
        
        '''<remarks/>
        Public Overloads Sub checkAvailabilityAsync(ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String)
            Me.checkAvailabilityAsync(prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub checkAvailabilityAsync(ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String, ByVal userState As Object)
            If (Me.checkAvailabilityOperationCompleted Is Nothing) Then
                Me.checkAvailabilityOperationCompleted = AddressOf Me.OncheckAvailabilityOperationCompleted
            End If
            Me.InvokeAsync("checkAvailability", New Object() {prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num}, Me.checkAvailabilityOperationCompleted, userState)
        End Sub
        
        Private Sub OncheckAvailabilityOperationCompleted(ByVal arg As Object)
            If (Not (Me.checkAvailabilityCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent checkAvailabilityCompleted(Me, New checkAvailabilityCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/VillarentersWebService/priceChecker/mainPriceCalc", RequestNamespace:="http://tempuri.org/VillarentersWebService/priceChecker", ResponseNamespace:="http://tempuri.org/VillarentersWebService/priceChecker", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function mainPriceCalc(ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String) As mainPrice
            Dim results() As Object = Me.Invoke("mainPriceCalc", New Object() {prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num})
            Return CType(results(0),mainPrice)
        End Function
        
        '''<remarks/>
        Public Overloads Sub mainPriceCalcAsync(ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String)
            Me.mainPriceCalcAsync(prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub mainPriceCalcAsync(ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String, ByVal userState As Object)
            If (Me.mainPriceCalcOperationCompleted Is Nothing) Then
                Me.mainPriceCalcOperationCompleted = AddressOf Me.OnmainPriceCalcOperationCompleted
            End If
            Me.InvokeAsync("mainPriceCalc", New Object() {prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num}, Me.mainPriceCalcOperationCompleted, userState)
        End Sub
        
        Private Sub OnmainPriceCalcOperationCompleted(ByVal arg As Object)
            If (Not (Me.mainPriceCalcCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent mainPriceCalcCompleted(Me, New mainPriceCalcCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/VillarentersWebService/priceChecker/discountPriceCalc", RequestNamespace:="http://tempuri.org/VillarentersWebService/priceChecker", ResponseNamespace:="http://tempuri.org/VillarentersWebService/priceChecker", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function discountPriceCalc(ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String, ByVal promo_code As String, ByVal promo_rcam As String) As discountPrice
            Dim results() As Object = Me.Invoke("discountPriceCalc", New Object() {prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num, promo_code, promo_rcam})
            Return CType(results(0),discountPrice)
        End Function
        
        '''<remarks/>
        Public Overloads Sub discountPriceCalcAsync(ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String, ByVal promo_code As String, ByVal promo_rcam As String)
            Me.discountPriceCalcAsync(prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num, promo_code, promo_rcam, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub discountPriceCalcAsync(ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String, ByVal promo_code As String, ByVal promo_rcam As String, ByVal userState As Object)
            If (Me.discountPriceCalcOperationCompleted Is Nothing) Then
                Me.discountPriceCalcOperationCompleted = AddressOf Me.OndiscountPriceCalcOperationCompleted
            End If
            Me.InvokeAsync("discountPriceCalc", New Object() {prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num, promo_code, promo_rcam}, Me.discountPriceCalcOperationCompleted, userState)
        End Sub
        
        Private Sub OndiscountPriceCalcOperationCompleted(ByVal arg As Object)
            If (Not (Me.discountPriceCalcCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent discountPriceCalcCompleted(Me, New discountPriceCalcCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/VillarentersWebService/priceChecker/ExtrasPriceCalc", RequestNamespace:="http://tempuri.org/VillarentersWebService/priceChecker", ResponseNamespace:="http://tempuri.org/VillarentersWebService/priceChecker", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ExtrasPriceCalc(ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String, ByVal chosen_Extras As String) As extraPrice
            Dim results() As Object = Me.Invoke("ExtrasPriceCalc", New Object() {prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num, chosen_Extras})
            Return CType(results(0),extraPrice)
        End Function
        
        '''<remarks/>
        Public Overloads Sub ExtrasPriceCalcAsync(ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String, ByVal chosen_Extras As String)
            Me.ExtrasPriceCalcAsync(prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num, chosen_Extras, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub ExtrasPriceCalcAsync(ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String, ByVal chosen_Extras As String, ByVal userState As Object)
            If (Me.ExtrasPriceCalcOperationCompleted Is Nothing) Then
                Me.ExtrasPriceCalcOperationCompleted = AddressOf Me.OnExtrasPriceCalcOperationCompleted
            End If
            Me.InvokeAsync("ExtrasPriceCalc", New Object() {prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num, chosen_Extras}, Me.ExtrasPriceCalcOperationCompleted, userState)
        End Sub
        
        Private Sub OnExtrasPriceCalcOperationCompleted(ByVal arg As Object)
            If (Not (Me.ExtrasPriceCalcCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ExtrasPriceCalcCompleted(Me, New ExtrasPriceCalcCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/VillarentersWebService/priceChecker/FullPriceCalc", RequestNamespace:="http://tempuri.org/VillarentersWebService/priceChecker", ResponseNamespace:="http://tempuri.org/VillarentersWebService/priceChecker", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function FullPriceCalc(ByVal type As String, ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String, ByVal chosen_extras As String, ByVal promo_code As String, ByVal promo_rcam As String) As FullPrice
            Dim results() As Object = Me.Invoke("FullPriceCalc", New Object() {type, prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num, chosen_extras, promo_code, promo_rcam})
            Return CType(results(0),FullPrice)
        End Function
        
        '''<remarks/>
        Public Overloads Sub FullPriceCalcAsync(ByVal type As String, ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String, ByVal chosen_extras As String, ByVal promo_code As String, ByVal promo_rcam As String)
            Me.FullPriceCalcAsync(type, prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num, chosen_extras, promo_code, promo_rcam, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub FullPriceCalcAsync(ByVal type As String, ByVal prop_ref As String, ByVal start_date_YYYYMMDD As String, ByVal end_date_YYYYMMDD As String, ByVal number_nights As String, ByVal people_num As String, ByVal chosen_extras As String, ByVal promo_code As String, ByVal promo_rcam As String, ByVal userState As Object)
            If (Me.FullPriceCalcOperationCompleted Is Nothing) Then
                Me.FullPriceCalcOperationCompleted = AddressOf Me.OnFullPriceCalcOperationCompleted
            End If
            Me.InvokeAsync("FullPriceCalc", New Object() {type, prop_ref, start_date_YYYYMMDD, end_date_YYYYMMDD, number_nights, people_num, chosen_extras, promo_code, promo_rcam}, Me.FullPriceCalcOperationCompleted, userState)
        End Sub
        
        Private Sub OnFullPriceCalcOperationCompleted(ByVal arg As Object)
            If (Not (Me.FullPriceCalcCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent FullPriceCalcCompleted(Me, New FullPriceCalcCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/VillarentersWebService/priceChecker")>  _
    Partial Public Class Availability
        
        Private prop_refField As Integer
        
        Private start_date_YYYYMMDDField As Date
        
        Private end_date_YYYYMMDDField As Date
        
        Private last_night_YYYYMMDDField As Date
        
        Private people_numberField As Integer
        
        Private number_of_nightsField As Integer
        
        Private dates_okField As Boolean
        
        Private avail_errorField As String
        
        '''<remarks/>
        Public Property prop_ref() As Integer
            Get
                Return Me.prop_refField
            End Get
            Set
                Me.prop_refField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property start_date_YYYYMMDD() As Date
            Get
                Return Me.start_date_YYYYMMDDField
            End Get
            Set
                Me.start_date_YYYYMMDDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property end_date_YYYYMMDD() As Date
            Get
                Return Me.end_date_YYYYMMDDField
            End Get
            Set
                Me.end_date_YYYYMMDDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property last_night_YYYYMMDD() As Date
            Get
                Return Me.last_night_YYYYMMDDField
            End Get
            Set
                Me.last_night_YYYYMMDDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property people_number() As Integer
            Get
                Return Me.people_numberField
            End Get
            Set
                Me.people_numberField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property number_of_nights() As Integer
            Get
                Return Me.number_of_nightsField
            End Get
            Set
                Me.number_of_nightsField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property dates_ok() As Boolean
            Get
                Return Me.dates_okField
            End Get
            Set
                Me.dates_okField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property avail_error() As String
            Get
                Return Me.avail_errorField
            End Get
            Set
                Me.avail_errorField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/VillarentersWebService/priceChecker")>  _
    Partial Public Class FullPrice
        
        Private availabilityField As Availability
        
        Private mainPriceField As mainPrice
        
        Private discountPriceField As discountPrice
        
        Private extraPriceField As extraPrice
        
        '''<remarks/>
        Public Property availability() As Availability
            Get
                Return Me.availabilityField
            End Get
            Set
                Me.availabilityField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property mainPrice() As mainPrice
            Get
                Return Me.mainPriceField
            End Get
            Set
                Me.mainPriceField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property discountPrice() As discountPrice
            Get
                Return Me.discountPriceField
            End Get
            Set
                Me.discountPriceField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property extraPrice() As extraPrice
            Get
                Return Me.extraPriceField
            End Get
            Set
                Me.extraPriceField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/VillarentersWebService/priceChecker")>  _
    Partial Public Class mainPrice
        
        Private currencyField As String
        
        Private mainPrice1Field As Decimal
        
        Private main_errorField As String
        
        '''<remarks/>
        Public Property currency() As String
            Get
                Return Me.currencyField
            End Get
            Set
                Me.currencyField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("mainPrice")>  _
        Public Property mainPrice1() As Decimal
            Get
                Return Me.mainPrice1Field
            End Get
            Set
                Me.mainPrice1Field = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property main_error() As String
            Get
                Return Me.main_errorField
            End Get
            Set
                Me.main_errorField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/VillarentersWebService/priceChecker")>  _
    Partial Public Class discountPrice
        
        Private discount_textField As String
        
        Private priceCheckTextField As String
        
        Private ownerDiscountField As Decimal
        
        Private autoDiscountLateField As Decimal
        
        Private autoDiscountLongField As Decimal
        
        Private autoDiscountEarlyField As Decimal
        
        Private promo_ownerField As Integer
        
        Private promo_discount_typeField As Integer
        
        Private promo_discount_currField As String
        
        Private promo_discount_percentageField As Decimal
        
        Private discount_errorField As String
        
        '''<remarks/>
        Public Property discount_text() As String
            Get
                Return Me.discount_textField
            End Get
            Set
                Me.discount_textField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property priceCheckText() As String
            Get
                Return Me.priceCheckTextField
            End Get
            Set
                Me.priceCheckTextField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property ownerDiscount() As Decimal
            Get
                Return Me.ownerDiscountField
            End Get
            Set
                Me.ownerDiscountField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property autoDiscountLate() As Decimal
            Get
                Return Me.autoDiscountLateField
            End Get
            Set
                Me.autoDiscountLateField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property autoDiscountLong() As Decimal
            Get
                Return Me.autoDiscountLongField
            End Get
            Set
                Me.autoDiscountLongField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property autoDiscountEarly() As Decimal
            Get
                Return Me.autoDiscountEarlyField
            End Get
            Set
                Me.autoDiscountEarlyField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property promo_owner() As Integer
            Get
                Return Me.promo_ownerField
            End Get
            Set
                Me.promo_ownerField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property promo_discount_type() As Integer
            Get
                Return Me.promo_discount_typeField
            End Get
            Set
                Me.promo_discount_typeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property promo_discount_curr() As String
            Get
                Return Me.promo_discount_currField
            End Get
            Set
                Me.promo_discount_currField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property promo_discount_percentage() As Decimal
            Get
                Return Me.promo_discount_percentageField
            End Get
            Set
                Me.promo_discount_percentageField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property discount_error() As String
            Get
                Return Me.discount_errorField
            End Get
            Set
                Me.discount_errorField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/VillarentersWebService/priceChecker")>  _
    Partial Public Class extraPrice
        
        Private compulsoryExtraTextField As String
        
        Private optionalExtraTextField As String
        
        Private extraPrice1Field As Decimal
        
        Private extraPriceCurrencyField As String
        
        Private extrasChosenField As String
        
        Private extra_errorField As String
        
        Private extraListField() As extraListOptions
        
        '''<remarks/>
        Public Property CompulsoryExtraText() As String
            Get
                Return Me.compulsoryExtraTextField
            End Get
            Set
                Me.compulsoryExtraTextField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property OptionalExtraText() As String
            Get
                Return Me.optionalExtraTextField
            End Get
            Set
                Me.optionalExtraTextField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("extraPrice")>  _
        Public Property extraPrice1() As Decimal
            Get
                Return Me.extraPrice1Field
            End Get
            Set
                Me.extraPrice1Field = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property extraPriceCurrency() As String
            Get
                Return Me.extraPriceCurrencyField
            End Get
            Set
                Me.extraPriceCurrencyField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property extrasChosen() As String
            Get
                Return Me.extrasChosenField
            End Get
            Set
                Me.extrasChosenField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property extra_error() As String
            Get
                Return Me.extra_errorField
            End Get
            Set
                Me.extra_errorField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute(IsNullable:=false)>  _
        Public Property extraList() As extraListOptions()
            Get
                Return Me.extraListField
            End Get
            Set
                Me.extraListField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/VillarentersWebService/priceChecker")>  _
    Partial Public Class extraListOptions
        
        Private extra_idField As Integer
        
        Private extra_textField As String
        
        Private extra_compulsoryField As Boolean
        
        Private extra_priceField As Decimal
        
        Private extra_pickedField As Boolean
        
        Private extra_currencyField As String
        
        Private extra_counter_allowField As Boolean
        
        Private extra_counterField As String
        
        '''<remarks/>
        Public Property extra_id() As Integer
            Get
                Return Me.extra_idField
            End Get
            Set
                Me.extra_idField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property extra_text() As String
            Get
                Return Me.extra_textField
            End Get
            Set
                Me.extra_textField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property extra_compulsory() As Boolean
            Get
                Return Me.extra_compulsoryField
            End Get
            Set
                Me.extra_compulsoryField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property extra_price() As Decimal
            Get
                Return Me.extra_priceField
            End Get
            Set
                Me.extra_priceField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property extra_picked() As Boolean
            Get
                Return Me.extra_pickedField
            End Get
            Set
                Me.extra_pickedField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property extra_currency() As String
            Get
                Return Me.extra_currencyField
            End Get
            Set
                Me.extra_currencyField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property extra_counter_allow() As Boolean
            Get
                Return Me.extra_counter_allowField
            End Get
            Set
                Me.extra_counter_allowField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property extra_counter() As String
            Get
                Return Me.extra_counterField
            End Get
            Set
                Me.extra_counterField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub checkAvailabilityCompletedEventHandler(ByVal sender As Object, ByVal e As checkAvailabilityCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class checkAvailabilityCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Availability
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Availability)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub mainPriceCalcCompletedEventHandler(ByVal sender As Object, ByVal e As mainPriceCalcCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class mainPriceCalcCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As mainPrice
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),mainPrice)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub discountPriceCalcCompletedEventHandler(ByVal sender As Object, ByVal e As discountPriceCalcCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class discountPriceCalcCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As discountPrice
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),discountPrice)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub ExtrasPriceCalcCompletedEventHandler(ByVal sender As Object, ByVal e As ExtrasPriceCalcCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class ExtrasPriceCalcCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As extraPrice
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),extraPrice)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub FullPriceCalcCompletedEventHandler(ByVal sender As Object, ByVal e As FullPriceCalcCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class FullPriceCalcCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As FullPrice
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),FullPrice)
            End Get
        End Property
    End Class
End Namespace
