class Information:

    """
    Diese Klasse übernimmt die Rolle eines InformationsPaketes.
    Objekte werden leer erstellt, rumgereicht, befüllt und am Ende in Excel geschrieben
    """

    url: str = ""
    datum: str = ""
    zeit: str = ""
    postfach: str = ""
    auftragsnummer = ""
    ba_id = ""
    filter_id = ""
    vz_nummer = ""
    bnr = ""
    beanstandung = ""
    kundencodierung = ""
    wekstattcodierung = ""
    postfach_filter = ""

    class Ansprechpartner:
        name = ""
        tel = ""
        plz = ""
        ort = ""

        def give_name(self):
            """
            Returned den Ansprechpartner in einer Zeile
            """
            return "{} Tel: {} Adr: {} {}".format(self.name, self.tel, self.plz, self.ort)

    ansprechpartner = Ansprechpartner()

    class Fahrzeugdaten:
        marke = ""
        modell_jahr = ""
        verkaufstyp = ""
        verkaufstyp_beschreibung = ""
        motor = ""
        getriebe = ""
        auslieferungs_datum = ""
        fahrgestellnr = ""
        laufleistung = ""

        def print_info(self):
            """
            Returned alle Infos in einer Zeile
            """
            return "Marke: {} ModellJahr: {} Verkaufstyp: {} VerkaufsTyp_Besch: {} Motor: {} " \
                   "Getriebe: {} AuslieferungsDatum: {} FahrgestellNr: {} Laufleistung: {}".format(self.marke, self.modell_jahr, self.verkaufstyp, self.verkaufstyp_beschreibung
                                                                                                   , self.motor, self.getriebe, self.auslieferungs_datum, self.fahrgestellnr, self.laufleistung)

    fahrzeugdaten = Fahrzeugdaten()

    class Partnerdaten:
        firma = ""
        # ort = ""
        # name = ""
        # org_id = ""
        # vs = ""
        # region = ""
        # tel = ""
        # email = ""
        # plz = ""
        # straße = ""

        # def print_info(self):
        #     """
        #     Returned die Partnerdaten in einer Zeile
        #     """
        #     return "Firma : {}, Ort: {}, Name: {}, Org-ID: {}, VS: {}, Region: {}, Tel: {}, Email: {}, PLZ: {}, Straße: {}"\
        #         .format(self.firma, self.ort, self.name, self.org_id, self.vs, self.region, self.tel, self.email, self.plz, self.straße)

    partnerdaten = Partnerdaten()
