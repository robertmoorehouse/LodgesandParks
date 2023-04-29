Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization
Imports System.IO
Imports System.Data
Imports System.EnterpriseServices
Imports Microsoft.VisualBasic
Imports System.Web.HttpContext
Imports System.Data.SqlClient

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class zonchiholidays
    Inherits System.Web.Services.WebService
    Private objConfigReader = New System.Configuration.AppSettingsReader
    Public zonchiholidaysConnectionString As String

    Public Sub New()
        zonchiholidaysConnectionString = System.Configuration.ConfigurationManager.AppSettings("zonchiholidaysConnectionString").ToString
    End Sub
    Public Structure PropertyReview
        Public prop_ref As String
        Public Reviews() As Review
    End Structure
    Public Structure Review
        Public ReviewDate As String
        Public StarRating As Integer
        Public By As String
        Public From As String
        Public Article As String
    End Structure
    <WebMethod(CacheDuration:=10)> _
        Public Function GetPropertyReviews(ByVal prop_ref As String, ByVal website As String) As PropertyReview
        prop_ref = stripstring(prop_ref)
        website = stripstring(website)
        '*gets the Reviews from the pdate_prop table
        Dim PropReviews As PropertyReview
        Dim objRow As Data.DataRowView

        Dim intMonthCount As Integer
        If InStr(prop_ref, "--") > 0 Then Err.Raise(101)
        Try
            If prop_ref > "" Then

                Dim oConn As Data.SqlClient.SqlConnection
                oConn = New SqlClient.SqlConnection
                oConn.ConnectionString = zonchiholidaysConnectionString
                oConn.Open()
                Dim SQLTerms As New SqlCommand("get_reviews", oConn)
                SQLTerms.CommandType = CommandType.StoredProcedure
                SQLTerms.Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 10, ParameterDirection.Input)).Value = prop_ref
                SQLTerms.Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 10, ParameterDirection.Input)).Value = website


                SQLTerms.ExecuteNonQuery()
                Dim dsReviews As New DataSet("dsReviews")
                Dim daReviews As New SqlDataAdapter()
                Dim dvReviews As New DataView
                daReviews.SelectCommand = SQLTerms
                daReviews.Fill(dsReviews)
                dvReviews = New DataView(dsReviews.Tables(0))
                PropReviews.prop_ref = prop_ref
                intMonthCount = 0
                '*Redim the size
                ReDim Preserve PropReviews.Reviews(dsReviews.Tables(0).Rows.Count - 1)
                PropReviews.prop_ref = prop_ref

                For Each objRow In dvReviews

                    '*Add the values
                    PropReviews.Reviews(intMonthCount).By = objRow("firstname") & " " & objRow("lastname")
                    PropReviews.Reviews(intMonthCount).ReviewDate = FormatDateTime(objRow("submitted_date"), DateFormat.ShortDate)
                    PropReviews.Reviews(intMonthCount).Article = objRow("review_text")
                    PropReviews.Reviews(intMonthCount).StarRating = objRow("star_rating")
                    PropReviews.Reviews(intMonthCount).From = objRow("town_from")
                    intMonthCount = intMonthCount + 1

                Next

                SQLTerms.Dispose()
                oConn.Close()

            End If
            GetPropertyReviews = PropReviews
        Catch
            GetPropertyReviews = Nothing
        End Try

    End Function
    <WebMethod(CacheDuration:=10)> _
    Public Function SavePropertyContents(ByVal prop_ref As String, ByVal prop_type As String, ByVal prop_type_id As Integer, _
     ByVal accommodation As String, _
     ByVal traffic As Integer, _
     ByVal shopping_trip As Boolean, _
     ByVal cultural As Boolean, _
     ByVal tourist As Boolean, _
     ByVal sight_seeing As Boolean, _
     ByVal seaside As Boolean, _
     ByVal luxury As Boolean, _
     ByVal romantic As Boolean, _
     ByVal relaxing As Boolean, _
     ByVal activity As Boolean, _
     ByVal family As Boolean, _
     ByVal business As Boolean, _
     ByVal budget As Boolean, _
     ByVal children As Boolean, _
     ByVal babies As Boolean, _
     ByVal pets As Boolean, _
     ByVal petsexplain As String, _
     ByVal wheelchairs As Boolean, _
     ByVal wheelchairsexplain As String, _
     ByVal elderly As Boolean, _
     ByVal living_seating As Integer, _
     ByVal dining_seating As Integer, _
     ByVal bathrooms As Integer, _
     ByVal wcs As Integer, _
     ByVal sleeps As Integer, _
     ByVal double_beds As Integer, _
     ByVal twin_beds As Integer, _
     ByVal single_beds As Integer, _
     ByVal cots As Integer, _
     ByVal ensuite As Integer, _
     ByVal sofa_beds As Integer, _
     ByVal sofa_beds_location As String, _
     ByVal dbl_sofa_beds As Integer, _
     ByVal dbl_sofa_beds_location As String, _
     ByVal dbl_bunks As Integer, _
     ByVal dbl_bunks_location As String, _
     ByVal open_fire As Boolean, _
     ByVal tv As Boolean, _
     ByVal home_cinema As Boolean, _
     ByVal video As Boolean, _
     ByVal dvd As Boolean, _
     ByVal satellite As Boolean, _
     ByVal cassette As Boolean, _
     ByVal vinyl As Boolean, _
     ByVal cd As Boolean, _
     ByVal radio As Boolean, _
     ByVal computer As Boolean, _
     ByVal internet As Boolean, _
     ByVal telephone_in As Boolean, _
     ByVal telephone_out As Boolean, _
     ByVal fax As Boolean, _
     ByVal sauna As Boolean, _
     ByVal home_gym As Boolean, _
     ByVal snooker_pool_table As Boolean, _
     ByVal table_tennis As Boolean, _
     ByVal air_conditioning As Boolean, _
     ByVal central_heating As Boolean, _
     ByVal linen_provided As Boolean, _
     ByVal cooker As Boolean, _
     ByVal oven As Boolean, _
     ByVal microwave As Boolean, _
     ByVal fridge As Boolean, _
     ByVal freezer As Boolean, _
     ByVal dish_washer As Boolean, _
     ByVal washing_machine As Boolean, _
     ByVal clothes_drier As Boolean, _
     ByVal kettle As Boolean, _
     ByVal toaster As Boolean, _
     ByVal cutlery As Boolean, _
     ByVal crockery As Boolean, _
     ByVal glassware As Boolean, _
     ByVal pots As Boolean, _
     ByVal hair_drier As Boolean, _
     ByVal trouser_press As Boolean, _
     ByVal iron As Boolean, _
     ByVal garden As Boolean, _
     ByVal garden_aspect As String, _
     ByVal patio As Boolean, _
     ByVal patio_aspect As String, _
     ByVal balcony As Boolean, _
     ByVal balcony_aspect As String, _
     ByVal views_sea As Boolean, _
     ByVal views_panoramic As Boolean, _
     ByVal views_other As Boolean, _
     ByVal summer_house As Boolean, _
     ByVal pool_private As Boolean, _
     ByVal pool_communal As Boolean, _
     ByVal pool_aspect As String, _
     ByVal tennis_court As Boolean, _
     ByVal barbeque As Boolean, _
     ByVal patio_heater As Boolean, _
     ByVal outside_lighting As Boolean, _
     ByVal parking As Boolean, _
     ByVal garage As Boolean, _
     ByVal extra As String, _
     ByVal room_title As String, _
     ByVal room_number As Integer, _
     ByVal resturants As Integer, _
     ByVal public_resturants As Integer, _
     ByVal bars_count As Integer, _
     ByVal lounges_count As Integer, _
     ByVal dining_rooms As Integer, _
     ByVal public_dining_rooms As Integer, _
     ByVal dry_cleaning As Boolean, _
     ByVal postal_service As Boolean, _
     ByVal express_checkout As Boolean, _
     ByVal left_luggage As Boolean, _
     ByVal safety_deposit As Boolean, _
     ByVal meeting_facilities As Boolean, _
     ByVal meeting_room_equipment_hire As Boolean, _
     ByVal free_internet As Boolean, _
     ByVal wireless_internet As Boolean, _
     ByVal photocopier As Boolean, _
     ByVal media_hire As Boolean, _
     ByVal lift As Boolean, _
     ByVal all_ground_floor As Boolean, _
     ByVal stairs_to_all As Boolean, _
     ByVal stairs_to_some As Boolean, _
     ByVal valet_parking As Boolean, _
     ByVal free_parking As Boolean, _
     ByVal hgv_parking As Boolean, _
     ByVal coach_parking As Boolean, _
     ByVal airport_parking As Boolean, _
     ByVal breakfast_weekday_times As String, _
     ByVal breakfast_weekend_times As String, _
     ByVal dinner_weekday_times As String, _
     ByVal dinner_weekend_times As String, _
     ByVal lunch_weekend_times As String, _
     ByVal lunch_weekday_times As String, _
     ByVal username As String, ByVal Password As String, ByVal website As String) As String

        Dim returnval As String = "1"
        If username = "gpwssecsave1997" And Password = "bx13721" Then
            Try
                If prop_ref > "" Then

                    Dim oConn As Data.SqlClient.SqlConnection
                    oConn = New SqlClient.SqlConnection
                    oConn.ConnectionString = zonchiholidaysConnectionString
                    oConn.Open()

                    Dim SQLReview As New SqlCommand("save_prop_contents", oConn)
                    SQLReview.CommandType = CommandType.StoredProcedure
                    SQLReview.CommandType = CommandType.StoredProcedure
                    Try
                        With SQLReview
                            .Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(prop_ref)
                            .Parameters.Add(New SqlParameter("@activity", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = activity
                            .Parameters.Add(New SqlParameter("@prop_type", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = stripstring(prop_type)
                            .Parameters.Add(New SqlParameter("@prop_type_id", SqlDbType.Int, 1, ParameterDirection.Input)).Value = prop_type_id
                            .Parameters.Add(New SqlParameter("@accommodation", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = stripstring(accommodation)
                            .Parameters.Add(New SqlParameter("@traffic", SqlDbType.Int, 1, ParameterDirection.Input)).Value = traffic
                            .Parameters.Add(New SqlParameter("@shopping_trip", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = shopping_trip
                            .Parameters.Add(New SqlParameter("@cultural", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = cultural
                            .Parameters.Add(New SqlParameter("@tourist", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = tourist
                            .Parameters.Add(New SqlParameter("@sight_seeing", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = sight_seeing
                            .Parameters.Add(New SqlParameter("@seaside", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = seaside
                            .Parameters.Add(New SqlParameter("@luxury", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = luxury
                            .Parameters.Add(New SqlParameter("@romantic", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = romantic
                            .Parameters.Add(New SqlParameter("@relaxing", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = relaxing
                            .Parameters.Add(New SqlParameter("@activity", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = activity
                            .Parameters.Add(New SqlParameter("@family", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = family
                            .Parameters.Add(New SqlParameter("@business", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = business
                            .Parameters.Add(New SqlParameter("@budget", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = budget
                            .Parameters.Add(New SqlParameter("@children", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = children
                            .Parameters.Add(New SqlParameter("@babies", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = babies
                            .Parameters.Add(New SqlParameter("@pets", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = pets
                            .Parameters.Add(New SqlParameter("@petsexplain", SqlDbType.VarChar, 1000, ParameterDirection.Input)).Value = stripstring(petsexplain)
                            .Parameters.Add(New SqlParameter("@wheelchairs", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = wheelchairs
                            .Parameters.Add(New SqlParameter("@wheelchairsexplain", SqlDbType.VarChar, 1000, ParameterDirection.Input)).Value = stripstring(wheelchairsexplain)
                            .Parameters.Add(New SqlParameter("@elderly", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = elderly
                            .Parameters.Add(New SqlParameter("@living_seating", SqlDbType.Int, 1, ParameterDirection.Input)).Value = living_seating
                            .Parameters.Add(New SqlParameter("@dining_seating", SqlDbType.Int, 1, ParameterDirection.Input)).Value = dining_seating
                            .Parameters.Add(New SqlParameter("@bathrooms", SqlDbType.Int, 1, ParameterDirection.Input)).Value = bathrooms
                            .Parameters.Add(New SqlParameter("@wcs", SqlDbType.Int, 1, ParameterDirection.Input)).Value = wcs
                            .Parameters.Add(New SqlParameter("@sleeps", SqlDbType.Int, 1, ParameterDirection.Input)).Value = sleeps
                            .Parameters.Add(New SqlParameter("@double_beds", SqlDbType.Int, 1, ParameterDirection.Input)).Value = double_beds
                            .Parameters.Add(New SqlParameter("@twin_beds", SqlDbType.Int, 1, ParameterDirection.Input)).Value = twin_beds
                            .Parameters.Add(New SqlParameter("@single_beds", SqlDbType.Int, 1, ParameterDirection.Input)).Value = single_beds
                            .Parameters.Add(New SqlParameter("@cots", SqlDbType.Int, 1, ParameterDirection.Input)).Value = cots
                            .Parameters.Add(New SqlParameter("@ensuite", SqlDbType.Int, 1, ParameterDirection.Input)).Value = ensuite
                            .Parameters.Add(New SqlParameter("@sofa_beds", SqlDbType.Int, 1, ParameterDirection.Input)).Value = sofa_beds
                            .Parameters.Add(New SqlParameter("@sofa_beds_location", SqlDbType.VarChar, 200, ParameterDirection.Input)).Value = stripstring(sofa_beds_location)
                            .Parameters.Add(New SqlParameter("@dbl_sofa_beds", SqlDbType.Int, 1, ParameterDirection.Input)).Value = dbl_sofa_beds
                            .Parameters.Add(New SqlParameter("@dbl_sofa_beds_location", SqlDbType.VarChar, 200, ParameterDirection.Input)).Value = stripstring(dbl_sofa_beds_location)
                            .Parameters.Add(New SqlParameter("@dbl_bunks", SqlDbType.Int, 1, ParameterDirection.Input)).Value = dbl_bunks
                            .Parameters.Add(New SqlParameter("@dbl_bunks_location", SqlDbType.VarChar, 200, ParameterDirection.Input)).Value = stripstring(dbl_bunks_location)
                            .Parameters.Add(New SqlParameter("@open_fire", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = open_fire
                            .Parameters.Add(New SqlParameter("@tv", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = tv
                            .Parameters.Add(New SqlParameter("@home_cinema", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = home_cinema
                            .Parameters.Add(New SqlParameter("@video", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = video
                            .Parameters.Add(New SqlParameter("@dvd", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = dvd
                            .Parameters.Add(New SqlParameter("@satellite", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = satellite
                            .Parameters.Add(New SqlParameter("@cassette", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = cassette
                            .Parameters.Add(New SqlParameter("@vinyl", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = vinyl
                            .Parameters.Add(New SqlParameter("@cd", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = cd
                            .Parameters.Add(New SqlParameter("@radio", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = radio
                            .Parameters.Add(New SqlParameter("@computer", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = computer
                            .Parameters.Add(New SqlParameter("@internet", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = internet
                            .Parameters.Add(New SqlParameter("@telephone_in", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = telephone_in
                            .Parameters.Add(New SqlParameter("@telephone_out", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = telephone_out
                            .Parameters.Add(New SqlParameter("@fax", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = fax
                            .Parameters.Add(New SqlParameter("@sauna", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = sauna
                            .Parameters.Add(New SqlParameter("@home_gym", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = home_gym
                            .Parameters.Add(New SqlParameter("@snooker_pool_table", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = snooker_pool_table
                            .Parameters.Add(New SqlParameter("@table_tennis", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = table_tennis
                            .Parameters.Add(New SqlParameter("@air_conditioning", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = air_conditioning
                            .Parameters.Add(New SqlParameter("@central_heating", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = central_heating
                            .Parameters.Add(New SqlParameter("@linen_provided", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = linen_provided
                            .Parameters.Add(New SqlParameter("@cooker", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = cooker
                            .Parameters.Add(New SqlParameter("@oven", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = oven
                            .Parameters.Add(New SqlParameter("@microwave", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = microwave
                            .Parameters.Add(New SqlParameter("@fridge", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = fridge
                            .Parameters.Add(New SqlParameter("@freezer", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = freezer
                            .Parameters.Add(New SqlParameter("@dish_washer", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = dish_washer
                            .Parameters.Add(New SqlParameter("@washing_machine", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = washing_machine
                            .Parameters.Add(New SqlParameter("@clothes_drier", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = clothes_drier
                            .Parameters.Add(New SqlParameter("@kettle", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = kettle
                            .Parameters.Add(New SqlParameter("@toaster", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = toaster
                            .Parameters.Add(New SqlParameter("@cutlery", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = cutlery
                            .Parameters.Add(New SqlParameter("@crockery", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = crockery
                            .Parameters.Add(New SqlParameter("@glassware", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = glassware
                            .Parameters.Add(New SqlParameter("@pots", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = pots
                            .Parameters.Add(New SqlParameter("@hair_drier", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = hair_drier
                            .Parameters.Add(New SqlParameter("@trouser_press", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = trouser_press
                            .Parameters.Add(New SqlParameter("@iron", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = iron
                            .Parameters.Add(New SqlParameter("@garden", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = garden
                            .Parameters.Add(New SqlParameter("@garden_aspect", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = garden_aspect
                            .Parameters.Add(New SqlParameter("@patio", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = patio
                            .Parameters.Add(New SqlParameter("@patio_aspect", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = patio_aspect
                            .Parameters.Add(New SqlParameter("@balcony", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = balcony
                            .Parameters.Add(New SqlParameter("@balcony_aspect", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = balcony_aspect
                            .Parameters.Add(New SqlParameter("@views_sea", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = views_sea
                            .Parameters.Add(New SqlParameter("@views_panoramic", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = views_panoramic
                            .Parameters.Add(New SqlParameter("@views_other", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = views_other
                            .Parameters.Add(New SqlParameter("@summer_house", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = summer_house
                            .Parameters.Add(New SqlParameter("@pool_private", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = pool_private
                            .Parameters.Add(New SqlParameter("@pool_communal", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = pool_communal
                            .Parameters.Add(New SqlParameter("@pool_aspect", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = stripstring(pool_aspect)
                            .Parameters.Add(New SqlParameter("@tennis_court", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = tennis_court
                            .Parameters.Add(New SqlParameter("@barbeque", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = barbeque
                            .Parameters.Add(New SqlParameter("@patio_heater", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = patio_heater
                            .Parameters.Add(New SqlParameter("@outside_lighting", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = outside_lighting
                            .Parameters.Add(New SqlParameter("@parking", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = parking
                            .Parameters.Add(New SqlParameter("@garage", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = garage
                            .Parameters.Add(New SqlParameter("@extra", SqlDbType.VarChar, 1000, ParameterDirection.Input)).Value = stripstring(extra)
                            .Parameters.Add(New SqlParameter("@room_title", SqlDbType.VarChar, 150, ParameterDirection.Input)).Value = stripstring(room_title)
                            .Parameters.Add(New SqlParameter("@room_number", SqlDbType.Int, 1, ParameterDirection.Input)).Value = room_number
                            .Parameters.Add(New SqlParameter("@resturants", SqlDbType.Int, 1, ParameterDirection.Input)).Value = resturants
                            .Parameters.Add(New SqlParameter("@public_resturants", SqlDbType.Int, 1, ParameterDirection.Input)).Value = public_resturants
                            .Parameters.Add(New SqlParameter("@bars_count", SqlDbType.Int, 1, ParameterDirection.Input)).Value = bars_count
                            .Parameters.Add(New SqlParameter("@lounges_count", SqlDbType.Int, 1, ParameterDirection.Input)).Value = lounges_count
                            .Parameters.Add(New SqlParameter("@dining_rooms", SqlDbType.Int, 1, ParameterDirection.Input)).Value = dining_rooms
                            .Parameters.Add(New SqlParameter("@public_dining_rooms", SqlDbType.Int, 1, ParameterDirection.Input)).Value = public_dining_rooms
                            .Parameters.Add(New SqlParameter("@dry_cleaning", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = dry_cleaning
                            .Parameters.Add(New SqlParameter("@postal_service", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = postal_service
                            .Parameters.Add(New SqlParameter("@express_checkout", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = express_checkout
                            .Parameters.Add(New SqlParameter("@left_luggage", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = left_luggage
                            .Parameters.Add(New SqlParameter("@safety_deposit", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = safety_deposit
                            .Parameters.Add(New SqlParameter("@meeting_facilities", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = meeting_facilities
                            .Parameters.Add(New SqlParameter("@meeting_room_equipment_hire", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = meeting_room_equipment_hire
                            .Parameters.Add(New SqlParameter("@free_internet", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = free_internet
                            .Parameters.Add(New SqlParameter("@wireless_internet", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = wireless_internet
                            .Parameters.Add(New SqlParameter("@photocopier", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = photocopier
                            .Parameters.Add(New SqlParameter("@media_hire", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = media_hire
                            .Parameters.Add(New SqlParameter("@lift", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = lift
                            .Parameters.Add(New SqlParameter("@all_ground_floor", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = all_ground_floor
                            .Parameters.Add(New SqlParameter("@stairs_to_all", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = stairs_to_all
                            .Parameters.Add(New SqlParameter("@stairs_to_some", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = stairs_to_some
                            .Parameters.Add(New SqlParameter("@valet_parking", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = valet_parking
                            .Parameters.Add(New SqlParameter("@free_parking", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = free_parking
                            .Parameters.Add(New SqlParameter("@hgv_parking", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = hgv_parking
                            .Parameters.Add(New SqlParameter("@coach_parking", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = coach_parking
                            .Parameters.Add(New SqlParameter("@airport_parking", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = airport_parking
                            .Parameters.Add(New SqlParameter("@breakfast_weekday_times", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = stripstring(breakfast_weekday_times)
                            .Parameters.Add(New SqlParameter("@breakfast_weekend_times", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = stripstring(breakfast_weekend_times)
                            .Parameters.Add(New SqlParameter("@dinner_weekday_times", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = stripstring(dinner_weekday_times)
                            .Parameters.Add(New SqlParameter("@dinner_weekend_times", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = stripstring(dinner_weekend_times)
                            .Parameters.Add(New SqlParameter("@lunch_weekend_times", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = stripstring(lunch_weekend_times)
                            .Parameters.Add(New SqlParameter("@lunch_weekday_times", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = stripstring(lunch_weekday_times)
                            .ExecuteNonQuery()
                        End With

                    Catch ex As Exception
                        returnval = ex.ToString
                    Finally
                        SQLReview.Dispose()
                        oConn.Close()
                    End Try

                End If



                

            Catch ex As Exception
                returnval = ex.ToString
            End Try
        End If
        Return returnval


    End Function
    <WebMethod(CacheDuration:=10)> _
    Public Function SavePropertyCharacteristics( _
    ByVal prop_ref As String, _
    ByVal airport As String, _
    ByVal airport_distance As Integer, _
    ByVal airport_units As String, _
    ByVal MapLink As Boolean, _
    ByVal Lat As Boolean, _
    ByVal Lon As Boolean, _
    ByVal non_smoking As Boolean, _
    ByVal loc_city As Boolean, _
    ByVal loc_town As Boolean, _
    ByVal loc_village As Boolean, _
    ByVal loc_rural As Boolean, _
    ByVal loc_beach As Boolean, _
    ByVal loc_seaside As Boolean, _
    ByVal loc_waterfront As Boolean, _
    ByVal loc_resort As Boolean, _
    ByVal loc_mountains As Boolean, _
    ByVal loc_countryside As Boolean, _
    ByVal loc_life As Boolean, _
    ByVal loc_quiet As Boolean, _
    ByVal user1 As String, _
    ByVal user1_distance As Integer, _
    ByVal user1_units As String, _
    ByVal user2 As String, _
    ByVal user2_distance As Integer, _
    ByVal user2_units As String, _
    ByVal user3 As String, _
    ByVal user3_distance As Integer, _
    ByVal user3_units As String, _
    ByVal user4 As String, _
    ByVal user4_distance As Integer, _
    ByVal user4_units As String, _
    ByVal map_accuracy As Integer, _
    ByVal username As String, ByVal Password As String, ByVal website As String) As String

        Dim returnval As String = "1"
        If username = "gpwssecsave1997" And Password = "bx13721" Then
            Try
                If prop_ref > "" Then

                    Dim oConn As Data.SqlClient.SqlConnection
                    oConn = New SqlClient.SqlConnection
                    oConn.ConnectionString = zonchiholidaysConnectionString
                    oConn.Open()

                    Dim SQLReview As New SqlCommand("save_prop_contents", oConn)
                    SQLReview.CommandType = CommandType.StoredProcedure
                    SQLReview.CommandType = CommandType.StoredProcedure
                    Try
                        With SQLReview

                            .Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(prop_ref)
                            .Parameters.Add(New SqlParameter("@non_smoking", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = non_smoking
                            .Parameters.Add(New SqlParameter("@loc_city", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = loc_city
                            .Parameters.Add(New SqlParameter("@loc_town", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = loc_town
                            .Parameters.Add(New SqlParameter("@loc_village", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = loc_village
                            .Parameters.Add(New SqlParameter("@loc_rural", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = loc_rural
                            .Parameters.Add(New SqlParameter("@loc_beach", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = loc_beach
                            .Parameters.Add(New SqlParameter("@loc_seaside", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = loc_seaside
                            .Parameters.Add(New SqlParameter("@loc_waterfront", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = loc_waterfront
                            .Parameters.Add(New SqlParameter("@loc_resort", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = loc_resort
                            .Parameters.Add(New SqlParameter("@loc_mountains", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = loc_mountains
                            .Parameters.Add(New SqlParameter("@loc_countryside", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = loc_countryside
                            .Parameters.Add(New SqlParameter("@loc_life", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = loc_life
                            .Parameters.Add(New SqlParameter("@loc_quiet", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = loc_quiet
                            .Parameters.Add(New SqlParameter("@airport", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(airport)
                            .Parameters.Add(New SqlParameter("@airport_distance", SqlDbType.Int, 1, ParameterDirection.Input)).Value = airport_distance
                            .Parameters.Add(New SqlParameter("@airport_units", SqlDbType.VarChar, 10, ParameterDirection.Input)).Value = stripstring(airport_units)
                            .Parameters.Add(New SqlParameter("@user1", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(user1)
                            .Parameters.Add(New SqlParameter("@user1_distance", SqlDbType.Int, 1, ParameterDirection.Input)).Value = user1_distance
                            .Parameters.Add(New SqlParameter("@user1_units", SqlDbType.VarChar, 10, ParameterDirection.Input)).Value = stripstring(user1_units)
                            .Parameters.Add(New SqlParameter("@user2", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(user2)
                            .Parameters.Add(New SqlParameter("@user2_distance", SqlDbType.Int, 1, ParameterDirection.Input)).Value = user2_distance
                            .Parameters.Add(New SqlParameter("@user2_units", SqlDbType.VarChar, 10, ParameterDirection.Input)).Value = stripstring(user2_units)
                            .Parameters.Add(New SqlParameter("@user3", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(user3)
                            .Parameters.Add(New SqlParameter("@user3_distance", SqlDbType.Int, 1, ParameterDirection.Input)).Value = user3_distance
                            .Parameters.Add(New SqlParameter("@user3_units", SqlDbType.VarChar, 10, ParameterDirection.Input)).Value = stripstring(user3_units)
                            .Parameters.Add(New SqlParameter("@user4", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(user4)
                            .Parameters.Add(New SqlParameter("@user4_distance", SqlDbType.Int, 1, ParameterDirection.Input)).Value = user4_distance
                            .Parameters.Add(New SqlParameter("@user4_units", SqlDbType.VarChar, 10, ParameterDirection.Input)).Value = stripstring(user4_units)
                            .Parameters.Add(New SqlParameter("@maplink", SqlDbType.VarChar, 1000, ParameterDirection.Input)).Value = stripstring(MapLink)
                            .Parameters.Add(New SqlParameter("@lon", SqlDbType.Float, 1, ParameterDirection.Input)).Value = Lon
                            .Parameters.Add(New SqlParameter("@lat", SqlDbType.Float, 1, ParameterDirection.Input)).Value = Lat
                            .Parameters.Add(New SqlParameter("@map_accuracy", SqlDbType.Int, 1, ParameterDirection.Input)).Value = map_accuracy
                            .Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(website)



                        End With

                    Catch ex As Exception
                        returnval = ex.ToString
                    Finally
                        SQLReview.Dispose()
                        oConn.Close()
                    End Try

                End If





            Catch ex As Exception
                returnval = ex.ToString
            End Try
        End If
        Return returnval



    End Function

    <WebMethod(CacheDuration:=10)> _
   Public Function SavePropertyActivities( _
    ByVal prop_ref As String, _
    ByVal beach As Integer, _
    ByVal swimming As Integer, _
    ByVal sailing As Integer, _
    ByVal waterskiing As Integer, _
    ByVal boathire As Integer, _
    ByVal windsurfing As Integer, _
    ByVal fishing As Integer, _
    ByVal climbing As Integer, _
    ByVal flying As Integer, _
    ByVal walking As Integer, _
    ByVal cycling As Integer, _
    ByVal mountainbiking As Integer, _
    ByVal horseriding As Integer, _
    ByVal skiing As Integer, _
    ByVal golf As Integer, _
    ByVal tennis As Integer, _
    ByVal sportscenter As Integer, _
    ByVal scuba As Integer, _
    ByVal sports_extra As String, _
    ByVal historic As Integer, _
    ByVal museum As Integer, _
    ByVal zoo As Integer, _
    ByVal theatre_cinema As Integer, _
    ByVal shopping As Integer, _
    ByVal themepark As Integer, _
    ByVal restaurant As Integer, _
    ByVal food_shop As Integer, _
    ByVal attraction_extra As String, _
    ByVal username As String, ByVal Password As String, ByVal website As String) As String


        Dim returnval As String = "1"
        If username = "gpwssecsave1997" And Password = "bx13721" Then
            Try
                If prop_ref > "" Then

                    Dim oConn As Data.SqlClient.SqlConnection
                    oConn = New SqlClient.SqlConnection
                    oConn.ConnectionString = zonchiholidaysConnectionString
                    oConn.Open()

                    Dim SQLReview As New SqlCommand("save_prop_activities", oConn)
                    SQLReview.CommandType = CommandType.StoredProcedure
                    SQLReview.CommandType = CommandType.StoredProcedure
                    Try
                        With SQLReview


                            .Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(prop_ref)
                            .Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(website)
                            .Parameters.Add(New SqlParameter("@beach", SqlDbType.Int, 1, ParameterDirection.Input)).Value = beach
                            .Parameters.Add(New SqlParameter("@swimming", SqlDbType.Int, 1, ParameterDirection.Input)).Value = swimming
                            .Parameters.Add(New SqlParameter("@sailing", SqlDbType.Int, 1, ParameterDirection.Input)).Value = sailing
                            .Parameters.Add(New SqlParameter("@waterskiing", SqlDbType.Int, 1, ParameterDirection.Input)).Value = waterskiing
                            .Parameters.Add(New SqlParameter("@boathire", SqlDbType.Int, 1, ParameterDirection.Input)).Value = boathire
                            .Parameters.Add(New SqlParameter("@windsurfing", SqlDbType.Int, 1, ParameterDirection.Input)).Value = windsurfing
                            .Parameters.Add(New SqlParameter("@fishing", SqlDbType.Int, 1, ParameterDirection.Input)).Value = fishing
                            .Parameters.Add(New SqlParameter("@climbing", SqlDbType.Int, 1, ParameterDirection.Input)).Value = climbing
                            .Parameters.Add(New SqlParameter("@flying", SqlDbType.Int, 1, ParameterDirection.Input)).Value = flying
                            .Parameters.Add(New SqlParameter("@walking", SqlDbType.Int, 1, ParameterDirection.Input)).Value = walking
                            .Parameters.Add(New SqlParameter("@cycling", SqlDbType.Int, 1, ParameterDirection.Input)).Value = cycling
                            .Parameters.Add(New SqlParameter("@mountainbiking", SqlDbType.Int, 1, ParameterDirection.Input)).Value = mountainbiking
                            .Parameters.Add(New SqlParameter("@horseriding", SqlDbType.Int, 1, ParameterDirection.Input)).Value = horseriding
                            .Parameters.Add(New SqlParameter("@skiing", SqlDbType.Int, 1, ParameterDirection.Input)).Value = skiing
                            .Parameters.Add(New SqlParameter("@golf", SqlDbType.Int, 1, ParameterDirection.Input)).Value = golf
                            .Parameters.Add(New SqlParameter("@tennis", SqlDbType.Int, 1, ParameterDirection.Input)).Value = tennis
                            .Parameters.Add(New SqlParameter("@sportscenter", SqlDbType.Int, 1, ParameterDirection.Input)).Value = sportscenter
                            .Parameters.Add(New SqlParameter("@scuba", SqlDbType.Int, 1, ParameterDirection.Input)).Value = scuba
                            .Parameters.Add(New SqlParameter("@sports_extra", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = stripstring(sports_extra)
                            .Parameters.Add(New SqlParameter("@historic", SqlDbType.Int, 1, ParameterDirection.Input)).Value = historic
                            .Parameters.Add(New SqlParameter("@museum", SqlDbType.Int, 1, ParameterDirection.Input)).Value = museum
                            .Parameters.Add(New SqlParameter("@zoo", SqlDbType.Int, 1, ParameterDirection.Input)).Value = zoo
                            .Parameters.Add(New SqlParameter("@theatre_cinema", SqlDbType.Int, 1, ParameterDirection.Input)).Value = theatre_cinema
                            .Parameters.Add(New SqlParameter("@shopping", SqlDbType.Int, 1, ParameterDirection.Input)).Value = shopping
                            .Parameters.Add(New SqlParameter("@themepark", SqlDbType.Int, 1, ParameterDirection.Input)).Value = themepark
                            .Parameters.Add(New SqlParameter("@restaurant", SqlDbType.Int, 1, ParameterDirection.Input)).Value = restaurant
                            .Parameters.Add(New SqlParameter("@food_shop", SqlDbType.Int, 1, ParameterDirection.Input)).Value = food_shop
                            .Parameters.Add(New SqlParameter("@attraction_extra", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = stripstring(attraction_extra)


                        End With

                    Catch ex As Exception
                        returnval = ex.ToString
                    Finally
                        SQLReview.Dispose()
                        oConn.Close()
                    End Try

                End If





            Catch ex As Exception
                returnval = ex.ToString
            End Try
        End If
        Return returnval



    End Function


    <WebMethod(CacheDuration:=10)> _
    Public Function savepropertydescriptions( _
    ByVal prop_ref As String, _
    ByVal title As String, _
    ByVal paragraph As String, _
    ByVal username As String, ByVal Password As String, ByVal website As String) As String

        Dim returnval As String = "1"
        If username = "gpwssecsave1997" And Password = "bx13721" Then
            Try
                If prop_ref > "" Then

                    Dim oConn As Data.SqlClient.SqlConnection
                    oConn = New SqlClient.SqlConnection
                    oConn.ConnectionString = zonchiholidaysConnectionString
                    oConn.Open()
                    Dim SQLReview As New SqlCommand("save_prop_descriptions", oConn)
                    SQLReview.CommandType = CommandType.StoredProcedure
                    SQLReview.CommandType = CommandType.StoredProcedure
                    Try
                        With SQLReview
                            .Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(prop_ref)
                            .Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(website)
                            .Parameters.Add(New SqlParameter("@paragraph", SqlDbType.NText, 1, ParameterDirection.Input)).Value = paragraph
                            .Parameters.Add(New SqlParameter("@title", SqlDbType.VarChar, 255, ParameterDirection.Input)).Value = stripstring(title)
                        End With
                    Catch ex As Exception
                        returnval = ex.ToString
                    Finally
                        SQLReview.Dispose()
                        oConn.Close()
                    End Try

                End If
            Catch ex As Exception
                returnval = ex.ToString
            End Try
        End If
        Return returnval



    End Function

    <WebMethod(CacheDuration:=10)> _
    Public Function savepropertyimages( _
    ByVal prop_ref As String, _
    ByVal imageURL As String, _
    ByVal imagecaption As String, _
    ByVal username As String, ByVal Password As String, ByVal website As String) As String

        Dim returnval As String = "1"
        If username = "gpwssecsave1997" And Password = "bx13721" Then
            Try
                If prop_ref > "" Then

                    Dim oConn As Data.SqlClient.SqlConnection
                    oConn = New SqlClient.SqlConnection
                    oConn.ConnectionString = zonchiholidaysConnectionString
                    oConn.Open()
                    Dim SQLReview As New SqlCommand("save_prop_images", oConn)
                    SQLReview.CommandType = CommandType.StoredProcedure
                    SQLReview.CommandType = CommandType.StoredProcedure
                    Try
                        With SQLReview
                            .Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(prop_ref)
                            .Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(website)
                            .Parameters.Add(New SqlParameter("@imagecaption", SqlDbType.VarChar, 1000, ParameterDirection.Input)).Value = stripstring(imagecaption)
                            .Parameters.Add(New SqlParameter("@imageURL", SqlDbType.VarChar, 1000, ParameterDirection.Input)).Value = stripstring(imageURL)
                        End With
                    Catch ex As Exception
                        returnval = ex.ToString
                    Finally
                        SQLReview.Dispose()
                        oConn.Close()
                    End Try

                End If
            Catch ex As Exception
                returnval = ex.ToString
            End Try
        End If
        Return returnval



    End Function

    <WebMethod(CacheDuration:=10)> _
        Public Function savepropertylocations( _
        ByVal prop_ref As String, _
        ByVal locationdescription As String, _
        ByVal parentID As Integer, _
        ByVal LocationRef As Integer, _
        ByVal username As String, ByVal Password As String, ByVal website As String) As String

        Dim returnval As String = "1"
        If username = "gpwssecsave1997" And Password = "bx13721" Then
            Try
                If prop_ref > "" Then

                    Dim oConn As Data.SqlClient.SqlConnection
                    oConn = New SqlClient.SqlConnection
                    oConn.ConnectionString = zonchiholidaysConnectionString
                    oConn.Open()
                    Dim SQLReview As New SqlCommand("save_prop_locations", oConn)
                    SQLReview.CommandType = CommandType.StoredProcedure
                    SQLReview.CommandType = CommandType.StoredProcedure
                    Try
                        With SQLReview
                            .Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(prop_ref)
                            .Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(website)
                            .Parameters.Add(New SqlParameter("@locationdescription", SqlDbType.VarChar, 255, ParameterDirection.Input)).Value = stripstring(locationdescription)
                            .Parameters.Add(New SqlParameter("@parentID", SqlDbType.Int, 1, ParameterDirection.Input)).Value = parentID
                            .Parameters.Add(New SqlParameter("@LocationRef", SqlDbType.Int, 1, ParameterDirection.Input)).Value = LocationRef
                        End With
                    Catch ex As Exception
                        returnval = ex.ToString
                    Finally
                        SQLReview.Dispose()
                        oConn.Close()
                    End Try

                End If
            Catch ex As Exception
                returnval = ex.ToString
            End Try
        End If
        Return returnval



    End Function
    <WebMethod(CacheDuration:=10)> _
        Public Function SavePropertyReviews(ByVal prop_ref As String, ByVal first_name As String, ByVal last_name As String, _
        ByVal email_address As String, ByVal booking_ref As String, ByVal val_for_money As Integer, ByVal met_expectations As Integer, _
        ByVal would_rec As Integer, ByVal overall_rating As Integer, ByVal submitted_date As DateTime, ByVal review_text As String, _
        ByVal star_rating As Integer, ByVal town_from As String, ByVal review_approved As String, _
        ByVal prop_country As String, ByVal prop_title As String, ByVal username As String, ByVal Password As String, ByVal website As String) As String

        Dim returnval As String = "1"
        If username = "gpwssecsave1997" And Password = "bx13721" Then
            Try
                If Len(prop_ref) > 0 Then

                    Dim oConn As Data.SqlClient.SqlConnection
                    oConn = New SqlClient.SqlConnection
                    oConn.ConnectionString = zonchiholidaysConnectionString
                    oConn.Open()

                    Dim SQLReview As New SqlCommand("save_property_review", oConn)
                    SQLReview.CommandType = CommandType.StoredProcedure
                    SQLReview.CommandType = CommandType.StoredProcedure
                    Try
                        With SQLReview
                            .Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(prop_ref)
                            .Parameters.Add(New SqlParameter("@firstname", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(first_name)
                            .Parameters.Add(New SqlParameter("@lastname", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(last_name)
                            .Parameters.Add(New SqlParameter("@email_address", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = stripstring(email_address)
                            .Parameters.Add(New SqlParameter("@booking_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(booking_ref)
                            .Parameters.Add(New SqlParameter("@val_for_money", SqlDbType.Int, 1, ParameterDirection.Input)).Value = val_for_money
                            .Parameters.Add(New SqlParameter("@met_expectations", SqlDbType.Int, 1, ParameterDirection.Input)).Value = met_expectations
                            .Parameters.Add(New SqlParameter("@would_rec", SqlDbType.Int, 1, ParameterDirection.Input)).Value = would_rec
                            .Parameters.Add(New SqlParameter("@overall_rating", SqlDbType.Int, 1, ParameterDirection.Input)).Value = overall_rating
                            .Parameters.Add(New SqlParameter("@star_rating", SqlDbType.Int, 1, ParameterDirection.Input)).Value = star_rating
                            .Parameters.Add(New SqlParameter("@review_text", SqlDbType.Text, 4000, ParameterDirection.Input)).Value = stripstring(review_text)
                            .Parameters.Add(New SqlParameter("@town_from", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(town_from)
                            .Parameters.Add(New SqlParameter("@submitted_date", SqlDbType.DateTime, 8, ParameterDirection.Input)).Value = submitted_date
                            .Parameters.Add(New SqlParameter("@review_approved", SqlDbType.Int, 1, ParameterDirection.Input)).Value = review_approved
                            .Parameters.Add(New SqlParameter("@prop_country", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(prop_country)
                            .Parameters.Add(New SqlParameter("@prop_title", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(prop_title)
                            .Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = stripstring(website)

                            .ExecuteNonQuery()
                        End With

                    Catch ex As Exception
                        returnval = ex.ToString
                    Finally
                        SQLReview.Dispose()
                        oConn.Close()
                    End Try

                End If

            Catch ex As Exception
                returnval = ex.ToString
            End Try
        End If
        Return returnval
    End Function

    Public Structure UserField
        Public UserLocation As String
        Public UserDistance As String
    End Structure
    Public Structure Description
        Public Title As String
        Public Paragraph As String
    End Structure
    Public Structure Location
        Public LocationRef As Long
        Public LocationDescription As String
        Public ParentID As Integer
    End Structure
    Public Structure PropImage
        Public ImageCaption As String
        Public ImageURL As String   'http://www.villarenters.com/data/images/11954_thm_4.jpg
    End Structure
    Public Structure Villa
        Public prop_ref As String
        Public owner_ref As String
        Public PropType As String
        Public Title As String
        Public Summary As String
        Public Descriptions As Description()
        Public PropImages As PropImage()
        Public Filename As String
        Public Locations As Location()
        Public MinPrice As Decimal
        Public MaxPrice As Decimal
        Public Currency As String
        Public Sleeps As String
        Public DoubleBeds As Integer
        Public TwinBeds As Integer
        Public SingleBeds As Integer
        Public Cots As Integer
        Public Bathrooms As Integer
        Public TV As Boolean
        Public Satellite As Boolean
        Public Telephone As Boolean
        Public Cooker As Boolean
        Public Microwave As Boolean
        Public Fridge As Boolean
        Public Freezer As Boolean
        Public Internet As Boolean
        Public CentralHeating As Boolean
        Public LinenProvided As Boolean
        Public AirConditioning As Boolean
        Public Traffic As String
        Public Seaside As Boolean
        Public SightSeeing As Boolean
        Public Tourist As Boolean
        Public Romantic As Boolean
        Public Relaxing As Boolean
        Public Activity As Boolean
        Public Pets As Boolean
        Public OpenFire As Boolean
        Public Garden As Boolean
        Public Patio As Boolean
        Public Balcony As Boolean
        Public PrivatePool As Boolean
        Public SharedPool As Boolean
        Public TennisCourt As Boolean
        Public Parking As Boolean
        Public Airport As String
        Public AirportDistance As String
        Public UserFields As UserField()
        Public MapLink As String
        Public Lon As Double
        Public Lat As Double
        Public Extra As String
        Public Beach As String
        Public Sailing As String
        Public Swimming As String
        Public Walking As String
        Public Cycling As String
        Public HorseRiding As String
        Public Skiing As String
        Public Golf As String
        Public Tennis As String
        Public Climbing As String
        Public Nonesmoking As Boolean
        Public InstantBooking As Boolean
        Public VillarentersIndex As Integer
        Public ExternalRef As String
        Public website As String
        Public Features As String
        Public PriceRange As String
        Public Seo1 As String
        Public Seo2 As String
        Public Seo3 As String
        Public Seo4 As String
        Public Seo5 As String
        Public Seo6 As String
    End Structure

    Public Structure SearchRes
        Public prop_ref As String
        Public owner_ref As String
        Public PropType As String
        Public Title As String
        Public Summary As String
        Public Descriptions As Description()
        Public PropImages As PropImage()
        Public Locations As Location()
        Public Currency As String
        Public Sleeps As String
        Public website As String
        Public Features As String
        Public PriceRange As String
    End Structure

    Public Structure VillaResults
        Public NumberOfRecords As Integer
        Public Villas As Villa()
    End Structure
    Public Structure SearchResults
        Public NumberOfRecords As Integer
        Public Villas As SearchRes()
    End Structure

    <WebMethod(CacheDuration:=10)> _
        Public Function GetPropertyDetails(ByVal prop_ref As String, ByVal website As String) As VillaResults
        prop_ref = stripstring(prop_ref)
        website = stripstring(website)
        Dim strXML
        Dim intloop As Integer = 0
        Dim wsservice As New VR_VillaSearch.villa_search
        Try
            strXML = wsservice.VillaSearchV2("35465G", "", prop_ref, 0, "", 0, 0, 0, False, 0, 0, 0, 1, 500, False, "", "", 0, 0)
        Catch ex As Exception
            strXML = ex.ToString
        End Try

        Try


            Dim strucVilla As VillaResults
            Dim intVillaCount As Integer = strXML.NumberOfRecords
            ReDim strucVilla.Villas(intVillaCount - 1)
            Dim intArrayCount As Integer = 0
            strucVilla.NumberOfRecords = strXML.NumberOfRecords
            strucVilla.Villas(0).Activity = strucVilla.Villas(0).Activity
            strucVilla.Villas(0).AirConditioning = strXML.Villas(0).AirConditioning
            strucVilla.Villas(0).Airport = strXML.Villas(0).Airport
            strucVilla.Villas(0).AirportDistance = strXML.Villas(0).AirportDistance
            strucVilla.Villas(0).Balcony = strXML.Villas(0).Balcony
            strucVilla.Villas(0).Bathrooms = strXML.Villas(0).Bathrooms
            strucVilla.Villas(0).Beach = strXML.Villas(0).Beach
            strucVilla.Villas(0).CentralHeating = strXML.Villas(0).CentralHeating
            strucVilla.Villas(0).Climbing = strXML.Villas(0).Climbing
            strucVilla.Villas(0).Cooker = strXML.Villas(0).Cooker
            strucVilla.Villas(0).Cots = strXML.Villas(0).Cots
            strucVilla.Villas(0).Currency = strXML.Villas(0).Currency
            strucVilla.Villas(0).Cycling = strXML.Villas(0).Cycling

            ReDim strucVilla.Villas(0).Descriptions(strXML.Villas(0).Descriptions.length - 1)
            intloop = 0
            For Each item As Object In strXML.Villas(0).Descriptions
                strucVilla.Villas(0).Descriptions(intloop).Title = item.Title
                strucVilla.Villas(0).Descriptions(intloop).Paragraph = item.Paragraph
                intloop += 1
            Next

            strucVilla.Villas(0).DoubleBeds = strXML.Villas(0).DoubleBeds
            strucVilla.Villas(0).ExternalRef = strXML.Villas(0).ExternalRef
            strucVilla.Villas(0).Extra = strXML.Villas(0).Extra
            strucVilla.Villas(0).Filename = strXML.Villas(0).Filename
            strucVilla.Villas(0).Freezer = strXML.Villas(0).Freezer
            strucVilla.Villas(0).Fridge = strXML.Villas(0).Fridge
            strucVilla.Villas(0).Garden = strXML.Villas(0).Garden
            strucVilla.Villas(0).Golf = strXML.Villas(0).Golf
            strucVilla.Villas(0).HorseRiding = strXML.Villas(0).HorseRiding
            strucVilla.Villas(0).InstantBooking = strXML.Villas(0).InstantBooking
            strucVilla.Villas(0).Internet = strXML.Villas(0).Internet
            strucVilla.Villas(0).Lat = strXML.Villas(0).Lat
            strucVilla.Villas(0).LinenProvided = strXML.Villas(0).LinenProvided

            ReDim strucVilla.Villas(0).Locations(strXML.Villas(0).Locations.length - 1)
            intloop = 0
            For Each item As Object In strXML.Villas(0).Locations
                strucVilla.Villas(0).Locations(intloop).LocationDescription = item.LocationDescription
                strucVilla.Villas(0).Locations(intloop).ParentID = item.ParentID
                strucVilla.Villas(0).Locations(intloop).LocationRef = item.LocationRef
                intloop += 1
            Next

            strucVilla.Villas(0).Lon = strXML.Villas(0).Lon
            strucVilla.Villas(0).MapLink = strXML.Villas(0).MapLink
            strucVilla.Villas(0).MaxPrice = strXML.Villas(0).MaxPrice
            strucVilla.Villas(0).Microwave = strXML.Villas(0).Microwave
            strucVilla.Villas(0).MinPrice = strXML.Villas(0).MinPrice
            strucVilla.Villas(0).Nonesmoking = strXML.Villas(0).Nonesmoking
            strucVilla.Villas(0).OpenFire = strXML.Villas(0).OpenFire
            strucVilla.Villas(0).owner_ref = strXML.Villas(0).owner_ref
            strucVilla.Villas(0).Parking = strXML.Villas(0).Parking
            strucVilla.Villas(0).Patio = strXML.Villas(0).Patio
            strucVilla.Villas(0).Pets = strXML.Villas(0).Pets
            strucVilla.Villas(0).PrivatePool = strXML.Villas(0).PrivatePool
            strucVilla.Villas(0).prop_ref = strXML.Villas(0).prop_ref

            ReDim strucVilla.Villas(0).PropImages(strXML.Villas(0).PropImages.length - 1)
            intloop = 0
            For Each item As Object In strXML.Villas(0).PropImages
                strucVilla.Villas(0).PropImages(intloop).ImageURL = item.ImageURL
                strucVilla.Villas(0).PropImages(intloop).ImageCaption = item.ImageCaption
                intloop += 1
            Next

            strucVilla.Villas(0).PropType = strXML.Villas(0).PropType
            strucVilla.Villas(0).Relaxing = strXML.Villas(0).Relaxing
            strucVilla.Villas(0).Romantic = strXML.Villas(0).Romantic
            strucVilla.Villas(0).Sailing = strXML.Villas(0).Sailing
            strucVilla.Villas(0).Satellite = strXML.Villas(0).Satellite
            strucVilla.Villas(0).Seaside = strXML.Villas(0).Seaside
            strucVilla.Villas(0).SharedPool = strXML.Villas(0).SharedPool
            strucVilla.Villas(0).SightSeeing = strXML.Villas(0).SightSeeing
            strucVilla.Villas(0).SingleBeds = strXML.Villas(0).SingleBeds
            strucVilla.Villas(0).Skiing = strXML.Villas(0).Skiing
            strucVilla.Villas(0).Sleeps = strXML.Villas(0).Sleeps
            strucVilla.Villas(0).Summary = strXML.Villas(0).Summary
            strucVilla.Villas(0).Swimming = strXML.Villas(0).Swimming
            strucVilla.Villas(0).Telephone = strXML.Villas(0).Telephone
            strucVilla.Villas(0).Tennis = strXML.Villas(0).Tennis
            strucVilla.Villas(0).TennisCourt = strXML.Villas(0).TennisCourt
            strucVilla.Villas(0).Title = strXML.Villas(0).Title
            strucVilla.Villas(0).Tourist = strXML.Villas(0).Tourist
            strucVilla.Villas(0).Traffic = strXML.Villas(0).Traffic
            strucVilla.Villas(0).TV = strXML.Villas(0).TV
            strucVilla.Villas(0).TwinBeds = strXML.Villas(0).TwinBeds

            ReDim strucVilla.Villas(0).UserFields(strXML.Villas(0).UserFields.length - 1)
            intloop = 0
            For Each item As Object In strXML.Villas(0).UserFields
                strucVilla.Villas(0).UserFields(intloop).UserLocation = item.UserLocation
                strucVilla.Villas(0).UserFields(intloop).UserDistance = item.UserDistance
                intloop += 1
            Next

            strucVilla.Villas(0).VillarentersIndex = strXML.Villas(0).VillarentersIndex
            strucVilla.Villas(0).Walking = strXML.Villas(0).Walking



            Return strucVilla

        Catch ex As Exception

            Return Nothing

        End Try





    End Function


    <WebMethod(CacheDuration:=10)> _
        Public Function GetSearchResults(ByVal strOwnerRefs As String, ByVal strPropRefs As String, ByVal intPropType As Integer, ByVal strLocationRefs As String, ByVal intMaxPrice As Integer, ByVal intMinPrice As Integer, ByVal intSleeps As Integer, ByVal intPage As Integer, ByVal intItemsPerPage As Integer, ByVal blnEnableAvailabilitySearch As Boolean, ByVal strFromYYYYMMDD As String, ByVal strToYYYYMMDD As String, ByVal intSortOrder As Integer, ByVal website As String, ByVal Keyword As String) As SearchResults
        strOwnerRefs = stripstring(strOwnerRefs)
        strPropRefs = stripstring(strPropRefs)
        Dim strucVilla As SearchResults


        Dim objRow As Data.DataRowView
       
        Dim strFilter As String
        Dim intCount As Integer
        Dim intArrayCount As Integer

        Dim intImageCount As Integer
        Dim intloop As Integer
        Dim strOrderby As String

        Dim dsVillas As DataSet
        Dim dsLocations As DataSet
        Dim dsImages As DataSet
        Dim dsDescriptions As DataSet

        strOrderby = ""
        strFilter = ""

        Try
            If InStr(strOwnerRefs, "--") > 0 Then Err.Raise(101)
            If InStr(strPropRefs, "--") > 0 Then Err.Raise(101)
            If InStr(strLocationRefs, "--") > 0 Then Err.Raise(101)
            If InStr(strFromYYYYMMDD, "--") > 0 Then Err.Raise(101)
            If InStr(strToYYYYMMDD, "--") > 0 Then Err.Raise(101)

            Dim oConn As Data.SqlClient.SqlConnection
            oConn = New SqlClient.SqlConnection
            oConn.ConnectionString = zonchiholidaysConnectionString
            oConn.Open()

            'If website = "lodgesandparks" Then website = "HH" Else website = ""
            website = ""
            Keyword = Trim(Keyword)
            If Keyword > "" Then
                Dim SQLKeyword As New SqlCommand("freetext_search", oConn)
                SQLKeyword.CommandType = CommandType.StoredProcedure
                Dim dsKeyword As DataSet
                Dim intKeywordCount As Integer = 0
                dsKeyword = New DataSet

                
                SQLKeyword.Parameters.Add(New SqlParameter("@freetext_search", SqlDbType.VarChar, 1000, ParameterDirection.Input)).Value = Keyword
                SQLKeyword.Parameters.Add(New SqlParameter("@minmatch", SqlDbType.Int, 1, ParameterDirection.Input)).Value = 1
                SQLKeyword.Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = "" 'website
                SQLKeyword.ExecuteNonQuery()

                Dim daKeyword As New SqlDataAdapter()

                daKeyword.SelectCommand = SQLKeyword
                daKeyword.Fill(dsKeyword)

                intKeywordCount = (dsKeyword.Tables(0).Rows.Count)

                Dim cnt As Integer
                If intKeywordCount > 0 Then
                    strPropRefs = "'firstrecord'"
                    For cnt = 0 To intKeywordCount - 1
                        strPropRefs = strPropRefs & ",'" & dsKeyword.Tables(0).Rows(cnt).Item("prop_ref").ToString & "'"
                    Next
                End If
            End If


            Dim SQLTerms As New SqlCommand("XML_Get_Search_Results", oConn)
            SQLTerms.CommandType = CommandType.StoredProcedure

            dsVillas = New DataSet
            dsImages = New DataSet
            dsLocations = New DataSet
            dsDescriptions = New DataSet

            'If strOwnerRefs <> "" Then strFilter = strFilter & " and owner_details.owner_ref in (" & strOwnerRefs & ")"
            If intPropType > 0 Then
                Select Case intPropType
                    Case 1
                        strFilter = strFilter & " and prop_details.prop_type=" & "'apartment'"
                    Case 2
                        strFilter = strFilter & " and prop_details.prop_type=" & "'boat'"
                    Case 3
                        strFilter = strFilter & " and prop_details.prop_type=" & "'cabin'"
                    Case 4
                        strFilter = strFilter & " and prop_details.prop_type=" & "'castle'"
                    Case 5
                        strFilter = strFilter & " and prop_details.prop_type=" & "'chateau'"
                    Case 6
                        strFilter = strFilter & " and prop_details.prop_type=" & "'cottage'"
                    Case 7
                        strFilter = strFilter & " and prop_details.prop_type=" & "'country house'"
                    Case 8
                        strFilter = strFilter & " and prop_details.prop_type=" & "'farm house'"
                    Case 9
                        strFilter = strFilter & " and prop_details.prop_type=" & "'finca'"
                    Case 10
                        strFilter = strFilter & " and prop_details.prop_type=" & "'gite'"
                    Case 11
                        strFilter = strFilter & " and prop_details.prop_type=" & "'home'"
                    Case 12
                        strFilter = strFilter & " and prop_details.prop_type=" & "'house'"
                    Case 13
                        strFilter = strFilter & " and (prop_details.prop_type=" & "'lodge' or prop_details.prop_type=" & "'park' )"
                    Case 14
                        strFilter = strFilter & " and prop_details.prop_type=" & "'penthouse'"
                    Case 15
                        strFilter = strFilter & " and prop_details.prop_type=" & "'room/studio'"
                    Case 16
                        strFilter = strFilter & " and prop_details.prop_type=" & "'ski chalet'"
                    Case 17
                        strFilter = strFilter & " and prop_details.prop_type=" & "'villa'"
                    Case 18
                        strFilter = strFilter & " and prop_details.prop_type=" & "'village house'"
                End Select

            End If

            

            Select Case website
                Case ""
                Case "lp"
                    strFilter = strFilter & " and prop_details.website='HH'"
                Case Else
                    strFilter = strFilter & " and prop_details.website='" & website & "'"
            End Select
            If strLocationRefs <> "" Then strFilter = strFilter & " and prop_locations.LocationRef in (" & strLocationRefs & ")"
            If strPropRefs <> "" Then strFilter = strFilter & " and prop_details.Prop_ref in (" & strPropRefs & ")"
            If intMaxPrice > 0 Then strFilter = strFilter & " and prop_details.Maxprice <=" & intMaxPrice
            If intMinPrice > 0 Then strFilter = strFilter & " and prop_details.Minprice >=" & intMinPrice
            'If intSleeps > 0 Then strFilter = strFilter & " and prop_contents.Sleeps =" & intSleeps
            'If blnEnableAvailabilitySearch = True Then
            '    strFilter = strFilter & " AND dbo.prop_details.prop_ref IN (SELECT jp.prop_ref"
            '    strFilter = strFilter & " FROM jdates_prop jp"
            '    strFilter = strFilter & " INNER JOIN prop_details pd ON pd.prop_ref=jp.prop_ref"
            '    strFilter = strFilter & " WHERE pd.advert_on=1"
            '    strFilter = strFilter & " AND pd.checked=1"
            '    strFilter = strFilter & " AND pd.finished=1"
            '    strFilter = strFilter & " AND (jp.pabBooked IS NULL OR jp.pabBooked = 0)"
            '    strFilter = strFilter & " AND (jp.pabUnavail IS NULL OR jp.pabUnavail = 0)"
            '    'strFilter = strFilter & " AND jp.jdate BETWEEN convert(datetime, '" & strFromYYYYMMDD & "',126) AND convert(datetime, '" & strToYYYYMMDD & "',126)"
            '    strFilter = strFilter & " AND jp.jdate BETWEEN '" & strFromYYYYMMDD & "' AND '" & strToYYYYMMDD & "'"
            '    strFilter = strFilter & " GROUP BY jp.prop_ref"
            '    'strFilter = strFilter & " HAVING count(jp.prop_ref) = (datediff(d, convert(datetime, '" & strFromYYYYMMDD & "',126), convert(datetime, '" & strToYYYYMMDD & "',126)) + 1))"
            '    strFilter = strFilter & " HAVING count(jp.prop_ref) = (datediff(d,'" & strFromYYYYMMDD & "','" & strToYYYYMMDD & "') + 1))"
            'End If

            If intSortOrder > 0 Then
                Select Case intSortOrder
                    Case 1 'Order by Min price 
                        strOrderby = " ORDER BY prop_details.minprice"
                    Case 2 'Order by Max price
                        strOrderby = " ORDER BY prop_details.maxprice"
                    Case 3 'Order by Title
                        strOrderby = " ORDER BY prop_details.Title"
                    Case 4 'Order by Type
                        strOrderby = " ORDER BY prop_details.prop_type"
                        'Case 5 'Order by Sleeps
                        '   strOrderby = " ORDER BY prop_contents.sleeps"
                End Select

            Else
                strOrderby = ""
            End If

            Dim firstlistsearch As String = ""
            firstlistsearch = strPropRefs


            If strFilter = Nothing Then strFilter = ""
            Dim objParam As New OleDb.OleDbParameter
            Dim intVillaCount As Integer

            'get location properties first
            SQLTerms.Parameters.Add(New SqlParameter("@ReturnNRecords", SqlDbType.Int, 1, ParameterDirection.Input)).Value = 0
            SQLTerms.Parameters.Add(New SqlParameter("@Filter", SqlDbType.Text)).Value = strFilter
            SQLTerms.Parameters.Add(New SqlParameter("@OrderBy", SqlDbType.VarChar, 4000, ParameterDirection.Input)).Value = strOrderby
            SQLTerms.ExecuteNonQuery()
	response.write(strFilter)
response.end
            Dim daVillas As New SqlDataAdapter()

            daVillas.SelectCommand = SQLTerms
            daVillas.Fill(dsVillas)

            'Try
            '    intVillaCount = (dsVillas.Tables(0).Rows.Count)
            '    Dim locrecstr As String = ""

            '    Dim cntr As Integer
            '    If intVillaCount > 0 Then
            '        locrecstr = "'firstrecord'"
            '        For cntr = 0 To intVillaCount - 1
            '            locrecstr = locrecstr & ",'" & PurgeString(dsVillas.Tables(0).Rows(cntr).Item("prop_ref").ToString) & "'"
            '        Next
            '        If Len(locrecstr) > 13 Then
            '            strPropRefs = locrecstr '& "," & strPropRefs
            '        End If
            '    End If
            'Catch ex As Exception

            'End Try

            'now add these to the string list and requery

            strucVilla.NumberOfRecords = dsVillas.Tables(0).Rows.Count
            'if no location ones get by keywords
            If strucVilla.NumberOfRecords = 0 Then
                If strPropRefs <> "" Then strFilter = strFilter & " and prop_details.prop_ref in (" & strPropRefs & ")"
                strFilter = Replace(strFilter, " and prop_locations.LocationRef in (" & strLocationRefs & ")", "")
                SQLTerms.Parameters.Clear()
                SQLTerms.Parameters.Add(New SqlParameter("@ReturnNRecords", SqlDbType.Int, 1, ParameterDirection.Input)).Value = 0
                SQLTerms.Parameters.Add(New SqlParameter("@Filter", SqlDbType.Text)).Value = strFilter
                SQLTerms.Parameters.Add(New SqlParameter("@OrderBy", SqlDbType.VarChar, 4000, ParameterDirection.Input)).Value = strOrderby
                SQLTerms.ExecuteNonQuery()
                dsVillas.Clear()

                daVillas.SelectCommand = SQLTerms
                daVillas.Fill(dsVillas)
                strucVilla.NumberOfRecords = dsVillas.Tables(0).Rows.Count

            End If

            intVillaCount = (dsVillas.Tables(0).Rows.Count)

            ReDim strucVilla.Villas(intVillaCount - 1)
            intCount = ((intPage - 1) * intItemsPerPage)
            For intArrayCount = 0 To intVillaCount - 1
                objRow = dsVillas.Tables(0).DefaultView.Item(intCount)
                strucVilla.Villas(intArrayCount).Title = PurgeString(objRow.Item("Title"))
                strucVilla.Villas(intArrayCount).prop_ref = PurgeString(objRow.Item("prop_ref"))
                strucVilla.Villas(intArrayCount).PropType = PurgeString(objRow.Item("Prop_Type"))

                strucVilla.Villas(intArrayCount).Summary = PurgeString(Left(objRow.Item("Summary"), 300))
                If Len(strucVilla.Villas(intArrayCount).Summary) = 300 Then strucVilla.Villas(intArrayCount).Summary = strucVilla.Villas(intArrayCount).Summary + " ... more"
                strucVilla.Villas(intArrayCount).PriceRange = PurgeString(objRow.Item("PriceRange"))

                strucVilla.Villas(intArrayCount).Currency = PurgeString(objRow.Item("Currency"))

                strucVilla.Villas(intArrayCount).Features = PurgeString(Left(objRow.Item("features"), 300))
                If Len(strucVilla.Villas(intArrayCount).Features) = 300 Then strucVilla.Villas(intArrayCount).Features = strucVilla.Villas(intArrayCount).Features + " ... more"


                If objRow.Item("PriceRange") Is DBNull.Value Then
                    strucVilla.Villas(intArrayCount).PriceRange = 0
                Else
                    strucVilla.Villas(intArrayCount).PriceRange = PurgeString(objRow.Item("PriceRange"))
                End If

                strucVilla.Villas(intArrayCount).website = PurgeString(objRow.Item("website"))


                '*Get Images
                Dim SQLImages As New SqlCommand("XML_Get_Images_by_PropRef", oConn)
                SQLImages.CommandType = CommandType.StoredProcedure

                SQLImages.Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = objRow.Item("prop_ref")
                SQLImages.Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = objRow.Item("website")
                SQLImages.ExecuteNonQuery()

                daVillas.SelectCommand = SQLImages
                If dsImages.Tables.Count > 0 Then dsImages.Tables(0).Clear()
                daVillas.Fill(dsImages)

                intImageCount = dsImages.Tables(0).Rows.Count

                ReDim strucVilla.Villas(intArrayCount).PropImages(intImageCount - 1)
                Dim objRowImage

                For intloop = 1 To intImageCount

                    objRowImage = dsImages.Tables(0).DefaultView.Item(intloop - 1)

                    If dsImages.Tables(0).Rows.Count > 0 Then
                        strucVilla.Villas(intArrayCount).PropImages(intloop - 1).ImageURL = objRowImage("ImageURL")
                        strucVilla.Villas(intArrayCount).PropImages(intloop - 1).ImageCaption = objRowImage("ImageCaption")
                    Else
                        strucVilla.Villas(intArrayCount).PropImages(intloop - 1).ImageURL = ""
                        strucVilla.Villas(intArrayCount).PropImages(intloop - 1).ImageCaption = ""
                    End If
                Next

                '*Get Locations
                Dim SQLLocations As New SqlCommand("XML_Get_Prop_Locations_by_PropRef", oConn)
                SQLLocations.CommandType = CommandType.StoredProcedure

                SQLLocations.Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = PurgeString(objRow.Item("prop_ref"))
                SQLLocations.Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = PurgeString(objRow.Item("website"))
                SQLLocations.ExecuteNonQuery()

                daVillas.SelectCommand = SQLLocations
                If dsLocations.Tables.Count > 0 Then dsLocations.Tables(0).Clear()
                daVillas.Fill(dsLocations)

                intImageCount = dsLocations.Tables(0).Rows.Count

                ReDim strucVilla.Villas(intArrayCount).Locations(intImageCount - 1)

                For intloop = 1 To intImageCount
                    strucVilla.Villas(intArrayCount).Locations(intloop - 1).LocationDescription = PurgeString(dsLocations.Tables(0).Rows(intloop - 1).Item("LocationDescription"))
                    strucVilla.Villas(intArrayCount).Locations(intloop - 1).ParentID = PurgeString(dsLocations.Tables(0).Rows(intloop - 1).Item("ParentID"))
                    strucVilla.Villas(intArrayCount).Locations(intloop - 1).LocationRef = PurgeString(dsLocations.Tables(0).Rows(intloop - 1).Item("LocationRef"))
                Next

                intCount = intCount + 1

            Next
            GetSearchResults = strucVilla
            oConn.Close()
        Catch
            GetSearchResults = Nothing
        End Try
    End Function

    Function TitleCase(ByVal TitleString) As String
        TitleString = LCase(TitleString)
        Dim TempString, NextCap, CurrentChar

        NextCap = True
        TempString = ""
        For CurrentChar = 1 To Len(TitleString)
            If NextCap = True Then
                TempString = TempString & UCase(Mid(TitleString, CurrentChar, 1))
                NextCap = False

            Else
                TempString = TempString & Mid(TitleString, CurrentChar, 1)
            End If
            If InStr(" ({[""""", Mid(TitleString, CurrentChar, 1)) > 0 Then
                NextCap = True
            End If
        Next

        TitleCase = TempString

    End Function

    'get locations
    Public Structure ChildLocation
        Public RequestedParentID As Integer
        Public ChildLocations() As Location
    End Structure
    <WebMethod(CacheDuration:=10)> _
        Public Function GetLocations(ByVal ParentID As String, ByVal website As String, ByVal Filter As String) As ChildLocation
        ParentID = stripstring(ParentID)
        website = stripstring(website)
        Filter = stripstring(Filter)


        Try
            Dim objRow As Data.DataRowView

            Dim GetCountryList2 As New ChildLocation
            Dim intLocationsCount As Integer
            Dim dsLocations As New DataSet("dsReviews")
            Dim daLocations As New SqlDataAdapter()
            Dim dvLocations As New DataView

            Dim oConn As Data.SqlClient.SqlConnection
            oConn = New SqlClient.SqlConnection
            oConn.ConnectionString = zonchiholidaysConnectionString
            oConn.Open()

            Dim SQLTerms As New SqlCommand("get_locations", oConn)
            SQLTerms.CommandType = CommandType.StoredProcedure
            SQLTerms.Parameters.Add(New SqlParameter("@cat_parent", SqlDbType.Int, 1, ParameterDirection.Input)).Value = ParentID
            SQLTerms.Parameters.Add(New SqlParameter("@filter", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Filter
            SQLTerms.Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = website
            SQLTerms.ExecuteNonQuery()

            daLocations.SelectCommand = SQLTerms
            daLocations.Fill(dsLocations)
            dvLocations = New DataView(dsLocations.Tables(0))
            ReDim Preserve GetCountryList2.ChildLocations(dvLocations.Count - 1)
            GetCountryList2.RequestedParentID = ParentID
            For Each objRow In dvLocations
                GetCountryList2.ChildLocations(intLocationsCount).LocationDescription = objRow.Item("cat_description")
                GetCountryList2.ChildLocations(intLocationsCount).LocationRef = objRow.Item("cat_ref")
                GetCountryList2.ChildLocations(intLocationsCount).ParentID = objRow.Item("cat_parent")
                intLocationsCount = intLocationsCount + 1
            Next

            GetLocations = GetCountryList2
            oConn.Close()
        Catch
            GetLocations = Nothing
        End Try

    End Function
    <WebMethod(CacheDuration:=10)> _
        Public Function GetRefBySitecode(ByVal sitecode As String, ByVal productFilter As String) As String
        sitecode = stripstring(sitecode)
        productFilter = stripstring(productFilter)
        
        Try
            Dim objRow As Data.DataRowView

            Dim GetCountryList2 As New ChildLocation
            Dim dsLocations As New DataSet("dsReviews")
            Dim daLocations As New SqlDataAdapter()
            Dim dvLocations As New DataView

            Dim oConn As Data.SqlClient.SqlConnection
            oConn = New SqlClient.SqlConnection
            oConn.ConnectionString = zonchiholidaysConnectionString
            oConn.Open()

            Dim SQLTerms As New SqlCommand("get_PropRef_from_sitecode", oConn)
            SQLTerms.CommandType = CommandType.StoredProcedure
            SQLTerms.Parameters.Add(New SqlParameter("@sitecode", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = UCase(sitecode)
            SQLTerms.Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = productFilter
            SQLTerms.ExecuteNonQuery()

            daLocations.SelectCommand = SQLTerms
            daLocations.Fill(dsLocations)
            dvLocations = New DataView(dsLocations.Tables(0))
            Dim firstrec As Boolean = True

            For Each objRow In dvLocations
                If firstrec Then
                    GetRefBySitecode = "'" & objRow.Item("prop_ref") & "'"
                    firstrec = False
                Else
                    GetRefBySitecode = GetRefBySitecode & ",'" & objRow.Item("prop_ref") & "'"
                End If
            Next

            oConn.Close()
        Catch
            GetRefBySitecode = Nothing
        End Try

    End Function
    <WebMethod(CacheDuration:=10)> _
        Public Function GetAllLocationsfromCatref(ByVal CatRef As Integer, ByVal productfilter As String) As ChildLocation
        productfilter = stripstring(productfilter)
        
        Try
            Dim objRow As Data.DataRowView

            Dim GetCountryList2 As New ChildLocation
            Dim intLocationsCount As Integer
            Dim dsLocations As New DataSet("dsReviews")
            Dim daLocations As New SqlDataAdapter()
            Dim dvLocations As New DataView

            Dim oConn As Data.SqlClient.SqlConnection
            oConn = New SqlClient.SqlConnection
            oConn.ConnectionString = zonchiholidaysConnectionString
            oConn.Open()

            Dim SQLTerms As New SqlCommand("get_SearchRetrieveLocations", oConn)
            SQLTerms.CommandType = CommandType.StoredProcedure
            SQLTerms.Parameters.Add(New SqlParameter("@CatRef", SqlDbType.Int, 1, ParameterDirection.Input)).Value = CatRef
            SQLTerms.Parameters.Add(New SqlParameter("@productFilter", SqlDbType.VarChar, 255, ParameterDirection.Input)).Value = productfilter
            SQLTerms.ExecuteNonQuery()

            daLocations.SelectCommand = SQLTerms
            daLocations.Fill(dsLocations)
            dvLocations = New DataView(dsLocations.Tables(0))
            ReDim Preserve GetCountryList2.ChildLocations(dvLocations.Count - 1)
            GetCountryList2.RequestedParentID = CatRef
            For Each objRow In dvLocations
                GetCountryList2.ChildLocations(intLocationsCount).LocationDescription = objRow.Item("cat_description")
                GetCountryList2.ChildLocations(intLocationsCount).LocationRef = objRow.Item("cat_ref")
                GetCountryList2.ChildLocations(intLocationsCount).ParentID = objRow.Item("count")
                intLocationsCount = intLocationsCount + 1
            Next

            oConn.Close()
            GetAllLocationsfromCatref = GetCountryList2
        Catch
            GetAllLocationsfromCatref = Nothing
        End Try

    End Function
    <WebMethod(CacheDuration:=10)> _
        Public Function getlowestlocationforpropref(ByVal prop_ref As String, ByVal productfilter As String) As String
        prop_ref = stripstring(prop_ref)
        productfilter = stripstring(productfilter)
        
        Try
            Dim dsLocations As New DataSet("dsReviews")
            Dim daLocations As New SqlDataAdapter()
            Dim dvLocations As New DataView

            Dim oConn As Data.SqlClient.SqlConnection
            oConn = New SqlClient.SqlConnection
            oConn.ConnectionString = zonchiholidaysConnectionString
            oConn.Open()

            Dim SQLTerms As New SqlCommand("get_lowest_location_for_prop_ref", oConn)
            SQLTerms.CommandType = CommandType.StoredProcedure
            SQLTerms.Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 255, ParameterDirection.Input)).Value = prop_ref
            SQLTerms.Parameters.Add(New SqlParameter("@productFilter", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = productfilter
            SQLTerms.ExecuteNonQuery()

            daLocations.SelectCommand = SQLTerms
            daLocations.Fill(dsLocations)

            getlowestlocationforpropref = dsLocations.Tables(0).Rows(0).Item("cat_ref")

            oConn.Close()

        Catch
            getlowestlocationforpropref = Nothing
        End Try

    End Function
    <WebMethod(CacheDuration:=10)> _
        Public Function GetAllLocationsfromDescription(ByVal description As String, ByVal productfilter As String) As ChildLocation
        description = stripstring(description)
        productfilter = stripstring(productfilter)
        Try
            Dim objRow As Data.DataRowView

            Dim GetCountryList2 As New ChildLocation
            Dim intLocationsCount As Integer
            Dim dsLocations As New DataSet("dsReviews")
            Dim daLocations As New SqlDataAdapter()
            Dim dvLocations As New DataView

            Dim oConn As Data.SqlClient.SqlConnection
            oConn = New SqlClient.SqlConnection
            oConn.ConnectionString = zonchiholidaysConnectionString
            oConn.Open()

            Dim SQLTerms As New SqlCommand("get_SearchRetrieveLocations_fromname", oConn)
            SQLTerms.CommandType = CommandType.StoredProcedure
            SQLTerms.Parameters.Add(New SqlParameter("@description", SqlDbType.VarChar, 255, ParameterDirection.Input)).Value = description
            SQLTerms.Parameters.Add(New SqlParameter("@productFilter", SqlDbType.VarChar, 255, ParameterDirection.Input)).Value = productfilter
            SQLTerms.ExecuteNonQuery()

            daLocations.SelectCommand = SQLTerms
            daLocations.Fill(dsLocations)
            dvLocations = New DataView(dsLocations.Tables(0))
            ReDim Preserve GetCountryList2.ChildLocations(dvLocations.Count - 1)
            GetCountryList2.RequestedParentID = -1
            For Each objRow In dvLocations
                GetCountryList2.ChildLocations(intLocationsCount).LocationDescription = objRow.Item("cat_description")
                GetCountryList2.ChildLocations(intLocationsCount).LocationRef = objRow.Item("cat_ref")
                GetCountryList2.ChildLocations(intLocationsCount).ParentID = objRow.Item("count")
                intLocationsCount = intLocationsCount + 1
            Next

            oConn.Close()
            GetAllLocationsfromDescription = GetCountryList2
        Catch
            GetAllLocationsfromDescription = Nothing
        End Try

    End Function
    <WebMethod(CacheDuration:=10)> _
           Public Function GetALLPropertyDetails(ByVal strPropRefs As String, ByVal website As String) As VillaResults
        'Public Function GetALLPropertyDetails(ByVal strOwnerRefs As String, ByVal strPropRefs As String, ByVal intPropType As Integer, ByVal strLocationRefs As String, ByVal intMaxPrice As Integer, ByVal intMinPrice As Integer, ByVal intSleeps As Integer, ByVal blnInstantBooking As Boolean, ByVal intVillarentersIndex As Integer, ByVal intDiscountType As Integer, ByVal intBranding As Integer, ByVal intPage As Integer, ByVal intItemsPerPage As Integer, ByVal blnEnableAvailabilitySearch As Boolean, ByVal strFromYYYYMMDD As String, ByVal strToYYYYMMDD As String, ByVal intSortOrder As Integer, ByVal website As String, ByVal filter As String) As VillaResults
        strPropRefs = stripstring(strPropRefs)
        website = stripstring(website)
        Dim strucVilla As VillaResults


        Dim objRow As Data.DataRowView
        Dim objRowImage As Data.DataRowView

        Dim strFilter As String
        Dim intCount As Integer
        Dim intArrayCount As Integer

        Dim intImageCount As Integer
        Dim intloop As Integer
        Dim strOrderby As String

        Dim dsVillas As DataSet
        Dim dsLocations As DataSet
        Dim dsImages As DataSet
        Dim dsDescriptions As DataSet
        Dim dsSEO As DataSet

        strOrderby = ""
        strFilter = ""

        Try
            'If InStr(strOwnerRefs, "--") > 0 Then Err.Raise(101)
            If InStr(strPropRefs, "--") > 0 Then Err.Raise(101)
            'If InStr(strLocationRefs, "--") > 0 Then Err.Raise(101)
            'If InStr(strFromYYYYMMDD, "--") > 0 Then Err.Raise(101)
            'If InStr(strToYYYYMMDD, "--") > 0 Then Err.Raise(101)

            Dim oConn As Data.SqlClient.SqlConnection
            oConn = New SqlClient.SqlConnection
            oConn.ConnectionString = zonchiholidaysConnectionString
            oConn.Open()

            Dim SQLTerms As New SqlCommand("XML_WebService_VillaSearchV2", oConn)
            SQLTerms.CommandType = CommandType.StoredProcedure

            dsVillas = New DataSet
            dsImages = New DataSet
            dsLocations = New DataSet
            dsDescriptions = New DataSet
            dsSEO = New DataSet
            'If strOwnerRefs <> "" Then strFilter = strFilter & " and owner_details.owner_ref in (" & strOwnerRefs & ")"
            If strPropRefs <> "" Then strFilter = strFilter & " and prop_details.prop_ref = '" & strPropRefs & "'"


            Select Case website
                Case "lp"
                    strFilter = strFilter & " and prop_contents.website='HH'"
                Case Else
                    strFilter = strFilter & " and prop_contents.website='" & website & "'"
            End Select

            Dim intVillaCount As Integer

            SQLTerms.Parameters.Add(New SqlParameter("@ReturnNRecords", SqlDbType.Int, 1, ParameterDirection.Input)).Value = 1
            SQLTerms.Parameters.Add(New SqlParameter("@Filter", SqlDbType.VarChar, 4000, ParameterDirection.Input)).Value = strFilter
            SQLTerms.Parameters.Add(New SqlParameter("@OrderBy", SqlDbType.VarChar, 4000, ParameterDirection.Input)).Value = ""
            SQLTerms.ExecuteNonQuery()

            Dim daVillas As New SqlDataAdapter()

            daVillas.SelectCommand = SQLTerms
            daVillas.Fill(dsVillas)

            strucVilla.NumberOfRecords = dsVillas.Tables(1).Rows(0).Item(0)
            
            intVillaCount = (dsVillas.Tables(1).Rows.Count)
            
            ReDim strucVilla.Villas(intVillaCount - 1)
            intCount = 0
            For intArrayCount = 0 To intVillaCount - 1
                objRow = dsVillas.Tables(0).DefaultView.Item(intCount)
                strucVilla.Villas(intArrayCount).Activity = objRow.Item("activity")
                strucVilla.Villas(intArrayCount).AirConditioning = objRow.Item("air_conditioning")
                If objRow.Item("Airport") Is DBNull.Value Or objRow.Item("Airport") Is DBNull.Value Then
                    strucVilla.Villas(intArrayCount).Airport = ""
                    strucVilla.Villas(intArrayCount).AirportDistance = ""
                Else
                    strucVilla.Villas(intArrayCount).Airport = objRow.Item("Airport")
                    strucVilla.Villas(intArrayCount).AirportDistance = objRow.Item("airport_distance")
                End If

                strucVilla.Villas(intArrayCount).Balcony = objRow.Item("Balcony")
                strucVilla.Villas(intArrayCount).Bathrooms = objRow.Item("Bathrooms")

                strucVilla.Villas(intArrayCount).Beach = objRow.Item("Beach")

                strucVilla.Villas(intArrayCount).CentralHeating = objRow.Item("Central_Heating")

                strucVilla.Villas(intArrayCount).Climbing = objRow.Item("Climbing")

                strucVilla.Villas(intArrayCount).Cooker = objRow.Item("cooker")
                strucVilla.Villas(intArrayCount).Cots = objRow.Item("cots")
                strucVilla.Villas(intArrayCount).Currency = objRow.Item("Currency")


                strucVilla.Villas(intArrayCount).Cycling = objRow.Item("Climbing")

                strucVilla.Villas(intArrayCount).Summary = objRow.Item("Summary")
                strucVilla.Villas(intArrayCount).DoubleBeds = objRow.Item("double_beds")

                If objRow.Item("Extra") Is DBNull.Value Or objRow.Item("Extra") Is DBNull.Value Then

                    strucVilla.Villas(intArrayCount).Extra = ""
                Else
                    strucVilla.Villas(intArrayCount).Extra = objRow.Item("extra")
                End If
                strucVilla.Villas(intArrayCount).Features = objRow.Item("Features")
                strucVilla.Villas(intArrayCount).Fridge = objRow.Item("Fridge")
                strucVilla.Villas(intArrayCount).Freezer = objRow.Item("Freezer")
                strucVilla.Villas(intArrayCount).Garden = objRow.Item("Garden")

                strucVilla.Villas(intArrayCount).Golf = objRow.Item("Golf")
                strucVilla.Villas(intArrayCount).HorseRiding = objRow.Item("HorseRiding")

                If objRow.Item("instant_on") Is DBNull.Value Then
                    strucVilla.Villas(intArrayCount).InstantBooking = 0
                Else
                    strucVilla.Villas(intArrayCount).InstantBooking = objRow("instant_on")
                End If
                strucVilla.Villas(intArrayCount).Internet = objRow.Item("internet")
                strucVilla.Villas(intArrayCount).Lat = objRow.Item("Lat")
                strucVilla.Villas(intArrayCount).Lon = objRow.Item("Lon")
                strucVilla.Villas(intArrayCount).LinenProvided = objRow.Item("linen_provided")
                strucVilla.Villas(intArrayCount).MapLink = objRow.Item("MapLink")
                strucVilla.Villas(intArrayCount).Microwave = objRow.Item("Microwave")
                strucVilla.Villas(intArrayCount).Nonesmoking = objRow.Item("non_smoking")
                strucVilla.Villas(intArrayCount).OpenFire = objRow.Item("Open_Fire")
                strucVilla.Villas(intArrayCount).owner_ref = objRow.Item("owner_ref")
                strucVilla.Villas(intArrayCount).Parking = objRow.Item("Parking")
                strucVilla.Villas(intArrayCount).Patio = objRow.Item("Patio")
                strucVilla.Villas(intArrayCount).Pets = objRow.Item("Pets")
                strucVilla.Villas(intArrayCount).PrivatePool = objRow.Item("pool_private")
                strucVilla.Villas(intArrayCount).prop_ref = objRow.Item("Prop_ref")
                strucVilla.Villas(intArrayCount).PropType = objRow.Item("Prop_type")
                strucVilla.Villas(intArrayCount).Relaxing = objRow.Item("Relaxing")
                strucVilla.Villas(intArrayCount).Romantic = objRow.Item("Romantic")

                strucVilla.Villas(intArrayCount).Sailing = objRow.Item("Sailing")

                strucVilla.Villas(intArrayCount).Satellite = objRow.Item("satellite")
                strucVilla.Villas(intArrayCount).Seaside = objRow.Item("seaside")
                strucVilla.Villas(intArrayCount).SharedPool = objRow.Item("pool_communal")
                strucVilla.Villas(intArrayCount).SightSeeing = objRow.Item("sight_seeing")
                strucVilla.Villas(intArrayCount).SingleBeds = objRow.Item("single_beds")

                strucVilla.Villas(intArrayCount).Skiing = objRow.Item("Skiing")
                strucVilla.Villas(intArrayCount).Sleeps = objRow.Item("Sleeps")

                strucVilla.Villas(intArrayCount).Swimming = objRow.Item("Swimming")

                strucVilla.Villas(intArrayCount).Swimming = objRow.Item("single_beds")
                strucVilla.Villas(intArrayCount).Telephone = objRow.Item("single_beds")

                strucVilla.Villas(intArrayCount).Tennis = objRow.Item("Tennis")


                strucVilla.Villas(intArrayCount).TennisCourt = objRow.Item("tennis_court")
                strucVilla.Villas(intArrayCount).Title = TitleCase(objRow.Item("title"))
                strucVilla.Villas(intArrayCount).Tourist = objRow.Item("Tourist")
                strucVilla.Villas(intArrayCount).Traffic = objRow.Item("traffic")
                strucVilla.Villas(intArrayCount).TV = objRow.Item("TV")
                strucVilla.Villas(intArrayCount).TwinBeds = objRow.Item("twin_beds")

                If objRow.Item("user4") <> "" Then
                    ReDim strucVilla.Villas(intArrayCount).UserFields(3)
                ElseIf objRow.Item("user3") <> "" Then
                    ReDim strucVilla.Villas(intArrayCount).UserFields(2)
                ElseIf objRow.Item("user2") <> "" Then
                    ReDim strucVilla.Villas(intArrayCount).UserFields(1)
                ElseIf objRow.Item("user1") <> "" Then
                    ReDim strucVilla.Villas(intArrayCount).UserFields(0)
                End If
                If Not strucVilla.Villas(intArrayCount).UserFields Is Nothing Then
                    For intloop = 0 To strucVilla.Villas(intArrayCount).UserFields.Length - 1
                        strucVilla.Villas(intArrayCount).UserFields(intloop).UserLocation = objRow.Item("user" & intloop + 1)
                        strucVilla.Villas(intArrayCount).UserFields(intloop).UserDistance = objRow.Item("user" & intloop + 1 & "_distance") & " " & objRow.Item("user" & intloop + 1 & "_units")
                    Next
                End If
                strucVilla.Villas(intArrayCount).VillarentersIndex = objRow.Item("VillarentersIndex")

                strucVilla.Villas(intArrayCount).Walking = objRow.Item("Walking")

                strucVilla.Villas(intArrayCount).Filename = ""

                If objRow.Item("maxprice") Is DBNull.Value Then
                    strucVilla.Villas(intArrayCount).MaxPrice = 0
                Else
                    strucVilla.Villas(intArrayCount).MaxPrice = objRow.Item("maxprice")
                End If
                If objRow.Item("maxprice") Is DBNull.Value Then
                    strucVilla.Villas(intArrayCount).MaxPrice = 0
                Else
                    strucVilla.Villas(intArrayCount).MinPrice = objRow.Item("minprice")
                End If
                strucVilla.Villas(intArrayCount).PriceRange = objRow.Item("PriceRange")
                If objRow.Item("instant_on") Is DBNull.Value Then
                    strucVilla.Villas(intArrayCount).InstantBooking = 0
                Else
                    strucVilla.Villas(intArrayCount).InstantBooking = objRow("instant_on")
                End If

                If objRow.Item("external_ref") Is DBNull.Value Then
                    strucVilla.Villas(intArrayCount).ExternalRef = ""
                Else
                    strucVilla.Villas(intArrayCount).ExternalRef = objRow.Item("external_ref")
                End If

                strucVilla.Villas(intArrayCount).website = objRow.Item("website")

                '*Get Images
                Dim SQLImages As New SqlCommand("XML_Get_Images_by_PropRef", oConn)
                SQLImages.CommandType = CommandType.StoredProcedure

                SQLImages.Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = objRow.Item("prop_ref")
                SQLImages.Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = objRow.Item("website")
                SQLImages.ExecuteNonQuery()

                daVillas.SelectCommand = SQLImages
                If dsImages.Tables.Count > 0 Then dsImages.Tables(0).Clear()
                daVillas.Fill(dsImages)

                intImageCount = dsImages.Tables(0).Rows.Count

                ReDim strucVilla.Villas(intArrayCount).PropImages(intImageCount - 1)

                For intloop = 1 To intImageCount

                    objRowImage = dsImages.Tables(0).DefaultView.Item(intloop - 1)

                    If dsImages.Tables(0).Rows.Count > 0 Then
                        strucVilla.Villas(intArrayCount).PropImages(intloop - 1).ImageURL = objRowImage("ImageURL")
                        strucVilla.Villas(intArrayCount).PropImages(intloop - 1).ImageCaption = objRowImage("ImageCaption")
                    Else
                        strucVilla.Villas(intArrayCount).PropImages(intloop - 1).ImageURL = ""
                        strucVilla.Villas(intArrayCount).PropImages(intloop - 1).ImageCaption = ""
                    End If
                Next


                '*Get Locations
                Dim SQLLocations As New SqlCommand("XML_Get_Prop_Locations_by_PropRef", oConn)
                SQLLocations.CommandType = CommandType.StoredProcedure

                SQLLocations.Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = objRow.Item("prop_ref")
                SQLLocations.Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = objRow.Item("website")
                SQLLocations.ExecuteNonQuery()

                daVillas.SelectCommand = SQLLocations
                If dsLocations.Tables.Count > 0 Then dsLocations.Tables(0).Clear()
                daVillas.Fill(dsLocations)

                intImageCount = dsLocations.Tables(0).Rows.Count

                ReDim strucVilla.Villas(intArrayCount).Locations(intImageCount - 1)

                For intloop = 1 To intImageCount
                    strucVilla.Villas(intArrayCount).Locations(intloop - 1).LocationDescription = dsLocations.Tables(0).Rows(intloop - 1).Item("LocationDescription")
                    strucVilla.Villas(intArrayCount).Locations(intloop - 1).ParentID = dsLocations.Tables(0).Rows(intloop - 1).Item("ParentID")
                    strucVilla.Villas(intArrayCount).Locations(intloop - 1).LocationRef = dsLocations.Tables(0).Rows(intloop - 1).Item("LocationRef")
                Next

                '*Get Descriptions
                Dim SQLDescriptions As New SqlCommand("XML_Get_Prop_Descriptions", oConn)
                SQLDescriptions.CommandType = CommandType.StoredProcedure

                SQLDescriptions.Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = objRow.Item("prop_ref")
                SQLDescriptions.Parameters.Add(New SqlParameter("@website", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = objRow.Item("website")
                SQLDescriptions.ExecuteNonQuery()

                daVillas.SelectCommand = SQLDescriptions
                If dsDescriptions.Tables.Count > 0 Then dsDescriptions.Tables(0).Clear()
                daVillas.Fill(dsDescriptions)

                intImageCount = dsDescriptions.Tables(0).Rows.Count
                ReDim strucVilla.Villas(intArrayCount).Descriptions(intImageCount - 1)

                For intloop = 1 To intImageCount
                    If dsDescriptions.Tables(0).Rows(intloop - 1).Item("Title") = "" Then
                        strucVilla.Villas(intArrayCount).Descriptions(intloop - 1).Title = "Description"
                    Else
                        strucVilla.Villas(intArrayCount).Descriptions(intloop - 1).Title = dsDescriptions.Tables(0).Rows(intloop - 1).Item("Title")
                    End If
                    strucVilla.Villas(intArrayCount).Descriptions(intloop - 1).Paragraph = Replace(dsDescriptions.Tables(0).Rows(intloop - 1).Item("Paragraph"), vbCrLf, "<BR>")
                Next

                '*Get Descriptions
                Dim SQLSEO As New SqlCommand("advert_get_seo_text", oConn)
                SQLSEO.CommandType = CommandType.StoredProcedure

                SQLSEO.Parameters.Add(New SqlParameter("@prop_ref", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = objRow.Item("prop_ref")
                SQLSEO.ExecuteNonQuery()

                daVillas.SelectCommand = SQLSEO
                If dsSEO.Tables.Count > 0 Then dsSEO.Tables(0).Clear()
                daVillas.Fill(dsSEO)
                Try
                    strucVilla.Villas(intArrayCount).Seo1 = " " & dsSEO.Tables(0).Rows(0).Item("seo1")
                Catch ex As Exception
                    strucVilla.Villas(intArrayCount).Seo1 = " "
                End Try
                Try
                    strucVilla.Villas(intArrayCount).Seo2 = " " & dsSEO.Tables(0).Rows(0).Item("seo2")
                Catch ex As Exception
                    strucVilla.Villas(intArrayCount).Seo2 = " "
                End Try
                Try
                    strucVilla.Villas(intArrayCount).Seo3 = " " & dsSEO.Tables(0).Rows(0).Item("seo3")
                Catch ex As Exception
                    strucVilla.Villas(intArrayCount).Seo3 = " "
                End Try
                Try
                    strucVilla.Villas(intArrayCount).Seo4 = " " & dsSEO.Tables(0).Rows(0).Item("seo4")
                Catch ex As Exception
                    strucVilla.Villas(intArrayCount).Seo4 = " "
                End Try
                Try
                    strucVilla.Villas(intArrayCount).Seo5 = " " & dsSEO.Tables(0).Rows(0).Item("seo5")
                Catch ex As Exception
                    strucVilla.Villas(intArrayCount).Seo5 = " "
                End Try
                Try
                    strucVilla.Villas(intArrayCount).Seo6 = " " & dsSEO.Tables(0).Rows(0).Item("seo6")
                Catch ex As Exception
                    strucVilla.Villas(intArrayCount).Seo6 = " "
                End Try
               
            intCount = intCount + 1

            Next
            GetALLPropertyDetails = strucVilla
            oConn.Close()
        Catch
            GetALLPropertyDetails = Nothing
        End Try
    End Function
    Function PurgeString(ByVal OldStr As String) As String
        Dim NewStr As String = ""
        Dim l As Long
        For l = 1 To Len(OldStr)
            If Asc(Mid(OldStr, l, 1)) > 31 Then
                NewStr = NewStr & Mid(OldStr, l, 1)
            End If
        Next
        PurgeString = NewStr
    End Function
    Function Filterbyproductfilter(ByVal productfilter As String) As String
        productfilter = stripstring(productfilter)

        Select Case productfilter
            Case "lodge"
                Filterbyproductfilter = " and lodge_prop_count > 0"
            Case "boat"
                Filterbyproductfilter = " and boat_prop_count > 0"
            Case "cottage"
                Filterbyproductfilter = " and cottage_prop_count > 0"
            Case "hotel"
                Filterbyproductfilter = " and hotel_prop_count > 0"
            Case "bb"
                Filterbyproductfilter = " and bb_prop_count > 0"
            Case "villa"
                Filterbyproductfilter = " and villa_prop_count > 0"
            Case Else
                Filterbyproductfilter = ""
        End Select
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Function stripstring(ByVal val As String)
        val = Replace(val, "'", "", 1, -1, 1)
        val = Replace(val, "--", "", 1, -1, 1)
        Return val
    End Function
End Class