from enum import Enum


class InfoMessages(Enum):
    SettingsGelesen = 0
    ExcelSkelettErstellt = 1
    JsonSkelettErstellt = 2
    AlleOrdnerAngelegt = 3
    Listening = 4
    NeueEmail = 5
    EmailGelesen = 6
    ErrorEmail = 7
    DissTicketErstellungGestartet = 8
    ErstellungAbgebrochenFahrzeugNichtImGeltungszeitraum = 9
    DissTicketErfolgreichErstellt = 10
    InformationenInExcelGeschrieben = 11
    InformationenInJsonGeschrieben = 12
    FakeDissTicket = 13
    ExcelDateiGefunden = 14
    EmailAbgelaufen = 15


class ErrorMessages(Enum):
    SettingsFileZugriff = 0
    SettingsFileInhalt = 1
    ErstellungExcelDatei = 2
    ErstellungJsonDatei = 3
    DissLogin = 4 # Depricated
    DissFeldBeobachtungAusloesenButton = 5
    DissAnspracheTextfeld = 6
    DissInterneNotizTextfeld = 7
    DissLesenVonInformationenAuslieferungsdatum = 8
    DissLesenVonInformationenMarke = 9
    DissLesenVonInformationenModelljahr = 10
    DissLesenVonInformationenVerkaufstyp = 11
    DissLesenVonInformationenVerkaufstypBeschreibung = 12
    DissLesenVonInformationenMotor = 13
    DissLesenVonInformationenGetriebe = 14
    DissLesenVonInformationenFahrgestellnummer = 15
    DissLesenVonInformationenLaufleistung = 16
    DissLesenVonInformationenPartnerdaten = 17
    DissLesenVonInformationenBeanstandung = 18
    DissLesenVonInformationenKundencodierung = 19
    DissLesenVonInformationenWerkstattkodierung = 20
    DissGeltungscheck = 21
    DissTicketErstellenButton = 22
    ExcelZeileSchreiben = 23
    JsonZeileSchreiben = 24
    DissWebsiteZugriff = 25
    DissUserIDButton = 26
    DissUserNameTextfeld = 27
    DissPasswortTextfeld = 28


def sende_nachricht(info_message: InfoMessages=None, error_message: ErrorMessages=None):

    # Entweder Info oder Error
    if info_message is None and error_message is None:
        return
    if info_message is not None and error_message is not None:
        return

    # Erzeuge prints
    if info_message is not None:
        print("Info.{}".format(info_message).replace("InfoMessages.", ""))
    else:
        print("Error.{}".format(error_message).replace("ErrorMessages.", ""))

