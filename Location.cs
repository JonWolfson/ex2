public class Location {
  public string Name;
  public string Description;
  public Location PreviousRoom;
  public Location NextRoom;
  public bool Illuminated;

  //CONSTRUCTOR
  public Location(string name, bool illuminated) {
    this.Name = name;
    this.Illuminated = illuminated;
  }

  public string GetDescription() {
    if(Illuminated) {
      return Description;
    }
    else {
      return "You enter the room, but it is too dark to see anything.";
    }
  }

  public bool IsIlluminated() {
    return Illuminated;
  }
}
