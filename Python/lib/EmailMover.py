from pathlib import Path
import datetime


# noinspection PyBroadException
def move_email(email: Path, ziel_ordner: str):
    """
    Verschiebt Emails zum Zielort.
    Benennt dabei die Email um
    :param email:
    :param ziel_ordner:
    :return:
    """

    # Konstruiere neuen Namen
    zeit_stempel = datetime.datetime.now().__str__().split(".")[0].replace(" ", "_").replace(":", "-")
    print("test")
    print(zeit_stempel)
    name = "Email_{}.msg".format(zeit_stempel)
    # Verschiebe und benenne um
    try:
        to_file = Path(ziel_ordner + "/" + name)
        email.rename(to_file)
    except:
        print("moving Error")  # TODO RobustheitsWarnung - besser: email muss in Error Ordner
        pass
