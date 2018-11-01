from pathlib import Path
import os
from base64 import b64decode
from lib.SendeModul import ErrorMessages,sende_nachricht

class Settings:

    username: str
    password: str
    interne_notiz : str
    ansprache : str
    geltungszeitraum : int

    def __init__(self, username: str, password: str, interne_notiz: str, ansprache: str, geltungszeitraum: str):
        self.username = username
        self.password = password
        self.interne_notiz = interne_notiz
        self.ansprache = ansprache
        self.geltungszeitraum = int(geltungszeitraum)


settins_file = "DotNet/settings.txt"


def lese_settings():
    """
    Liest Settings aus SettingsFile
    :return:
        SettingsObject
    """
    # Öffne File
    try:
        path = Path(os.getcwd())
        path = path.parent
        path = Path.joinpath(path, settins_file)
        text = path.read_text()
    except:
        sende_nachricht(error_message=ErrorMessages.SettingsFileZugriff)
        return

    # Read Data
    try:
        lines = text.splitlines()
        username = decode(lines[0].split(":")[1])
        passwort = decode(lines[1].split(":")[1])
        notiz = lines[2].split(":")[1]
        ansprache = lines[3].split(":")[1]
        geltungszeitraum = lines[4].split(":")[1]
    except:
        sende_nachricht(error_message=ErrorMessages.SettingsFileInhalt)
        return
    # return SettingsObject
    return Settings(username, passwort, notiz, ansprache, geltungszeitraum)


def decode(text: str):
    return b64decode(text).decode('ascii')


