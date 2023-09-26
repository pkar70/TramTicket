
Public NotInheritable Class ShowLog
    Inherits Page

    Private Sub uiOK_Click(sender As Object, e As RoutedEventArgs)
        Me.Frame.GoBack()
    End Sub

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        uiLogOut.Text = App._logZdarzen
    End Sub
End Class
