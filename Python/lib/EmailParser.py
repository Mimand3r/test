from lib import Information
from pathlib import Path

import ExtractMsg


def lese_email_msg(information: Information, file: Path):

    msg = ExtractMsg.Message(file)
    try:
        # Lese PostfachFilter (Titel der Email)
        information.postfach_filter = msg.subject
        # Lese Datum

        # Depricated - Datum und Zeit aus Email zu lesen hat zu ErrorEmail geführt
            # information.datum = " ".join(msg.date.split(" ")[:4])
            # Lese Zeit
            # information.zeit = msg.date.split(" ")[4]

        # TODO finde neuen weg Postfach zu lesen
            # Lese Postfach
            # information.postfach = msg.to.split('e')[1].split('@')[0]
        # Lese Auftragsnummer
        information.auftragsnummer = msg.body.splitlines()[9].__str__().split(" ")[1].replace("'", "")
        # Lese BA ID
        information.ba_id = msg.body.splitlines()[12].__str__().split(" ")[1].replace("'", "")
        # Lese FilterID
        information.filter_id = msg.body.splitlines()[15].__str__().split(" ")[1].replace("'", "")
        # Lese VZ Nr
        information.vz_nummer = msg.body.splitlines()[18].__str__().split(" ")[1].replace("'", "")
        # Lese BNr
        information.bnr = msg.body.splitlines()[21].__str__().split(" ")[1].replace("'", "")

        # Lese Ansprechpartner
        information.ansprechpartner.name = msg.body.splitlines()[24].__str__().split(" ", 1)[1].replace("'", "")
        information.ansprechpartner.tel = msg.body.splitlines()[27].__str__().split(" ", 1)[1].replace("'", "")
        information.ansprechpartner.plz = msg.body.splitlines()[30].__str__().split(" ", 1)[1].replace("'", "")
        information.ansprechpartner.ort = msg.body.splitlines()[33].__str__().split(" ", 1)[1].replace("'", "")

        # Lese URL
        information.url = msg.body.splitlines()[37].__str__().split("<", 1)[1].split(">", 1)[0]
    finally:
        msg.close()

    return information
