from selenium import webdriver
import time
from selenium.webdriver.chrome.options import Options

# TODO zeigt Technologie, bald redundant
# Chrome login with UserProfile

# user_profile = r"C:\Users\mr-mc\AppData\Local\Google\Chrome\User Data"
user_profile = "C:/Users/mr-mc/AppData/Local\Google/Chrome/User Data"

options = Options()
# options.add_experimental_option("useAutomationExtension", False)
options.add_argument("user-data-dir="+user_profile)
# options.add_argument("--no-sandbox")
# options.add_argument("--disable-dev-shm-usage")
# options.add_argument("--start-maximized")

driver = webdriver.Chrome(chrome_options=options)
driver.get("https://www.google.de/")
time.sleep(5)

# Firefox login with UserProfile


