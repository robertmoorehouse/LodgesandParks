Imports Microsoft.VisualBasic

Public Class datacollections

    Public Function GetPersonalTitles() As ArrayList
        Dim MyA As New ArrayList

        With MyA
            .Add("Mr")
            .Add("Mrs")
            .Add("Ms")
            .Add("Miss")
            .Add("Dr")
            '.Add("Rev")
            '.Add("Sir")
            '.Add("Lady")
        End With

        Return MyA
    End Function
    Public Function GetCountriesOfTheWorld() As ArrayList
        Dim MyL As New ArrayList

        MyL.Add("Afghanistan")
        MyL.Add("Albania")
        MyL.Add("Algeria")
        MyL.Add("American Samoa")
        MyL.Add("Andorra")
        MyL.Add("Angola")
        MyL.Add("Anguilla")
        MyL.Add("Antarctica")
        MyL.Add("Antigua And Barbuda")
        MyL.Add("Argentina")
        MyL.Add("Armenia")
        MyL.Add("Aruba")
        MyL.Add("Australia")
        MyL.Add("Austria")
        MyL.Add("Azerbaijan")
        MyL.Add("Bahamas, The")
        MyL.Add("Bahrain")
        MyL.Add("Bangladesh")
        MyL.Add("Barbados")
        MyL.Add("Belarus")
        MyL.Add("Belgium")
        MyL.Add("Belize")
        MyL.Add("Benin")
        MyL.Add("Bermuda")
        MyL.Add("Bhutan")
        MyL.Add("Bolivia")
        MyL.Add("Bosnia and Herzegovina")
        MyL.Add("Botswana")
        MyL.Add("Bouvet Island")
        MyL.Add("Brazil")
        MyL.Add("British Indian Ocean Territory")
        MyL.Add("Brunei")
        MyL.Add("Bulgaria")
        MyL.Add("Burkina Faso")
        MyL.Add("Burundi")
        MyL.Add("Cambodia")
        MyL.Add("Cameroon")
        MyL.Add("Canada")
        MyL.Add("Cape Verde")
        MyL.Add("Cayman Islands")
        MyL.Add("Central African Republic")
        MyL.Add("Chad")
        MyL.Add("Chile")
        MyL.Add("China")
        MyL.Add("Christmas Island")
        MyL.Add("Cocos (Keeling) Islands")
        MyL.Add("Colombia")
        MyL.Add("Comoros")
        MyL.Add("Congo")
        MyL.Add("Congo, Democractic Republic of the")
        MyL.Add("Cook Islands")
        MyL.Add("Costa Rica")
        MyL.Add("Cote D'Ivoire (Ivory Coast)")
        MyL.Add("Croatia (Hrvatska)")
        MyL.Add("Cuba")
        MyL.Add("Cyprus")
        MyL.Add("Czech Republic")
        MyL.Add("Denmark")
        MyL.Add("Djibouti")
        MyL.Add("Dominica")
        MyL.Add("Dominican Republic")
        MyL.Add("East Timor")
        MyL.Add("Ecuador")
        MyL.Add("Egypt")
        MyL.Add("El Salvador")
        MyL.Add("Equatorial Guinea")
        MyL.Add("Eritrea")
        MyL.Add("Estonia")
        MyL.Add("Ethiopia")
        MyL.Add("Falkland Islands (Islas Malvinas)")
        MyL.Add("Faroe Islands")
        MyL.Add("Fiji Islands")
        MyL.Add("Finland")
        MyL.Add("France")
        MyL.Add("French Guiana")
        MyL.Add("French Polynesia")
        MyL.Add("French Southern Territories")
        MyL.Add("Gabon")
        MyL.Add("Gambia, The")
        MyL.Add("Georgia")
        MyL.Add("Germany")
        MyL.Add("Ghana")
        MyL.Add("Gibraltar")
        MyL.Add("Greece")
        MyL.Add("Greenland")
        MyL.Add("Grenada")
        MyL.Add("Guadeloupe")
        MyL.Add("Guam")
        MyL.Add("Guatemala")
        MyL.Add("Guinea")
        MyL.Add("Guinea-Bissau")
        MyL.Add("Guyana")
        MyL.Add("Haiti")
        MyL.Add("Heard and McDonald Islands")
        MyL.Add("Honduras")
        MyL.Add("Hong Kong S.A.R.")
        MyL.Add("Hungary")
        MyL.Add("Iceland")
        MyL.Add("India")
        MyL.Add("Indonesia")
        MyL.Add("Iran")
        MyL.Add("Iraq")
        MyL.Add("Ireland")
        MyL.Add("Israel")
        MyL.Add("Italy")
        MyL.Add("Jamaica")
        MyL.Add("Japan")
        MyL.Add("Jordan")
        MyL.Add("Kazakhstan")
        MyL.Add("Kenya")
        MyL.Add("Kiribati")
        MyL.Add("Korea")
        MyL.Add("Korea, North")
        MyL.Add("Kuwait")
        MyL.Add("Kyrgyzstan")
        MyL.Add("Laos")
        MyL.Add("Latvia")
        MyL.Add("Lebanon")
        MyL.Add("Lesotho")
        MyL.Add("Liberia")
        MyL.Add("Libya")
        MyL.Add("Liechtenstein")
        MyL.Add("Lithuania")
        MyL.Add("Luxembourg")
        MyL.Add("Macau S.A.R.")
        MyL.Add("Macedonia, Former Yugoslav Republic of")
        MyL.Add("Madagascar")
        MyL.Add("Malawi")
        MyL.Add("Malaysia")
        MyL.Add("Maldives")
        MyL.Add("Mali")
        MyL.Add("Malta")
        MyL.Add("Marshall Islands")
        MyL.Add("Martinique")
        MyL.Add("Mauritania")
        MyL.Add("Mauritius")
        MyL.Add("Mayotte")
        MyL.Add("Mexico")
        MyL.Add("Micronesia")
        MyL.Add("Moldova")
        MyL.Add("Monaco")
        MyL.Add("Mongolia")
        MyL.Add("Montserrat")
        MyL.Add("Morocco")
        MyL.Add("Mozambique")
        MyL.Add("Myanmar")
        MyL.Add("Namibia")
        MyL.Add("Nauru")
        MyL.Add("Nepal")
        MyL.Add("Netherlands Antilles")
        MyL.Add("Netherlands, The")
        MyL.Add("New Caledonia")
        MyL.Add("New Zealand")
        MyL.Add("Nicaragua")
        MyL.Add("Niger")
        MyL.Add("Nigeria")
        MyL.Add("Niue")
        MyL.Add("Norfolk Island")
        MyL.Add("Northern Mariana Islands")
        MyL.Add("Norway")
        MyL.Add("Oman")
        MyL.Add("Pakistan")
        MyL.Add("Palau")
        MyL.Add("Panama")
        MyL.Add("Papua new Guinea")
        MyL.Add("Paraguay")
        MyL.Add("Peru")
        MyL.Add("Philippines")
        MyL.Add("Pitcairn Island")
        MyL.Add("Poland")
        MyL.Add("Portugal")
        MyL.Add("Puerto Rico")
        MyL.Add("Qatar")
        MyL.Add("Reunion")
        MyL.Add("Romania")
        MyL.Add("Russia")
        MyL.Add("Rwanda")
        MyL.Add("Saint Helena")
        MyL.Add("Saint Kitts And Nevis")
        MyL.Add("Saint Lucia")
        MyL.Add("Saint Pierre and Miquelon")
        MyL.Add("Saint Vincent And The Grenadines")
        MyL.Add("Samoa")
        MyL.Add("San Marino")
        MyL.Add("Sao Tome and Principe")
        MyL.Add("Saudi Arabia")
        MyL.Add("Senegal")
        MyL.Add("Seychelles")
        MyL.Add("Sierra Leone")
        MyL.Add("Singapore")
        MyL.Add("Slovakia")
        MyL.Add("Slovenia")
        MyL.Add("Solomon Islands")
        MyL.Add("Somalia")
        MyL.Add("South Africa")
        MyL.Add("South Georgia And The South Sandwich Islands")
        MyL.Add("Spain")
        MyL.Add("Sri Lanka")
        MyL.Add("Sudan")
        MyL.Add("Suriname")
        MyL.Add("Svalbard And Jan Mayen Islands")
        MyL.Add("Swaziland")
        MyL.Add("Sweden")
        MyL.Add("Switzerland")
        MyL.Add("Syria")
        MyL.Add("Taiwan")
        MyL.Add("Tajikistan")
        MyL.Add("Tanzania")
        MyL.Add("Thailand")
        MyL.Add("Togo")
        MyL.Add("Tokelau")
        MyL.Add("Tonga")
        MyL.Add("Trinidad And Tobago")
        MyL.Add("Tunisia")
        MyL.Add("Turkey")
        MyL.Add("Turkmenistan")
        MyL.Add("Turks And Caicos Islands")
        MyL.Add("Tuvalu")
        MyL.Add("Uganda")
        MyL.Add("Ukraine")
        MyL.Add("United Arab Emirates")
        MyL.Add("United Kingdom")
        MyL.Add("United States")
        MyL.Add("United States Minor Outlying Islands")
        MyL.Add("Uruguay")
        MyL.Add("Uzbekistan")
        MyL.Add("Vanuatu")
        MyL.Add("Vatican City State (Holy See)")
        MyL.Add("Venezuela")
        MyL.Add("Vietnam")
        MyL.Add("Virgin Islands (British)")
        MyL.Add("Virgin Islands (US)")
        MyL.Add("Wallis And Futuna Islands")
        MyL.Add("Yemen")
        MyL.Add("Yugoslavia")
        MyL.Add("Zambia")
        MyL.Add("Zimbabwe")

        Return MyL

    End Function

    Public Function GetCountriesOfEurope() As ArrayList
        Dim MyL As New ArrayList

        MyL.Add("Austria")
        MyL.Add("Belgium")
        MyL.Add("Denmark")
        MyL.Add("Finland")
        MyL.Add("France")
        MyL.Add("Germany")
        MyL.Add("Greece")
        MyL.Add("Italy")
        MyL.Add("Luxembourg")
        MyL.Add("Netherlands, The")
        MyL.Add("Portugal")
        MyL.Add("Spain")
        MyL.Add("Sweden")

        Return MyL

    End Function
End Class