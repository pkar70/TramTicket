Imports vb14 = Vblib.pkarlibmodule14
Imports pkar.Uwp.Configs
Imports pkar.Uwp.Ext

Public NotInheritable Class NowaKarta
    Inherits Page

    Private Async Sub uiOk_Click(sender As Object, e As RoutedEventArgs)

        If uiOd.Date > uiDo.Date Then
            vb14.DialogBox("Data ważności nie może być ważna mniejsza niż data początku")
            Return
        End If

        ' vb14.SetSettingsInt("waznaDni", (uiDo.Date.Value - uiOd.Date.Value).TotalDays + 1)

        uiCenaKarty.SetSettingsInt("uiCenaKarty", False, 100)
        uiSmallTicket.SetSettingsInt("uiSmallTicket", False, 100)
        uiNormalTicket.SetSettingsInt("uiNormalTicket", False, 100)

        uiOd.SetSettingsDate()
        uiDo.SetSettingsDate()

        'vb14.AppendLogYearly(
        '        vbCrLf & vbCrLf & DateTime.Now.ToString("yyyy.MM.dd") & " zmiana danych" & vbCrLf &
        '        "Ważna od: " & uiOd.Date.Value.ToString("yyyy.MM.dd") & vbCrLf &
        '        "Ważna do: " & uiDo.Date.Value.ToString("yyyy.MM.dd") & vbCrLf &
        '        "Cena karty (groszy):" & uiCenaKarty.Text & vbCrLf &
        '        "Mały bilet (groszy):" & uiSmallTicket.Text & vbCrLf &
        '        "Duży bilet (groszy):" & uiNormalTicket.Text & vbCrLf)

        If Await vb14.DialogBoxYNAsync("Zresetować licznik?") Then
            'vb14.AppendLogYearly("reset licznika, stan bieżący: " & vb14.GetSettingsInt("kwota") & vbCrLf)
            vb14.SetSettingsInt("kwota", 0)
        End If

        Me.GoBack()

    End Sub


    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        uiCenaKarty.GetSettingsInt("uiCenaKarty", 100)
        uiSmallTicket.GetSettingsInt("uiSmallTicket", 100)
        uiNormalTicket.GetSettingsInt("uiNormalTicket", 100)

        uiOd.GetSettingsDate()
        uiDo.GetSettingsDate()

    End Sub

    Private Sub uiAddMonth_Click(sender As Object, e As RoutedEventArgs)
        uiOd.Date = uiOd.Date.Value.AddMonths(1)
        uiDo.Date = uiDo.Date.Value.AddMonths(1)
    End Sub



End Class
