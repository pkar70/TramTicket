
' ponieważ NIE DZIAŁA pod Uno.Android wczytywanie pliku (apk nie jest rozpakowany?),
' to w ten sposób przekazywanie zawartości pliku INI
' wychodzi na to samo, edycja pliku defaults.ini albo defsIni.lib.vb

Public Class IniLikeDefaults

    Public Const sIniContent As String = "
[main]
key=value 
uiOd=NOW    ' od kiedy karta wazna, domyslnie: DZIS
uiSmallTicket=400   ' w groszach
uiNormalTicket=600  ' w groszach

# remark
' remark
; remark
// remark

[debug]
key=value # remark

[app]
; lista z app (bez ustawiania)
uiOd=    ' do kiedy karta wazna
uiCenaKarty= ' groszy
kwota=0 ' wydane w biletach
' waznaDni=   ' wyliczane przy ustawieniach

[libs]
; lista z pkarmodule
remoteSystemDisabled=false
appFailData=
offline=false
lastPolnocnyTry=
lastPolnocnyOk=

"

End Class
