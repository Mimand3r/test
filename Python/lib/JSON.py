from pathlib import Path
import lib.worker.json_writing_worker as js_write

from lib import Information

# TODO Depricated
current_file: Path

# TODO Depricated
def json_neuer_run(json_file_name):

    # Prüfe ob JSON File existiert
    global current_file
    current_file = Path(json_file_name)

    # Es ist existiert keine JSON. Erzeuge neue + apply Grundsskelett
    if not current_file.is_file():

        current_file.open("w+")
        jsData = js_write.write_skelet()
        current_file.write_text(jsData)

    # Mache neuen Run Entry
    jsData = current_file.read_text()
    jsData = js_write.new_run(jsData)
    current_file.write_text(jsData)


def schreibe_zeile_in_json(information: Information):

    # Konstruiere InformationsObjekt
    new_data = {}
    new_data["Url"] = information.url
    new_data["Datum"] = information.datum
    new_data["Zeit"] = information.zeit
    new_data["Postfach"] = information.postfach
    new_data["AuftragsNr"] = information.auftragsnummer
    new_data["Ba_ID"] = information.ba_id
    new_data["Filter_ID"] = information.filter_id
    new_data["VZ_Nr"] = information.vz_nummer
    new_data["B_Nr"] = information.bnr
    new_data["Ansprechpartner"] = {}
    new_data["Ansprechpartner"]["Name"] = information.ansprechpartner.name
    new_data["Ansprechpartner"]["Tel"] = information.ansprechpartner.tel
    new_data["Ansprechpartner"]["PLZ"] = information.ansprechpartner.plz
    new_data["Ansprechpartner"]["Ort"] = information.ansprechpartner.ort
    new_data["Fahrzeugdaten"] = {}
    new_data["Fahrzeugdaten"]["Marke"] = information.fahrzeugdaten.marke
    new_data["Fahrzeugdaten"]["ModellJahr"] = information.fahrzeugdaten.modell_jahr
    new_data["Fahrzeugdaten"]["Verkaufstyp"] = information.fahrzeugdaten.verkaufstyp
    new_data["Fahrzeugdaten"]["Verkaufstyp_Beschr"] = information.fahrzeugdaten.verkaufstyp_beschreibung
    new_data["Fahrzeugdaten"]["Motor"] = information.fahrzeugdaten.motor
    new_data["Fahrzeugdaten"]["Getriebe"] = information.fahrzeugdaten.getriebe
    new_data["Fahrzeugdaten"]["AuslieferungsDatum"] = information.fahrzeugdaten.auslieferungs_datum
    new_data["Fahrzeugdaten"]["FahrgestellNummer"] = information.fahrzeugdaten.fahrgestellnr
    new_data["Fahrzeugdaten"]["Laufleistung"] = information.fahrzeugdaten.laufleistung
    new_data["Partnerdaten"] = {}
    new_data["Partnerdaten"]["Firma"] = information.partnerdaten.firma

    # Read Old Data
    current_file = Path("runData.json")
    old_jsData = current_file.read_text()

    # Flechte neue Daten ein
    js_data = js_write.new_trigger(old_jsData, new_data)

    # Speichere auf Disk
    current_file.write_text(js_data)
