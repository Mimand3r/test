from selenium import webdriver


def driver_setup():
    profile = webdriver.FirefoxProfile(r"C:\Users\FOX4HUT\AppData\Roaming\Mozilla\Firefox\Profiles\shyc01be.default")
    profile.set_preference("security.default_personal_cert", "Select Automatically")
    profile.accept_untrusted_certs = True
    return webdriver.Firefox(profile)
