# Doku zum Instanthalterrich

Der instanthalterrich ist ein Windowsdienst, welcher den EDU01 Server, sowie den CVS Trainings Server verwaltet.


## Inhalt

- Aufgaben und Funktionsweise
- Aufbau
- Klassen
- Datenbanken


### Aufbau und Funktionsweise

Der Instanthatlerrich, ist ein Windowsdienst, welcher immer wieder auftretende Aufgaben, auf dem EDU01 Server automatisch ab arbeiten soll. 

Die Aufgaben, die der Instanthalterrich bearbeiten kann:

 - Updaten von Alphaplan Versionen
 - Das Wiederherstellen von Datenbanken
 - Das updaten vom ClientSetup
 - Erinnerungs E-Mails und einen AlphaPlan ping für das erneuern von dem SSL Zertifikat.