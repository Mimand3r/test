from lib.Jira import mache_jira_ticket
from lib.Information import Information

# TODO redundant soon

information = Information()
information.ba_id = "Bsp baID"
information.kundencodierung = "Bsp Kundenkodierung"
information.wekstattcodierung = "Bsp Werkstattkodierung"
information.fahrzeugdaten.fahrgestellnr = "WVWBLIBLABLUB"
information.fahrzeugdaten.modell_jahr = "1980"
information.fahrzeugdaten.verkaufstyp = "bspVerkaufstyp"
information.fahrzeugdaten.laufleistung = "200.000"
information.fahrzeugdaten.motor = "motorkennzahl"
information.fahrzeugdaten.getriebe = "getriebekennzahl"
information.bnr = "2354"

mache_jira_ticket(information)




