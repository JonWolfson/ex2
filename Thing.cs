public class Thing {
  public string Name;
  public string Description;
  public string Details;

  //CONSTRUCTOR
  public Thing(string name) {
    this.Name = name;
  }

  public string GetDescription() {
    string thingDescription = "";
    thingDescription += Description + " " + Details;

    return thingDescription;
  }
}
