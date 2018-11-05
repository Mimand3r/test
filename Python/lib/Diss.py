from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By


from lib import Information
from lib.SettingsReader import Settings
from lib.worker.CheckeGeltungszeitaum import checke_geltungszeitraum
from lib.SendeModul import ErrorMessages, sende_nachricht
from lib.SeleniumDriver import driver_setup


def mache_diss_ticket(settings: Settings, information: Information):

    """
    Performed auf der übergebenen Diss url das erstellen eines Tickets

    :param settings:
        Settings die in .Net eingestellt wurden
    :param information:
        oprionaler Parameter.
        Wird hier ein Informationsonjekt übergeben, so wird es mit Informationen aus der html Seite befüllt
    :param geltungszeitraum:
        Wird benutzt zum prüfen ob geltungszeitraum überschritten ist.
        Wenn ja wird kein Ticket erstellt und None wird returned
    :return:
        returned Entweder nichts oder ein befülltes InformationsObjekt
    """

    ansprache = "Sehr geehrter Volkswagenpartner, Sie haben eine Feldbeobachtung ausgelöst. Bitte noch keine " \
                "Reparaturversuche durchführen! Können Sie die Kundenbeanstandung nachvollziehen/reproduzieren? Unter " \
                "welchen Umständen tritt die Beanstandung auf? Bitte teilen Sie uns ihr erstes Diagnoseergebnis mit. " \
                "Des Weiteren fügen Sie bitte ein aktuelles Eigendiagnoseprotokoll (Gesamtfahrzeug) und die " \
                "Messwertblöcke des Getriebes den Anlagen hinzu. Bei Nutzung von ODIS/UDS, bitte alle relevanten MWB " \
                "bzw. IDE´s vom Getriebesteuergerät auswählen. Mechanische Schäden sind mit Fotos in der Anlage zu " \
                "dokumentieren. Nutzen Sie bitte zur besseren Beschreibung der Beanstandung, den angehängten " \
                "Fragebogen. Freundliche Grüße Tobias Huthwelker "

    driver = driver_setup()
    try:
        driver.get(information.url)
    except:
        sende_nachricht(error_message=ErrorMessages.DissWebsiteZugriff)
        driver.close()

    try:
        # Umstellen auf UserID
        WebDriverWait(driver, 10).until(EC.presence_of_element_located((By.ID, "modeMsg")))
        first_klick = driver.find_element_by_id("modeMsg")
        first_klick.click()
    except:
        sende_nachricht(error_message=ErrorMessages.DissUserIDButton)
        driver.close()

    try:
        # Füllen des Usernamen
        WebDriverWait(driver, 10).until(EC.presence_of_element_located((By.NAME, "user")))
        Userid = driver.find_element_by_name("user")
        Userid.send_keys(settings.username)
    except:
        sende_nachricht(error_message=ErrorMessages.DissUserNameTextfeld)
        driver.close()

    try:
        # Füllen des Passworts
        WebDriverWait(driver, 10).until(EC.presence_of_element_located((By.NAME, "Password1")))
        Passwort = driver.find_element_by_id("Password1")
        Passwort.send_keys(settings.password)
        Passwort.send_keys(Keys.ENTER)
    except:
        sende_nachricht(error_message=ErrorMessages.DissPasswortTextfeld)
        driver.close()


    # Warte kurz
    driver.implicitly_wait()

    try:
        first_klick = driver.find_element_by_id("B_BtnFBAusloesen")
        first_klick.click()
    except:
        # sende_nachricht(error_message=ErrorMessages.DissFeldBeobachtungAusloesenButton)
        driver.close()
        return "abgelaufen"

    # Ansprache
    try:
        ansprache = driver.find_element_by_id("K_idKommunikation")
        ansprache.send_keys(settings.ansprache)
    except:
        sende_nachricht(error_message=ErrorMessages.DissAnspracheTextfeld)
        driver.close()

    # Fülle Interne Notiz
    try:
        interne_notiz = driver.find_element_by_id("K_idInterneNotiz")
        interne_notiz.send_keys(settings.interne_notiz.replace("#Postfach", information.postfach))
    except:
        sende_nachricht(error_message=ErrorMessages.DissInterneNotizTextfeld)
        driver.close()

    if information is not None:
        lese_informationen(driver, information)

    # Teste ob im Geltungszeitraum
    try:
        if not checke_geltungszeitraum(information.fahrzeugdaten.auslieferungs_datum, settings.geltungszeitraum):
            driver.close()
            return None
    except:
        sende_nachricht(error_message=ErrorMessages.DissGeltungscheck)
        driver.close()

    # Button Klick
    try:
        driver.execute_script("document.getElementById('B_BtnSenden').disabled = false")

        button = driver.find_element_by_id("B_BtnSenden")
        button.click()
    except:
        sende_nachricht(error_message=ErrorMessages.DissTicketErstellenButton)
        driver.close()

    # Schließe Driver
    driver.close()
    return information


