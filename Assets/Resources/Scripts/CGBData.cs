[System.Serializable]
public class CGBData
{
    //차깨비 외형 정보
    public bool isPlaced { get; set; } = false;
    public int age { get; set; } = 1; //진화단계
    public string base1 { get; set; } //몸색(1단계)
    public string base2 { get; set; } //스킨(2단계)
    public enum flavors { none, scent, earthy, sweet, sour } public flavors flavor { get; set; } //맛(3단계)
    public string name { get; set; } = "차깨비";
    public string description { get; set; }

    //public enum skins { baby, strawberry, lemon, butterfly }
    //public skins skin { get; set; } //종류
    //public enum colors { green, yellow, red, brown, blue }
    //public colors bodyColor { get; set; } //몸색

    public int mouth { get; set; }
    public int brow { get; set; }

    public void UpdateAppearance(CGBData newCGB)
    {
        isPlaced = newCGB.isPlaced;
        age = newCGB.age;
        base1 = newCGB.base1;
        base2 = newCGB.base2;
        name = newCGB.name;
        description = newCGB.description;
        //skin = newCGB.skin;
        //bodyColor = newCGB.bodyColor;
        mouth = newCGB.mouth;
        brow = newCGB.brow;
    }
}
