from TicketPrompter import turn_off_login_transfer
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from lib.SettingsReader import lese_login
from time import sleep

# Lese LoginData
diss_login = lese_login(not turn_off_login_transfer)

# Gehe auf Diss
# driver = webdriver.Chrome()
driver = webdriver.Firefox()
driver.get("https://portal.cpn.vwg/login/login_de.html")

# Umstellen auf UserID
first_klick = driver.find_element_by_id("modeMsg")
first_klick.click()

# Füllen des Usernamen
Userid = driver.find_element_by_name("user")
Userid.send_keys(diss_login.username)

# Füllen des Passworts
Passwort = driver.find_element_by_id("Password1")
Passwort.send_keys(diss_login.password)
Passwort.send_keys(Keys.ENTER)

# Warte kurz
sleep(2)
fehlertext = ""

# noinspection PyBroadException
try:
    fehlertext = driver.find_element_by_xpath('//*[@id="Table6"]/tbody/tr[3]/td').text
except:
    pass

driver.close()
if fehlertext == "":
    print("Bestanden")
else:
    print("Durchgefallen")
