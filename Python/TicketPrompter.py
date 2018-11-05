# This Python file uses the following encoding: utf-8
import time
from pathlib import Path
import os


# Eigene Module
from lib.Diss import mache_diss_ticket
from lib.Excel import erstelle_excel_datei
from lib import Information
from lib.Excel import schreibe_zeile_in_excel
from lib.EmailParser import lese_email_msg
from lib.JSON import json_neuer_run
from lib.JSON import schreibe_zeile_in_json
from lib.SettingsReader import Settings, lese_settings
from lib.EmailMover import move_email
from lib.SendeModul import ErrorMessages, InfoMessages, sende_nachricht

# ----------------------------------------------------------------------
# EinstellParameter
trigger_folder = "TriggerSection/neueTrigger"
erledigt_folder = "TriggerSection/erledigteTrigger"
ergebnis_ordner = "ExcelLogFiles"
error_ordner = "TriggerSection/error"
verpasst_ordner = "TriggerSection/verpassteTrigger"
geltungszeitraum_folder = "TriggerSection/außerhalbGeltungszeitraum"

# TODO Json zurzeit not in use
json_file_name = "runData.json"  # Wird benutzt zur Rückgabe der Infos an dotNet (zurzeit nicht relevant)

# -----------------------------------------------------------------------
# Dev Parameters

turn_off_Diss = False
turn_off_Jira = True

# -----------------------------------------------------------------------
if __name__ == "__main__":

    # Lese SettingsFile
    settings: Settings = lese_settings()
    sende_nachricht(info_message=InfoMessages.SettingsGelesen)

    # Erzeuge neue Excel
    try:
        erstelle_excel_datei(ergebnis_ordner)
    except:
        sende_nachricht(error_message=ErrorMessages.ErstellungExcelDatei)

    # Mache Eintrag in JSON
    # try:
    #     json_neuer_run(json_file_name)
    #     sende_nachricht(info_message=InfoMessages.JsonSkelettErstellt)
    # except:
    #     sende_nachricht(error_message=ErrorMessages.ErstellungJsonDatei)

    # Erzeuge Trigger Folder falls nicht vorhanden
    # TODO erzeuge alle ordner wenn nicht vorhanden
    try:
        os.mkdir(trigger_folder)
    except:
        pass
    sende_nachricht(info_message=InfoMessages.AlleOrdnerAngelegt)

    # Connecte zum Trigger Folder
    folder_path = Path(trigger_folder)

    sende_nachricht(info_message=InfoMessages.Listening)

    # print("JSON:{}\{}".format(os.getcwd(), json_file_name))

    # Endlos Schleife
    while True:

        # Prüfe ob neue TextFile reingekommen ist
        for child in folder_path.glob('*.msg'):

            sende_nachricht(info_message=InfoMessages.NeueEmail)
            # Erstelle InformationsObjekt
            information = Information()
            # Lese Email aus
            try:
                information = lese_email_msg(information, child)
                sende_nachricht(info_message=InfoMessages.EmailGelesen)
            except:
                print("unerwartete Struktur der Email")
                move_email(child, error_ordner)
                sende_nachricht(info_message=InfoMessages.ErrorEmail)
                sende_nachricht(info_message=InfoMessages.Listening)
                continue

            # Erstelle Diss Ticket
            if not turn_off_Diss:
                sende_nachricht(info_message=InfoMessages.DissTicketErstellungGestartet)
                information = mache_diss_ticket(settings, information)  # liest Zusatzinformationen aus
            else:
                sende_nachricht(info_message=InfoMessages.FakeDissTicket)

            if information is None:
                # Fall Tritt auf wenn Fahrzeug nicht im Geltungszeitraum
                move_email(child, geltungszeitraum_folder)
                sende_nachricht(info_message=InfoMessages.ErstellungAbgebrochenFahrzeugNichtImGeltungszeitraum)
                sende_nachricht(info_message=InfoMessages.Listening)
                continue

            if information == "abgelaufen":
                # Fall Tritt auf wenn Email zu alt
                move_email(child, verpasst_ordner)
                sende_nachricht(info_message=InfoMessages.EmailAbgelaufen)
                sende_nachricht(info_message=InfoMessages.Listening)
                continue

            move_email(child, erledigt_folder)

            # Erstelle Jira Ticket
            # if not turn_off_Jira:
            #       Jiraticket

            # neue Zeile in Excel
            try:
                schreibe_zeile_in_excel(information)
                sende_nachricht(info_message=InfoMessages.InformationenInExcelGeschrieben)
            except:
                sende_nachricht(error_message=ErrorMessages.ExcelZeileSchreiben)

            # neue Zeile in JSON
            # try:
            #     schreibe_zeile_in_json(information)
            #     sende_nachricht(info_message=InfoMessages.InformationenInJsonGeschrieben)
            # except:
            #     sende_nachricht(error_message=ErrorMessages.JsonZeileSchreiben)

            sende_nachricht(info_message=InfoMessages.DissTicketErfolgreichErstellt)

            sende_nachricht(info_message=InfoMessages.Listening)
        # Warte
        time.sleep(5)  # Bestimmt wie oft pro Sekunde auf neue Files geprüft wird
