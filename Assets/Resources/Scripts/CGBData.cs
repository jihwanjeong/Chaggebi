
public class CGBData
{
    //차깨비 외형 정보
    public bool isPlaced { get; set; } = false;
    public string name { get; set; } = "차깨비";
    public string description { get; set; }
    public int age { get; set; } = 1; //진화단계
    public enum skins { baby, strawberry }
    public skins skin { get; set; } //종류
    public enum colors { green, yellow, red, brown }
    public colors bodyColor { get; set; } //몸색

    public int mouth { get; set; }
    public int brow { get; set; }

    public void UpdateAppearance(CGBData newCGB)
    {
        isPlaced = newCGB.isPlaced;
        name = newCGB.name;
        description = newCGB.description;
        age = newCGB.age;
        skin = newCGB.skin;
        bodyColor = newCGB.bodyColor;
        mouth = newCGB.mouth;
        brow = newCGB.brow;
    }
}
