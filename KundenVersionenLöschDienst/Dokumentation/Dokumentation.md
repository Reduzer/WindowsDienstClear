# Dokumentation von dem Instandhalterrich

Der Instandhalerrich automatisiert viele Aufgaben, welche auf dem EDU01 Server gemacht werden müssen.

## Aufgaben

- Versionslöschen
- Aktuallisieren
- ClientSetup
- Wiederherstellungsskripte
- Ping
- AP Schnittstelle
- Nützliche Dinge

## Versionslöschen

Das Versionslöschen bezieht sich auf von Kunden erstellte Versionen, welche sich auf dem EDU01 Server befinden.

Diese sollen nach einer gewissen Zeit wieder gelöscht werden, um Speicherplatz ein zu spaaren.

Hierfür wird die Klasse "deleteFiles.cs" genutzt, welche die vorhandenen Datein einliest und sobald diese älter als eine Woche sind automatisch löscht.

## Aktuallisieren

Das Aktuallisieren ist auf die AlphaPlan Versionen, welche sich auf dem Server befinden bezogen. Diese sollen immer auf der Neusten Version gehalten werden, welche aktuell zugelassen ist.

Hierfür sind die Zwei Klassen "sql.cs" und "updater.cs" genutzt. Die updater.cs Klasse ist hier die ausführende Klasse, welche zuerst überprüft, ob die aktuell installierte Alphaplan Version, der aktuell neusten erlaubten Version entspricht. Sollte dies nicht der Fall sein, wird automatisch ein Update auf die neuste Version ausgeführt.

Die sql.cs Klasse ist hier für die Verfolgbarkeit der Updates zuständig. Diese schreibt in eine hierfürt angelegte Datenbank, welche Version, auf welche Version geupdated wurde und wann.

So kann nachgewiesen werden, dass die Updates zuverlässig durchlaufen.

## ClientSetup

Da die neuen AlphaPlan Versionen ein ClientSetup benötigen, wird dieses auch aktuallisert, um die Funktionstüchtigkeit zu gewährleisten.

## Wiederherstellungsskripte

Die Wiederherstellungsskripte haben die Aufgabe, die Datenbanken, welche für Seminare benötigt werden, wieder auf ihren Ursprung zurück zu setzten, so das mit diesesn wieder gearbeitet werden kann. Da ein Seminar nur ein mal die Woche statt findet, wird dies zum Ende jeder Woche gemacht.

## Ping

Die Ping Klassen, sind dafür da, um sowohl den Entwickler, bei Problemen, so wie andere Nutzer bei generellen Dingen zu Informieren.
Dies läuft per E-Mails und Aufgaben in AlphaPlan.

## AP Schnitstelle

Noch in Arbeit!

Die AP Schnittstelle dient dafür, um die interaktion mit AlphaPlan zu gewährleisten.

## Nützliche Dinge

Hier sind Dinge, wie ein Exception Handler etc. zu finden.
