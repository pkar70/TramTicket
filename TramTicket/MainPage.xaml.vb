﻿Imports vb14 = Vblib.pkarlibmodule14
Imports pkar.Uwp.Ext

Public NotInheritable Class MainPage
    Inherits Page

    Private Const DLUGI_CZAS As Integer = 60
    Private Const KROTKI_CZAS As Integer = 20

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        uiDataOd.Text = vb14.GetSettingsString("uiOd")
        uiDataDo.Text = vb14.GetSettingsString("uiDo") ' mDataDo.ToString("dd MM yyyy")

        uiAdd20.Content = $"{KROTKI_CZAS} min"
        uiAdd50.Content = $"{DLUGI_CZAS} min"

        uiRefresh_Click(Nothing, Nothing)
    End Sub

    Private Sub AddKwota(sSetting As String)

        Dim iBiletGroszy As Integer = vb14.GetSettingsInt(sSetting)

        Dim iGroszy As Integer = vb14.GetSettingsInt("kwota")
        iGroszy += iBiletGroszy
        vb14.SetSettingsInt("kwota", iGroszy, True)

        App._logZdarzen &= $"{Date.Now.ToString("yyyy.MM.dd HH:mm")}    +{iBiletGroszy} = {iGroszy}" & vbCrLf

        uiRefresh_Click(Nothing, Nothing)
    End Sub

    Private Sub uiAdd20_Click(sender As Object, e As RoutedEventArgs)
        ' AddKwota(3.4)
        AddKwota("uiSmallTicket")
    End Sub

    Private Sub uiAdd50_Click(sender As Object, e As RoutedEventArgs)
        'AddKwota(4.6)
        AddKwota("uiNormalTicket")
    End Sub

    Private Sub UstawDniKarty()
        uiSliderCzas.Maximum = CInt((vb14.GetSettingsDate("uiDo") - vb14.GetSettingsDate("uiOd")).TotalDays) + 1
        uiSliderCzas.Value = CInt((DateTimeOffset.Now - vb14.GetSettingsDate("uiOd")).TotalDays) + 1
    End Sub

    Private Sub UstawKoszt()
        Dim dGroszy As Double
        dGroszy = Math.Max(vb14.GetSettingsInt("uiCenaKarty"), vb14.GetSettingsInt("kwota")) / 100.0
        uiSliderKwota.Maximum = dGroszy

        uiSliderKwota.Value = vb14.GetSettingsInt("kwota") / 100.0
    End Sub

    Private Sub uiRefresh_Click(sender As Object, e As RoutedEventArgs)
        UstawDniKarty()
        UstawKoszt()
    End Sub

    Private Sub uiSetting_Click(sender As Object, e As RoutedEventArgs)
        Me.Navigate(GetType(NowaKarta))
    End Sub

    Private Sub uiLog_Click(sender As Object, e As RoutedEventArgs)
        Me.Navigate(GetType(ShowLog))
    End Sub

End Class
