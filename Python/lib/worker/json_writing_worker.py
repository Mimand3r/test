import json
import datetime


# TODO Depricated
def write_skelet():

    json_data = {'Runs': []}
    json_data = json.dumps(json_data)

    return json_data

# TODO Depricated
def new_run(old_json):

    # Konstruiere Run Data

    # RunTime & Date
    date = datetime.datetime.now().date()
    time = datetime.datetime.now().time()
    str_time = str(time).split(".")[0]

    # JSON Unteropjekt
    new_json = {"Datum": str(date), "Zeit": str_time, "TriggerEvents": []}

    # Flechte neues Objekt ein
    json_data_full = json.loads(old_json)
    json_data = json_data_full["Runs"]
    json_data.append(new_json)

    # Return als Dumped JSON
    return json.dumps(json_data_full)


def new_trigger(old_json, new_data):

    old_json = json.loads(old_json)
    letzter_run = old_json["Runs"][-1]
    trigger_events = letzter_run["TriggerEvents"]
    trigger_events.append(new_data)
    new_json = json.dumps(old_json)
    return new_json

