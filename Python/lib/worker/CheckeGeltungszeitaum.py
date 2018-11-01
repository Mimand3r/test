from datetime import datetime
from math import ceil


def checke_geltungszeitraum(startdate: str, geltungszeitraum: int):

    if geltungszeitraum == 0:
        return True

    # Geltungszeitraum in Tage umwandeln
    geltungszeitraum = int(ceil(geltungszeitraum / 12 * 365))
    now = datetime.now().date()
    date_startdate = datetime.strptime(startdate, "%Y-%m-%d").date()

    laufzeit = (now - date_startdate).days

    if laufzeit > geltungszeitraum:
        # Ist zu lange gelaufen
        return False
    else:
        return True