def lese_informationen(driver: webdriver, information: Information):

    # Lese FahrzeugDaten

    # lese Auslieferungsdatum
    try:
        information.fahrzeugdaten.auslieferungs_datum = driver.find_element_by_id("Z_6").text
    except:
        sende_nachricht(error_message=ErrorMessages.DissLesenVonInformationenAuslieferungsdatum)

    # lese Marke
    try:
        information.Fahrzeugdaten.marke = driver.find_element_by_id("Z_1").text
    except:
        sende_nachricht(error_message=ErrorMessages.DissLesenVonInformationenMarke)

    # lese Modelljahr
    try:
        information.fahrzeugdaten.modell_jahr = driver.find_element_by_id("Z_2").text
    except:
        sende_nachricht(error_message=ErrorMessages.DissLesenVonInformationenModelljahr)

    # lese Verkaufstyp
    try:
        information.fahrzeugdaten.verkaufstyp = driver.find_element_by_id("Z_3").text
    except:
        sende_nachricht(error_message=ErrorMessages.DissLesenVonInformationenVerkaufstyp)

    # lese Verkaufstyp Beschreibung
    try:
        information.fahrzeugdaten.verkaufstyp_beschreibung = driver.find_element_by_id("Z_8").text
    except:
        sende_nachricht(error_message=ErrorMessages.DissLesenVonInformationenVerkaufstypBeschreibung)

    # lese Motor
    try:
        information.fahrzeugdaten.motor = driver.find_element_by_id("Z_4").text
    except:
        sende_nachricht(error_message=ErrorMessages.DissLesenVonInformationenMotor)

    # lese Getriebe
    try:
        information.fahrzeugdaten.getriebe = driver.find_element_by_id("Z_5").text
    except:
        sende_nachricht(error_message=ErrorMessages.DissLesenVonInformationenGetriebe)

    # lese Fahrgestellnummer
    try:
        information.fahrzeugdaten.fahrgestellnr = driver.find_element_by_xpath('//*[@id="Z_TableFahrzeug"]/tbody/tr[9]/td[2]').text
    except:
        sende_nachricht(error_message=ErrorMessages.DissLesenVonInformationenFahrgestellnummer)

    # lese Laufleistung
    try:
        information.fahrzeugdaten.laufleistung = driver.find_element_by_id("Z_7").text.split(" ")[0]
    except:
        sende_nachricht(error_message=ErrorMessages.DissLesenVonInformationenLaufleistung)

    # Lese Partnerdaten
    try:
        information.partnerdaten.firma = driver.find_element_by_xpath('//*[@id="Z_TablePartner"]/tbody/tr[2]/td[2]')
    except:
        sende_nachricht(error_message=ErrorMessages.DissLesenVonInformationenPartnerdaten)

    # Lese Beanstandung
    try:
        information.beanstandung = driver.find_element_by_id("Z_TbKundenaussage").text
    except:
        sende_nachricht(error_message=ErrorMessages.DissLesenVonInformationenBeanstandung)

    # Lese Kundencodierung
    try:
        information.kundencodierung = driver.find_element_by_id("Z_TbKCode").text.replace(" ", "").replace(">", "_")
    except:
        sende_nachricht(error_message=ErrorMessages.DissLesenVonInformationenKundencodierung)

    # Lese Werkstattkodierung
    try:
        information.wekstattcodierung = driver.find_element_by_id("Z_TbWCode").text.replace(" ", "").replace(">", "_")
    except:
        sende_nachricht(error_message=ErrorMessages.DissLesenVonInformationenWerkstattkodierung)
