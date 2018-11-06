from lib import Information
from pathlib import Path

import ExtractMsg


def lese_email_msg(information: Information, file: Path):

    msg = ExtractMsg.Message(file)
    try:
        # Lese PostfachFilter (Titel der Email)
        information.postfach_filter = msg.subject
        # Lese Datum

        # Depricated - Datum und Zeit aus Email zu lesen hat zu unkonstanz geführt
            # information.datum = " ".join(msg.date.split(" ")[:4])
            # Lese Zeit
            # information.zeit = msg.date.split(" ")[4]

        # Lese Postfach
        information.postfach = msg.to.split('e')[1].split('@')[0]
        # Lese Auftragsnummer
        information.auftragsnummer = msg.body.splitlines()[9].split(" ")[1]
        # Lese BA ID
        information.ba_id = msg.body.splitlines()[12].split(" ")[1]
        # Lese FilterID
        information.filter_id = msg.body.splitlines()[15].split(" ")[1]
        # Lese VZ Nr
        information.vz_nummer = msg.body.splitlines()[18].split(" ")[1]
        # Lese BNr
        information.bnr = msg.body.splitlines()[21].split(" ")[1]

        # Lese Ansprechpartner
        information.ansprechpartner.name = msg.body.splitlines()[24].split(" ", 1)[1]
        information.ansprechpartner.tel = msg.body.splitlines()[27].split(" ", 1)[1]
        information.ansprechpartner.plz = msg.body.splitlines()[30].split(" ", 1)[1]
        information.ansprechpartner.ort = msg.body.splitlines()[33].split(" ", 1)[1]

        # Lese URL
        information.url = msg.body.splitlines()[37].split("<", 1)[1].split(">", 1)[0]
    finally:
        msg.close()

    return information
