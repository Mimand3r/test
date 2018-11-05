from selenium import webdriver
from selenium.webdriver.support import expected_conditions as ec
from selenium.webdriver.common.by import By
from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.support.ui import Select

from lib import Information
from lib.SeleniumDriver import driver_setup
import time


def mache_jira_ticket(information: Information):

    # Jira Setup
    jira_url = "https://cocoa.volkswagen.de/sjira/issues/"
    driver = driver_setup()
    driver.get(jira_url)

    # Klicke Certificate Button
    cert = driver.find_element_by_xpath("/html/body/div[7]/div[2]/form[2]/fieldset/input[2]")
    cert.click()

    # Ticket erstellen Button
    WebDriverWait(driver, 10).until(ec.presence_of_element_located((By.ID, "create_link")))
    time.sleep(3)  # TODO Robustheit erhöhen - besser: wait until fully loaded
    first_klick = driver.find_element_by_id("create_link")
    first_klick.click()

    # Zusammenfassung Textbox
    WebDriverWait(driver, 10).until(ec.presence_of_element_located((By.ID, "summary")))
    zsfassung = driver.find_element_by_id("summary")
    zsfassung.send_keys("{}_{}".format(information.ba_id, information.beanstandung))

    # Beschreibung Textbox
    text_button = driver.find_element_by_id("aui-uid-8")
    text_button.click()
    bschreibung = driver.find_element_by_id("description")
    bschreibung.send_keys(information.beanstandung)

    # BA-ID Textbox
    ba_id = driver.find_element_by_id("customfield_12210-textarea")
    ba_id.send_keys(information.ba_id)

    # Kundencodierung Textbox
    ba_id = driver.find_element_by_id("customfield_12212-textarea")
    ba_id.send_keys(information.kundencodierung)

    # Werkstattcodierung Textbox
    ba_id = driver.find_element_by_id("customfield_12211-textarea")
    ba_id.send_keys(information.wekstattcodierung)

    # Fachgruppen SelectionBox
    fachgruppe = Select(driver.find_element_by_id("customfield_11212"))
    fachgruppe.deselect_all()
    fachgruppe.select_by_index(0)  # Sachbearbeiter soll die nachträglich ausfüllen
    # 0 = Keine, 1 = IPB Airbag, 2 = IPB Aufbau Ausstattung, 3 = IPB E Traktion, 4 = IPB Elektrik,
    # 5 = IPB Fahrwerk, 6 = IPB Getriebe, 7 = IPB Infotainment, 8 = IPB MOD, 9 = IPB Motor Diesel, 10 = IPB Motor Otto
    # 11 = IPB Wegfahrsperre, 12 = LB Elektrik, 13 = LB Motor, 14 = LB ZP4, 15 = LB ZP7

    # Sicherheitsstufe SelectionBox
    sich = Select(driver.find_element_by_id("security"))
    sich.select_by_index(1)
    # 0 = Keine, 1 = IPBLB_extern, 2 = IPLB_intern

    # Fahrzeug Reiter anklicken
    fahrzeug = driver.find_element_by_id("aui-uid-3")
    fahrzeug.click()

    # FIN Textbox
    fin = driver.find_element_by_id("customfield_12216-textarea")
    fin.send_keys(information.fahrzeugdaten.fahrgestellnr)

    # ModelJahr Textbox
    year = driver.find_element_by_id("customfield_12612-textarea")
    year.send_keys(information.fahrzeugdaten.modell_jahr)

    # Fahrzeugtyp Textbox
    ftyp = driver.find_element_by_id("customfield_12289-textarea")
    ftyp.send_keys(information.fahrzeugdaten.verkaufstyp)

    # KM-Stand Textbox
    kmstand = driver.find_element_by_id("customfield_12222")
    kmstand.send_keys(information.fahrzeugdaten.laufleistung)

    # MKB Textbox
    mkb = driver.find_element_by_id("customfield_12283")
    mkb.send_keys(information.fahrzeugdaten.motor)

    # GKB Textbox
    gkb = driver.find_element_by_id("customfield_12282")
    gkb.send_keys(information.fahrzeugdaten.getriebe)

    # Ansprechpartner Button
    apartner = driver.find_element_by_id("aui-uid-5")
    apartner.click()

    # Bearbeiter Button
    bearbeiter = driver.find_element_by_id("assign-to-me-trigger")
    bearbeiter.click()

    # Autor Textbox
    autor = driver.find_element_by_id("reporter-field")
    autor.clear()
    autor.send_keys("Tobias Huthwelker")

    # HaendlerNr Textbox
    autor = driver.find_element_by_id("customfield_12250-textarea")
    autor.send_keys(information.bnr)

    # # Absenden Button
    # absenden = driver.find_element_by_id("create-issue-submit")
    # absenden.click()
